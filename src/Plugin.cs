
using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace PowerOverhaul
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "com.cubernetic.poweroverhaul";
        public const string PluginName = "PowerOverhaul";
        public const string PluginVersion = "0.1.0";

		internal static ConfigEntry<bool>  Enabled = null!;
    	internal static ConfigEntry<float> PowerMultiplier = null!;

		internal static ManualLogSource Log = null;

        private Harmony harmony;

        private void Awake()
        {
            harmony = new Harmony(PluginGuid);

			Log = Logger;

			try
			{
				// Persisted to BepInEx/config/com.cubernetic.poweroverhaul.cfg
				Enabled = Config.Bind(
					"General", "Enabled", true,
					"Turn the mod on/off without uninstalling.");

				PowerMultiplier = Config.Bind(
					"Power", "Multiplier", 1.0f,
					new ConfigDescription(
						"Scale device power usage; 0.5 = half, 1.0 = full.",
						new AcceptableValueRange<float>(0.05f, 1.0f)
					));

				harmony.PatchAll();
			}
			catch (Exception exc)
			{
				Logger.LogError($"Failed to apply patch: {exc}");
			}
        }

        private void OnDestroy()
        {
            try
            {
                harmony?.UnpatchSelf();
            }
            catch (Exception exc)
            {
                Logger.LogError($"Unpatch failed: {exc}");
            }
        }
    }
}

