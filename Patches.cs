using BulwarkStudios.Stanford.Common.TechTree;
using BulwarkStudios.Stanford.Torus.Buildings;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;
using HarmonyLib;

namespace BuildingValuesCustomizer;

public static class Patches
{
    [HarmonyPatch(typeof(BuildingActionTotalCapacity), nameof(BuildingActionTotalCapacity.GetTotalCapacityStockpile))]
    public static class StockpilesCapacity
    {
        public static void Postfix(ref int __result)
        {
            if (!Plugin.enabled) return;
            foreach (var set in Buildings.stockpileSettings)
                if (set.getDefaultValue() == __result)
                    __result = set.getValue();
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourQuarter), nameof(BuildingActionBehaviourQuarter.GetMaxCitizen))]
    public static class HouseCapacity
    {
        public static void Postfix(ref int __result)
        {
            if (!Plugin.enabled) return;
            foreach (var set in Buildings.housingSettings)
                if (set.getDefaultValue() == __result)
                    __result = set.getValue();
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourCellHousing), nameof(BuildingActionBehaviourCellHousing.GetMaxCitizen))]
    public static class CellHouseCapacity
    {
        public static void Postfix(ref int __result)
        {
            if (!Plugin.enabled) return;
            foreach (var set in Buildings.cellHousingSettings)
                if (set.getDefaultValue() == __result)
                    __result = set.getValue();
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourGenerator), nameof(BuildingActionBehaviourGenerator.MaximumCapacity),
        MethodType.Getter)]
    public static class BatteryCapacity
    {
        public static void Postfix(ref int __result)
        {
            if (!Plugin.enabled) return;
            foreach (var set in Buildings.batteriesSettings)
                if (set.getDefaultValue() * 60 == __result)
                    __result = set.getValue() * 60;
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourScienceLab), nameof(BuildingActionBehaviourScienceLab.GetActiveTeam))]
    public static class ScienceLab
    {
        private static int done;

        public static void Postfix(BuildingActionBehaviourScienceLab __instance)
        {
            if (!Plugin.enabled) return;
            done++;
            if (done is < 2 or > 2) return;
            foreach (var team in __instance.teams)
            foreach (var set in Buildings.scienceLabSettings)
                if (team.sciencePerProduction == set.Key.getDefaultValue() &&
                    team.cyclePerProduction == set.Value.getDefaultValue())
                {
                    team.sciencePerProduction = set.Key.getValue();
                    team.cyclePerProduction = set.Value.getValue();
                }
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourStockpile), nameof(BuildingActionBehaviourStockpile.GetNbTransporters))]
    public static class StockpilesTransporters
    {
        public static void Postfix(ref int __result)
        {
            if (!Plugin.enabled) return;
            foreach (var set in Buildings.stockpileTransporterSettings)
                if (set.getDefaultValue() == __result)
                    __result = set.getValue();
        }
    }
}