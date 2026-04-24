using System.Collections.Generic;
using Il2CppSystem;
using IMHelper;

namespace BuildingValuesCustomizer;

public static class Buildings
{
    internal static SettingsHelper.SettingsSection topSection;
    internal static readonly List<SettingsHelper.NumberInputSetting> stockpileSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> stockpileTransporterSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> housingSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> cellHousingSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> batteriesSettings = [];
    internal static List<SettingsHelper.NumberInputSetting> miscellaneousSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> algaeFarmSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> insectFarmSettings = [];
    internal static SettingsHelper.NumberInputSetting insectFarmAmountSetting;
    internal static readonly List<SettingsHelper.NumberInputSetting> factoryCostSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> factoryResultSettings = [];

    internal static readonly List<KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>>
        scienceLabSettings = [];
    internal static readonly List<KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>> cropsFarmSettings = [];

    internal static void init()
    {
        reset();
        SettingsHelper.addTopSection(topSection);
        stockpileCapacity();
        stockpileTransporters();
        housing();
        batteries();
        scienceLab();
        foodProduction();
        factories();
        miscellaneous();
    }

    private static void reset()
    {
        topSection = new SettingsHelper.SettingsSection(Plugin.Name);
        stockpileSettings.Clear();
        stockpileTransporterSettings.Clear();
        housingSettings.Clear();
        cellHousingSettings.Clear();
        batteriesSettings.Clear();
        miscellaneousSettings.Clear();
        algaeFarmSettings.Clear();
        insectFarmSettings.Clear();
        scienceLabSettings.Clear();
        cropsFarmSettings.Clear();
        factoryCostSettings.Clear();
        factoryResultSettings.Clear();
    }

