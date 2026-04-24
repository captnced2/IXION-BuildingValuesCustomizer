using BulwarkStudios.Stanford.Core.GameResources;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles.Actions;
using BulwarkStudios.Stanford.Torus.Buildings;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;
using HarmonyLib;
using UnityEngine;

namespace BuildingValuesCustomizer;

public static class Patches
{
    [HarmonyPatch(typeof(BuildingActionTotalCapacity), nameof(BuildingActionTotalCapacity.GetTotalCapacityStockpile))]
    public static class StockpilesCapacity
    {
        public static void Postfix(ref int __result)
        {
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
            foreach (var set in Buildings.batteriesSettings)
                if (set.getDefaultValue() * 60 == __result)
                    __result = set.getValue() * 60;
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourScienceLab), nameof(BuildingActionBehaviourScienceLab.GetActiveTeam))]
    public static class ScienceLab
    {
        public static void Postfix(ref BuildingActionBehaviourScienceLab.Team __result)
        {
            foreach (var set in Buildings.scienceLabSettings)
                if (__result.SciencePerProduction == set.Key.getDefaultValue() &&
                    Mathf.Approximately(__result.CyclePerProduction, set.Value.getDefaultValue()))
                {
                    var newTeam = new BuildingActionBehaviourScienceLab.Team
                    {
                        technology = __result.technology,
                        sciencePerProduction = set.Key.getValue(),
                        cyclePerProduction = set.Value.getValue()
                    };
                    __result = newTeam;
                }
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourStockpile), nameof(BuildingActionBehaviourStockpile.GetNbTransporters))]
    public static class StockpilesTransporters
    {
        public static void Postfix(ref int __result)
        {
            foreach (var set in Buildings.stockpileTransporterSettings)
                if (set.getDefaultValue() == __result)
                    __result = set.getValue();
        }
    }
}