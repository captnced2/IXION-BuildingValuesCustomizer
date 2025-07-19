using System.Collections.Generic;
using IMHelper;

namespace BuildingValuesCustomizer;

public static class Buildings
{
    internal static readonly List<SettingsHelper.NumberInputSetting> stockpileSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> stockpileTransporterSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> housingSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> cellHousingSettings = [];
    internal static readonly List<SettingsHelper.NumberInputSetting> batteriesSettings = [];

    internal static readonly List<KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>>
        scienceLabSettings = [];

    internal static void init()
    {
        stockpileCapacity();
        stockpileTransporters();
        housing();
        batteries();
        scienceLab();
    }

    private static void stockpileCapacity()
    {
        var sec = new SettingsHelper.SettingsSection(Plugin.Name + " - Stockpile Capacity");
        Plugin.sections.Add(sec);
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Small Stockpile Tier 1 Capacity", "Capacity of Small Stockpile with no upgrades",
            100, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Small Stockpile Tier 2 Capacity", "Capacity of Small Stockpile with 10% storage increase",
            110, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Small Stockpile Tier 3 Capacity", "Capacity of Small Stockpile with 20% storage increase",
            120, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Medium Stockpile Tier 1 Capacity",
            "Capacity of Medium Stockpile with no upgrades", 300, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Medium Stockpile Tier 2 Capacity",
            "Capacity of Medium Stockpile with 10% storage increase", 330, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Medium Stockpile Tier 3 Capacity",
            "Capacity of Medium Stockpile with 20% storage increase", 360, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Large Stockpile Tier 1 Capacity", "Capacity of Large Stockpile with no upgrades",
            600, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Large Stockpile Tier 2 Capacity", "Capacity of Large Stockpile with 10% storage increase",
            660, false));
        stockpileSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Large Stockpile Tier 3 Capacity", "Capacity of Large Stockpile with 20% storage increase",
            720, false));
    }

    private static void stockpileTransporters()
    {
        var sec = new SettingsHelper.SettingsSection(Plugin.Name + " - Stockpile Transporters");
        Plugin.sections.Add(sec);
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Small Stockpile Tier 1 Transporter", "Transporter amount of Small Stockpile with no upgrade", 5, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Small Stockpile Tier 2 Transporter", "Transporter amount of Small Stockpile with +1 upgrade", 6, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Small Stockpile Tier 3 Transporter", "Transporter amount of Small Stockpile with +2 upgrade", 7, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Medium Stockpile Tier 1 Transporter", "Transporter amount of Small Stockpile with no upgrade", 8, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Medium Stockpile Tier 2 Transporter", "Transporter amount of Small Stockpile with +1 upgrade", 9, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Medium Stockpile Tier 3 Transporter", "Transporter amount of Small Stockpile with +2 upgrade", 10, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Large Stockpile Tier 1 Transporter", "Transporter amount of Small Stockpile with no upgrade", 12, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Large Stockpile Tier 2 Transporter", "Transporter amount of Small Stockpile with +1 upgrade", 13, false));
        stockpileTransporterSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Large Stockpile Tier 3 Transporter", "Transporter amount of Small Stockpile with +2 upgrade", 14, false));
    }

    private static void housing()
    {
        var sec = new SettingsHelper.SettingsSection(Plugin.Name + " - Housing");
        Plugin.sections.Add(sec);
        housingSettings.Add(
            new SettingsHelper.NumberInputSetting(sec, "Crew Quarters Tier 1 Capacity", "Capacity of Crew Quarters with no upgrades", 15, false));
        housingSettings.Add(
            new SettingsHelper.NumberInputSetting(sec, "Crew Quarters Tier 2 Capacity", "Capacity of Crew Quarters with 30% increase", 20, false));
        housingSettings.Add(
            new SettingsHelper.NumberInputSetting(sec, "Crew Quarters Tier 3 Capacity", "Capacity of Crew Quarters with 60% increase", 24, false));
        housingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Optimized Quarters Tier 1 Capacity",
            "Capacity of Optimized Quarters with no upgrades", 40, false));
        housingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Optimized Quarters Tier 2 Capacity",
            "Capacity of Optimized Quarters with 30% increase", 52, false));
        housingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Optimized Quarters Tier 3 Capacity",
            "Capacity of Optimized Quarters with 60% increase", 64, false));
        housingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Domotic Quarters Tier 1 Capacity", "Capacity of Domotic Quarters with no upgrades",
            70, false));
        housingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Domotic Quarters Tier 2 Capacity", "Capacity of Domotic Quarters with 30% increase",
            91, false));
        housingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Domotic Quarters Tier 3 Capacity", "Capacity of Domotic Quarters with 60% increase",
            112, false));
        cellHousingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Cell Housing Tier 1 Capacity",
            "Capacity of Cell Housing with no upgrades", 125, false));
        cellHousingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Cell Housing Tier 2 Capacity",
            "Capacity of Cell Housing with 30% increase", 162, false));
        cellHousingSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Cell Housing Tier 3 Capacity",
            "Capacity of Cell Housing with 60% increase", 200, false));
    }

    private static void batteries()
    {
        var sec = new SettingsHelper.SettingsSection(Plugin.Name + " - Batteries");
        Plugin.sections.Add(sec);
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 1 Battery Stage 1 Capacity", "Capacity of Battery - Tier 1 with no upgrades",
            100, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 1 Battery Stage 2 Capacity", "Capacity of Battery - Tier 1 with 10% capacity increase",
            110, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 1 Battery Stage 3 Capacity", "Capacity of Battery - Tier 1 with 20% capacity increase",
            120, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 2 Battery Stage 1 Capacity", "Capacity of Battery - Tier 2 with no upgrades",
            300, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 2 Battery Stage 2 Capacity", "Capacity of Battery - Tier 2 with 10% capacity increase",
            330, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 2 Battery Stage 3 Capacity", "Capacity of Battery - Tier 2 with 20% capacity increase",
            360, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 3 Battery Stage 1 Capacity", "Capacity of Battery - Tier 3 with no upgrades",
            700, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 3 Battery Stage 2 Capacity", "Capacity of Battery - Tier 3 with 10% capacity increase",
            770, false));
        batteriesSettings.Add(new SettingsHelper.NumberInputSetting(sec, "Tier 3 Battery Stage 3 Capacity", "Capacity of Battery - Tier 3 with 20% capacity increase",
            840, false));
    }

    private static void scienceLab()
    {
        const string description = "Changes the amount of science produced by the team";
        const string descriptionCycle = "Changes the amount of cycles it takes the team to produce science";
        var sec = new SettingsHelper.SettingsSection(Plugin.Name + " - Science Lab");
        Plugin.sections.Add(sec);
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting(sec, "Tier 1 Team Science Amount", description, 1, false),
            new SettingsHelper.NumberInputSetting(sec, "Tier 1 Team Cycles Amount", descriptionCycle, 30, false)));
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting(sec, "Tier 2 Team Science Amount", description, 3, false),
            new SettingsHelper.NumberInputSetting(sec, "Tier 2 Team Cycles Amount", descriptionCycle, 5, false)));
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting(sec, "Tier 3 Team Science Amount", description, 5, false),
            new SettingsHelper.NumberInputSetting(sec, "Tier 3 Team Cycles Amount", descriptionCycle, 5, false)));
        scienceLabSettings.Add(new KeyValuePair<SettingsHelper.NumberInputSetting, SettingsHelper.NumberInputSetting>(
            new SettingsHelper.NumberInputSetting(sec, "Tier 4 Team Science Amount", description, 5, false),
            new SettingsHelper.NumberInputSetting(sec, "Tier 4 Team Cycles Amount", descriptionCycle, 3, false)));
    }
}