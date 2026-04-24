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

    [HarmonyPatch(typeof(SpaceVehicleActionBehaviourProbe), nameof(SpaceVehicleActionBehaviourProbe.GetScanRange))]
    public static class ProbeRange
    {
        public static void Postfix(ref float __result)
        {
            __result = Buildings.miscellaneousSettings[0].getValue() / 10f;
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourCropFarm), nameof(BuildingActionBehaviourCropFarm.GrowthMaxDuration), MethodType.Getter)]
    public static class CropFarmGrowthDuration
    {
        public static void Postfix(ref float __result)
        {
            foreach (var set in Buildings.cropsFarmSettings)
            {
                var diff = set.Key.getDefaultValueFloat() * 60f - __result;
                if (diff is < -3 or > 3) continue;
                if (!Mathf.Approximately(set.Key.getDefaultValueFloat(), set.Key.getValueFloat()))
                    __result = set.Key.getValueFloat() * 60f;
            }
        }
    }
    
    [HarmonyPatch(typeof(BuildingActionBehaviourCropFarmField), nameof(BuildingActionBehaviourCropFarmField.ProduceMealPerSecond), MethodType.Getter)]
    public static class CropFarmProduction
    {
        public static void Postfix(ref float __result)
        {
            foreach (var set in Buildings.cropsFarmSettings)
            {
                if (!Mathf.Approximately(set.Value.getDefaultValueFloat() / 60f, __result)) continue;
                if (!Mathf.Approximately(set.Value.getDefaultValueFloat(), set.Value.getValueFloat()))
                    __result = set.Value.getValueFloat() / 60f;
            }
        }
    }
    
    [HarmonyPatch(typeof(AlgaeFarmMaxChildCountModifier), nameof(AlgaeFarmMaxChildCountModifier.GetMaxChildCount))]
    public static class AlgaeFarmAmount
    {
        public static void Postfix(ref int __result)
        {
            foreach (var set in Buildings.algaeFarmSettings)
            {
                if (set.getDefaultValue() == __result)
                {
                    __result = set.getValue();
                }
            }
        }
    }
    
    [HarmonyPatch(typeof(InsectFarmGenerationTimeMultiplier), nameof(InsectFarmGenerationTimeMultiplier.GetMultiplier))]
    public static class InsectFarmGrowthDuration
    {
        public static void Postfix(ref float __result)
        {
            foreach (var set in Buildings.insectFarmSettings)
            {
                if (Mathf.Approximately(set.getDefaultValueFloat(), __result))
                {
                    __result = set.getValueFloat();
                }
            }
        }
    }
    
    [HarmonyPatch(typeof(BuildingActionBehaviourGeneration), nameof(BuildingActionBehaviourGeneration.BuildingApplyState))]
    public static class InsectFarmProductionAmount
    {
        public static void Postfix(BuildingActionBehaviourGeneration __instance)
        {
            __instance.generatedResources.SetResource(ResourceData.TYPE.FOOD, Buildings.insectFarmAmountSetting.getValue(), false);
        }
    }
    
    [HarmonyPatch(typeof(BuildingActionBehaviourTransformation), nameof(BuildingActionBehaviourTransformation.GetTransformationResult))]
    public static class FactoryResults
    {
        public static void Postfix(ResourceContainer __result)
        {
            foreach (var set in Buildings.factoryResultSettings)
            {
                if (__result.GetResourceCount(ResourceData.TYPE.ALLOY) == set.getDefaultValue())
                {
                    __result.SetResource(ResourceData.TYPE.ALLOY, set.getValue());
                    break;
                }
                if (__result.GetResourceCount(ResourceData.TYPE.ELECTRONICS) == set.getDefaultValue())
                {
                    __result.SetResource(ResourceData.TYPE.ELECTRONICS, set.getValue());
                    break;
                }
                if (__result.GetResourceCount(ResourceData.TYPE.POLYMER) == set.getDefaultValue())
                {
                    __result.SetResource(ResourceData.TYPE.POLYMER, set.getValue());
                    break;
                }
            }
        }
    }

    [HarmonyPatch(typeof(BuildingActionBehaviourTransformation), nameof(BuildingActionBehaviourTransformation.GetTransformationCost))]
    public static class FactoryCosts
    {
        public static void Postfix(ResourceContainer __result)
        {
            foreach (var set in Buildings.factoryCostSettings)
            {
                if (__result.GetResourceCount(ResourceData.TYPE.IRON) == set.getDefaultValue())
                {
                    __result.SetResource(ResourceData.TYPE.IRON, set.getValue());
                    break;
                }
                if (__result.GetResourceCount(ResourceData.TYPE.SILICON) == set.getDefaultValue())
                {
                    __result.SetResource(ResourceData.TYPE.SILICON, set.getValue());
                    break;
                }
                if (__result.GetResourceCount(ResourceData.TYPE.CARBON) == set.getDefaultValue())
                {
                    __result.SetResource(ResourceData.TYPE.CARBON, set.getValue());
                    break;
                }
            }
        }
    }
}