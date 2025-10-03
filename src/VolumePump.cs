
using HarmonyLib;

using Assets.Scripts.Networks;
using Objects.Pipes;

namespace PowerOverhaul
{
	[HarmonyPatch]
	static class VolumePumpPatches
	{
		[HarmonyPatch(typeof(VolumePump), nameof(VolumePump.GetUsedPower), new[] { typeof(CableNetwork) })]
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

			__result *= Plugin.PowerMultiplier.Value;
		}
	}
}

