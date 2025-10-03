
using HarmonyLib;

using Assets.Scripts.Objects.Pipes;
using Assets.Scripts.Networks;

namespace PowerOverhaul
{
	[HarmonyPatch]
	static class DevicePatches
	{
		// Some devices do not have an override for GetUsedPower. At the time of writing, only the
		// Device class in the hierarchy has it. So we patch that, and check the instance type in
		// the postfix. Unfortunately, Harmoniy does not support searching from a derived tye along
		// its base types, so we have to specify the Device class directly. This also means, once
		// a derived class has its own override, things may break if the derived class does not call
		// base.GetUsedPower().
		[HarmonyPatch(typeof(Device), nameof(Device.GetUsedPower), new[] { typeof(CableNetwork) })]
		[HarmonyPostfix]
		static void GetUsedPower(object __instance, CableNetwork cableNetwork, ref float __result)
		{
			if (!Plugin.Enabled.Value)
			{
				return;
			}

			// preserve special meanings:
			// -1 => not on this network, 0 => off/not built
			if (__result <= 0f)
			{
				return;
			}

			// Add all types that should be affected by the power scaling here and currently do not
			// have their own override for GetUsedPower.
			switch (__instance)
			{
				case PressureRegulator:
				case Mixer:
					__result *= Plugin.PowerMultiplier.Value;
					return;
			}
		}
	}
}

