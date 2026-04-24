using System.Collections.Generic;
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

    internal static readonly List<KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>>
        scienceLabSettings = [];

    internal static void init()
    {
        reset();
        SettingsHelper.addTopSection(topSection);
        stockpileCapacity();
        stockpileTransporters();
        housing();
        batteries();
        scienceLab();
    private static void reset()
    {
        topSection = new SettingsHelper.SettingsSection(Plugin.Name);
        stockpileSettings.Clear();
        stockpileTransporterSettings.Clear();
        housingSettings.Clear();
        cellHousingSettings.Clear();
        batteriesSettings.Clear();
        scienceLabSettings.Clear();
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
            new SettingsHelper.NumberInputSetting(sec, "Tier 4 Team Science Amount", description, 5, false),
            new SettingsHelper.NumberInputSetting(sec, "Tier 4 Team Cycles Amount", descriptionCycle, 3, false)));
            new SettingsHelper.NumberInputSetting("Tier 4 Team Science Amount", description, 5, true),
            new SettingsHelper.NumberInputSetting("Tier 4 Team Cycles Amount", descriptionCycle, 3, true)));
        foreach (var s in scienceLabSettings)
        {
            sec.addItem(s.Key);
            sec.addItem(s.Value);
    }
}