    private static void stockpileCapacity()
    {
        var sec = new SettingsHelper.SettingsSection("Stockpile Capacity");
        topSection.addItem(sec);
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Small Stockpile Tier 1 Capacity", "Capacity of Small Stockpile with no upgrades",
            100, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Small Stockpile Tier 2 Capacity", "Capacity of Small Stockpile with 10% storage increase",
            110, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Small Stockpile Tier 3 Capacity", "Capacity of Small Stockpile with 20% storage increase",
            120, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Medium Stockpile Tier 1 Capacity",
            "Capacity of Medium Stockpile with no upgrades", 300, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Medium Stockpile Tier 2 Capacity",
            "Capacity of Medium Stockpile with 10% storage increase", 330, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Medium Stockpile Tier 3 Capacity",
            "Capacity of Medium Stockpile with 20% storage increase", 360, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Large Stockpile Tier 1 Capacity", "Capacity of Large Stockpile with no upgrades",
            600, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Large Stockpile Tier 2 Capacity", "Capacity of Large Stockpile with 10% storage increase",
            660, true));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting("Large Stockpile Tier 3 Capacity", "Capacity of Large Stockpile with 20% storage increase",
            720, true));
        
        sec.addItem(stockpileSettings);
    }

    private static void stockpileTransporters()
    {
        var sec = new SettingsHelper.SettingsSection("Stockpile Transporters");
        topSection.addItem(sec);
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Small Stockpile Tier 1 Transporter", "Transporter amount of Small Stockpile with no upgrade", 5, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Small Stockpile Tier 2 Transporter", "Transporter amount of Small Stockpile with +1 upgrade", 6, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Small Stockpile Tier 3 Transporter", "Transporter amount of Small Stockpile with +2 upgrade", 7, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Medium Stockpile Tier 1 Transporter", "Transporter amount of Medium Stockpile with no upgrade", 8, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Medium Stockpile Tier 2 Transporter", "Transporter amount of Medium Stockpile with +1 upgrade", 9, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Medium Stockpile Tier 3 Transporter", "Transporter amount of Medium Stockpile with +2 upgrade", 10, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Large Stockpile Tier 1 Transporter", "Transporter amount of Large Stockpile with no upgrade", 12, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Large Stockpile Tier 2 Transporter", "Transporter amount of Large Stockpile with +1 upgrade", 13, true));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting("Large Stockpile Tier 3 Transporter", "Transporter amount of Large Stockpile with +2 upgrade", 14, true));
        
        sec.addItem(stockpileTransporterSettings);
    }

    private static void housing()
    {
        var sec = new SettingsHelper.SettingsSection("Housing");
        topSection.addItem(sec);
        housingSettings.Add(
            new SettingsHelper.NumberInputSetting("Crew Quarters Tier 1 Capacity", "Capacity of Crew Quarters with no upgrades", 15, true));
        housingSettings.Add(
            new SettingsHelper.NumberInputSetting("Crew Quarters Tier 2 Capacity", "Capacity of Crew Quarters with 30% increase", 20, true));
        housingSettings.Add(
            new SettingsHelper.NumberInputSetting("Crew Quarters Tier 3 Capacity", "Capacity of Crew Quarters with 60% increase", 24, true));
        housingSettings.Add(new SettingsHelper.NumberInputSetting("Optimized Quarters Tier 1 Capacity",
            "Capacity of Optimized Quarters with no upgrades", 40, true));
        housingSettings.Add(new SettingsHelper.NumberInputSetting("Optimized Quarters Tier 2 Capacity",
            "Capacity of Optimized Quarters with 30% increase", 52, true));
        housingSettings.Add(new SettingsHelper.NumberInputSetting("Optimized Quarters Tier 3 Capacity",
            "Capacity of Optimized Quarters with 60% increase", 64, true));
        housingSettings.Add(new SettingsHelper.NumberInputSetting("Domotic Quarters Tier 1 Capacity", "Capacity of Domotic Quarters with no upgrades",
            70, true));
        housingSettings.Add(new SettingsHelper.NumberInputSetting("Domotic Quarters Tier 2 Capacity", "Capacity of Domotic Quarters with 30% increase",
            91, true));
        housingSettings.Add(new SettingsHelper.NumberInputSetting("Domotic Quarters Tier 3 Capacity", "Capacity of Domotic Quarters with 60% increase",
            112, true));
        cellHousingSettings.Add(new SettingsHelper.NumberInputSetting("Cell Housing Tier 1 Capacity",
            "Capacity of Cell Housing with no upgrades", 125, true));
        cellHousingSettings.Add(new SettingsHelper.NumberInputSetting("Cell Housing Tier 2 Capacity",
            "Capacity of Cell Housing with 30% increase", 162, true));
        cellHousingSettings.Add(new SettingsHelper.NumberInputSetting("Cell Housing Tier 3 Capacity",
            "Capacity of Cell Housing with 60% increase", 200, true));
        
        sec.addItem(housingSettings);
        sec.addItem(cellHousingSettings);
    }

    private static void batteries()
    {
        var sec = new SettingsHelper.SettingsSection("Batteries");
        topSection.addItem(sec);
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 1 Battery Stage 1 Capacity", "Capacity of Battery - Tier 1 with no upgrades",
            100, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 1 Battery Stage 2 Capacity", "Capacity of Battery - Tier 1 with 10% capacity increase",
            110, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 1 Battery Stage 3 Capacity", "Capacity of Battery - Tier 1 with 20% capacity increase",
            120, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 2 Battery Stage 1 Capacity", "Capacity of Battery - Tier 2 with no upgrades",
            300, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 2 Battery Stage 2 Capacity", "Capacity of Battery - Tier 2 with 10% capacity increase",
            330, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 2 Battery Stage 3 Capacity", "Capacity of Battery - Tier 2 with 20% capacity increase",
            360, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 3 Battery Stage 1 Capacity", "Capacity of Battery - Tier 3 with no upgrades",
            700, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 3 Battery Stage 2 Capacity", "Capacity of Battery - Tier 3 with 10% capacity increase",
            770, true));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting("Tier 3 Battery Stage 3 Capacity", "Capacity of Battery - Tier 3 with 20% capacity increase",
            840, true));
        
        sec.addItem(batteriesSettings);
    }

    private static void scienceLab()
    {
        const string description = "Amount of science produced by the team";
        const string descriptionCycle = "Number of cycles it takes the team to produce science";
        var sec = new SettingsHelper.SettingsSection("Science Lab");
        topSection.addItem(sec);
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting("Tier 1 Team Science Amount", description, 1, true),
            new SettingsHelper.NumberInputSetting("Tier 1 Team Cycles Amount", descriptionCycle, 30, true)));
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting("Tier 2 Team Science Amount", description, 3, true),
            new SettingsHelper.NumberInputSetting("Tier 2 Team Cycles Amount", descriptionCycle, 5, true)));
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting("Tier 3 Team Science Amount", description, 5, true),
            new SettingsHelper.NumberInputSetting("Tier 3 Team Cycles Amount", descriptionCycle, 5, true)));
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting("Tier 4 Team Science Amount", description, 5, true),
            new SettingsHelper.NumberInputSetting("Tier 4 Team Cycles Amount", descriptionCycle, 3, true)));
        foreach (var s in scienceLabSettings)
        {
            sec.addItem(s.Key);
            sec.addItem(s.Value);
        }
    }

    private static void foodProduction()
    {
        var sec = new SettingsHelper.SettingsSection("Food Production");
        topSection.addItem(sec);
        const string descriptionDuration = "Number of cycles between harvests";
        const string descriptionFood = "Amount of food produced per field (not farm) per cycle";
        for (var i = 1; i < 6; i++)
        {
            cropsFarmSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
                new SettingsHelper.NumberInputSetting("Crop Farm Tier " + i + " Grow Duration", descriptionDuration, (float) Math.Round(600f / float.Parse("1," + (i - 1)) / 60f, 1), true),
                new SettingsHelper.NumberInputSetting("Crop Farm Tier " + i + " Food per Cycle", descriptionFood, (float) Math.Round(1.2f * float.Parse("1," + (i - 1)), 2), true)));
        }
        
        for (var i = 1; i < 6; i++)
        {
            cropsFarmSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
                new SettingsHelper.NumberInputSetting("Algae Farm Tier " + i + " Grow Duration", descriptionDuration, (float) Math.Round(300f / float.Parse("1," + (i - 1)) / 60f, 1), true),
                new SettingsHelper.NumberInputSetting("Algae Farm Tier " + i + " Food per Cycle", descriptionFood, (float) Math.Round(3.6f * float.Parse("1," + (i - 1)), 2), true)));
        }

        for (var i = 4; i < 7; i++)
        {
            algaeFarmSettings.Add(new SettingsHelper.NumberInputSetting("Algae Farm Tier " + (i - 3) + " Plantation Amount", "Max amount of plantations/fields for algae farms", i, true));
        }
        for (var i = 0; i < 3; i++)
        {
            insectFarmSettings.Add(new SettingsHelper.NumberInputSetting("Insect Farm Tier " + (i + 1) + " Growth Duration", descriptionDuration, 1.0f - i * 0.1f, true));
        }

        insectFarmAmountSetting = new SettingsHelper.NumberInputSetting("Insect Farm Produced Amount","Amount of food produced", 1, true);
        
        foreach (var s in cropsFarmSettings)
        {
            sec.addItem(s.Key);
            sec.addItem(s.Value);
        }
        sec.addItem(algaeFarmSettings);
        sec.addItem(insectFarmSettings);
        sec.addItem(insectFarmAmountSetting);
    }

    private static void factories()
    {
        var sec = new SettingsHelper.SettingsSection("Factories");
        topSection.addItem(sec);
        const string descriptionCostSteel = "Amount of iron required for production";
        const string descriptionCostElectronics = "Amount of silicon required for production";
        const string descriptionCostPolymer = "Amount of carbon required for production";
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Steel Mill Cost Tier 1", descriptionCostSteel, 15, true));
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Steel Mill Cost Tier 2", descriptionCostSteel, 13, true));
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Steel Mill Cost Tier 3", descriptionCostSteel, 10, true));
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Electronics Factory Cost Tier 1", descriptionCostElectronics, 30, true));
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Electronics Factory Cost Tier 2", descriptionCostElectronics, 25, true));
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Electronics Factory Cost Tier 3", descriptionCostElectronics, 20, true));
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Polymer Refinery Cost Tier 1", descriptionCostPolymer, 5, true));
        factoryCostSettings.Add(new SettingsHelper.NumberInputSetting("Polymer Refinery Cost Tier 2", descriptionCostPolymer, 4, true));
        
        factoryResultSettings.Add(new SettingsHelper.NumberInputSetting("Steel Mill Produced Amount", "Amount of alloy produced", 15, true));
        factoryResultSettings.Add(new SettingsHelper.NumberInputSetting("Electronics Factory Produced Amount", "Amount of electronics produced", 1, true));
        factoryResultSettings.Add(new SettingsHelper.NumberInputSetting("Polymer Refinery Produced Amount","Amount of polymer produced", 5, true));
        
        foreach (var s in factoryCostSettings)
        {
            sec.addItem(s);
        }
        foreach (var s in factoryResultSettings)
        {
            sec.addItem(s);
        }
    }

    private static void miscellaneous()
    {
        miscellaneousSettings = [];
        var sec = new SettingsHelper.SettingsSection("Miscellaneous");
        topSection.addItem(sec);
        miscellaneousSettings.Add(new SettingsHelper.NumberInputSetting("Probe Scan Range", "Size of scanned area around the probe\n(resource estimates might be inaccurate at higher values)", 5, true));
        
        sec.addItem(miscellaneousSettings);
    }
}