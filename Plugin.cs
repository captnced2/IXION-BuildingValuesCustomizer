using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using IMHelper;

namespace BuildingValuesCustomizer;

[BepInPlugin(Guid, Name, Version)]
[BepInProcess("IXION.exe")]
[BepInDependency("captnced.IMHelper")]
public class Plugin : BasePlugin
{
    private const string Guid = "captnced.BuildingValuesCustomizer";
    internal const string Name = "BuildingValuesCustomizer";
    private const string Version = "1.0.0";
    internal new static ManualLogSource Log;
    internal static bool enabled = true;
    private static Harmony harmony;
    internal static List<SettingsHelper.SettingsSection> sections;

    public override void Load()
    {
        Log = base.Log;
        harmony = new Harmony(Guid);
        if (IL2CPPChainloader.Instance.Plugins.ContainsKey("captnced.IMHelper")) setEnabled();
        if (!enabled)
            Log.LogInfo("Disabled by IMHelper!");
        else
            init();
    }

    private static void setEnabled()
    {
        enabled = ModsMenu.isSelfEnabled();
    }

    private static void init()
    {
        sections = [];
        Buildings.init();
        harmony.PatchAll();
        foreach (var patch in harmony.GetPatchedMethods())
            Log.LogInfo("Patched " + patch.DeclaringType + ":" + patch.Name);
        Log.LogInfo("Loaded \"" + Name + "\" version " + Version + "!");
    }

    private static void disable()
    {
        foreach (var section in sections) section?.destroySection();
        sections = [];
        Log.LogInfo("Unloaded \"" + Name + "\" version " + Version + "!");
    }

    public static void enable(bool value)
    {
        enabled = value;
        if (enabled) init();
        else disable();
    }
}