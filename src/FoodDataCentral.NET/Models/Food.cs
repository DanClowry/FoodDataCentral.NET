using FoodDataCentral.Models.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoodDataCentral.Models
{
    public class Food
    {
        public string FoodClass { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(FoodNutrientConverter))]
        public Dictionary<NutrientType, FoodNutrient> FoodNutrients { get; set; }
        public FoodComponent[] FoodComponents { get; set; }
        public FoodAttribute[] FoodAttributes { get; set; }
        public string TableAliasName { get; set; }
        public NutrientConversionFactor[] NutrientConversionFactors { get; set; }
        public bool IsHistoricalReference { get; set; }
        public int NdbNumber { get; set; }
        public int FdcId { get; set; }
        public string DataType { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public FoodPortion[] FoodPortions { get; set; }
        public InputFoodOuter[] InputFoods { get; set; }
        public string Changes { get; set; }
        public DateTime PublicationDate { get; set; }
    }

    public class FoodCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class FoodNutrient
    {
        public string Type { get; set; }
        public Nutrient Nutrient { get; set; }
        public int Id { get; set; }
        public int DataPoints { get; set; }
        public FoodNutrientDerivation FoodNutrientDerivation { get; set; }
        public float Amount { get; set; }
    }

    public class Nutrient
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public string UnitName { get; set; }
    }

    public class FoodNutrientDerivation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public FoodNutrientSource FoodNutrientSource { get; set; }
    }

    public class FoodNutrientSource
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class FoodComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PercentWeight { get; set; }
        public float GramWeight { get; set; }
        public int DataPoints { get; set; }
        public bool IsRefuse { get; set; }
    }

    public class FoodAttribute
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public FoodAttributeType FoodAttributeType { get; set; }
        public int SequenceNumber { get; set; }
    }

    public class FoodAttributeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class NutrientConversionFactor
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public float ProteinValue { get; set; }
        public float FatValue { get; set; }
        public float CarbohydrateValue { get; set; }
    }

    public class FoodPortion
    {
        public int Id { get; set; }
        public Measureunit MeasureUnit { get; set; }
        public string Modifier { get; set; }
        public float GramWeight { get; set; }
        public float Amount { get; set; }
        public int SequenceNumber { get; set; }
    }

    public class Measureunit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class InputFoodOuter
    {
        public int Id { get; set; }
        public string FoodDescription { get; set; }
        public InputFood InputFood { get; set; }
    }

    public class InputFood
    {
        public string FoodClass { get; set; }
        public string Description { get; set; }
        public string TableAliasName { get; set; }
        public int FdcId { get; set; }
        public string DataType { get; set; }
        public DateTime PublicationDate { get; set; }
        public FoodCategory FoodCategory { get; set; }
    }

    public enum NutrientType
    {
        Nitrogen = 1002,
        Protein = 1003,
        Lipid = 1004,
        CarbohydrateByDifference = 1005,
        Ash = 1007,
        EnergyKcal = 1008,
        Starch = 1009,
        Sucrose = 1010,
        Glucose = 1011,
        Fructose = 1012,
        Lactose = 1013,
        Maltose = 1014,
        AlcoholEthyl = 1018,
        SpecificGravity = 1024,
        AceticAcid = 1026,
        LacticAcid = 1038,
        CarbohydrateBySummation = 1050,
        Water = 1051,
        Sorbitol = 1056,
        Caffeine = 1057,
        Theobromine = 1058,
        EnergykJ = 1062,
        SugarsTotalNLEA = 1063,
        CarbohydrateOther = 1072,
        Galactose = 1075,
        Xylitol = 1078,
        FiberTotalDietary = 1079,
        Ribose = 1081,
        FiberSoluble = 1082,
        FiberInsoluble = 1084,
        TotalFatNLEA = 1085,
        TotalSugarAlcohols = 1086,
        Calcium = 1087,
        Chlorine = 1088,
        Iron = 1089,
        Magnesium = 1090,
        Phosphorus = 1091,
        Potassium = 1092,
        Sodium = 1093,
        Sulfur = 1094,
        Zinc = 1095,
        Chromium = 1096,
        Cobalt = 1097,
        Copper = 1098,
        Fluoride = 1099,
        Iodine = 1100,
        Manganese = 1101,
        Molybdenum = 1102,
        Selenium = 1103,
        VitaminAIU = 1104,
        Retinol = 1105,
        VitaminARAE = 1106,
        CaroteneBeta = 1107,
        CaroteneAlpha = 1108,
        VitaminEAlphatocopherol = 1109,
        VitaminD = 1110,
        VitaminD2 = 1111,
        VitaminD3 = 1112,
        Calcifediol = 1113,
        VitaminD2D3 = 1114,
        Phytoene = 1116,
        Phytofluene = 1117,
        Zeaxanthin = 1119,
        CryptoxanthinBeta = 1120,
        Lutein = 1121,
        Lycopene = 1122,
        LuteinZeaxanthin = 1123,
        VitaminELabelEntry = 1124,
        TocopherolBeta = 1125,
        TocopherolGamma = 1126,
        TocopherolDelta = 1127,
        TocotrienolAlpha = 1128,
        TocotrienolBeta = 1129,
        TocotrienolGamma = 1130,
        TocotrienolDelta = 1131,
        Boron = 1137,
        Nickel = 1146,
        VitaminE = 1158,
        CisBetaCarotene = 1159,
        CisLycopene = 1160,
        CisLuteinZeaxanthin = 1161,
        VitaminCTotalAscorbicAcid = 1162,
        Thiamin = 1165,
        Riboflavin = 1166,
        Niacin = 1167,
        PantothenicAcid = 1170,
        VitaminB6 = 1175,
        Biotin = 1176,
        FolateTotal = 1177,
        VitaminB12 = 1178,
        CholineTotal = 1180,
        Inositol = 1181,
        Menaquinone4 = 1183,
        Dihydrophylloquinone = 1184,
        VitaminK1 = 1185,
        FolicAcid = 1186,
        FolateFood = 1187,
        FiveMethyltetrahydrofolate = 1188,
        FolateDFE = 1190,
        TenFormylFolicAcid = 1191,
        FiveFormyltetrahydrofolicAcid = 1192,
        CholineFree = 1194,
        CholinePhosphocholine = 1195,
        CholinePhosphotidylcholine = 1196,
        CholineGlycerophosphocholine = 1197,
        Betaine = 1198,
        CholineFromSphingomyelin = 1199,
        Tryptophan = 1210,
        Threonine = 1211,
        Isoleucine = 1212,
        Leucine = 1213,
        Lysine = 1214,
        Methionine = 1215,
        Cystine = 1216,
        Phenylalanine = 1217,
        Tyrosine = 1218,
        Valine = 1219,
        Arginine = 1220,
        Histidine = 1221,
        Alanine = 1222,
        AsparticAcid = 1223,
        GlutamicAcid = 1224,
        Glycine = 1225,
        Proline = 1226,
        Serine = 1227,
        Hydroxyproline = 1228,
        Cysteine = 1232,
        Glutamine = 1233,
        Taurine = 1234,
        SugarsAdded = 1235,
        VitaminEAdded = 1242,
        VitaminB12Added = 1246,
        Cholesterol = 1253,
        FattyAcidsTotalTrans = 1257,
        FattyAcidsTotalSaturated = 1258,

        // Lipid numbers
        /// <summary>
        /// C4:0 Butanoic acid
        /// </summary>
        C4 = 1259,
        /// <summary>
        /// C6:0 Hexanoic acid
        /// </summary>
        C6 = 1260,
        /// <summary>
        /// C8:0 Octanoic acid
        /// </summary>
        C8 = 1261,
        /// <summary>
        /// C10:0 Decanoic acid
        /// </summary>
        C10 = 1262,
        /// <summary>
        /// C12:0 Dodecanoic acid
        /// </summary>
        C12 = 1263,
        /// <summary>
        /// C14:0 Tetradecanoic acid
        /// </summary>
        C14 = 1264,
        /// <summary>
        /// C16:0 Hexadecanoic acid
        /// </summary>
        C16 = 1265,
        /// <summary>
        /// C18:0 Octadecanoic acid
        /// </summary>
        C18 = 1266,
        /// <summary>
        /// C20:0 Eicosanoic acid
        /// </summary>
        C20 = 1267,
        /// <summary>
        /// C18:1
        /// </summary>
        C18_1 = 1268,
        /// <summary>
        /// C18:2
        /// </summary>
        C18_2 = 1269,
        /// <summary>
        /// C18:3
        /// </summary>
        C18_3 = 1270,
        /// <summary>
        /// C20:4
        /// </summary>
        C20_4 = 1271,
        /// <summary>
        /// C22:6(n-3) Docosahexaenoic acid
        /// </summary>
        C22_6n_3 = 1272,
        /// <summary>
        /// C22:0
        /// </summary>
        C22 = 1273,
        /// <summary>
        /// C14:1
        /// </summary>
        C14_1 = 1274,
        /// <summary>
        /// C16:1
        /// </summary>
        C16_1 = 1275,
        /// <summary>
        /// C18:4
        /// </summary>
        C18_4 = 1276,
        /// <summary>
        /// C20:1
        /// </summary>
        C20_1 = 1277,
        /// <summary>
        /// C20:5(n-3) Eicosapentaenoic acid
        /// </summary>
        C20_5n_3 = 1278,
        /// <summary>
        /// C22:1
        /// </summary>
        C22_1 = 1279,
        /// <summary>
        /// C22:5(n-3) Docosapentaenoic acid
        /// </summary>
        C22_5n_3 = 1280,
        /// <summary>
        /// C14:1 t
        /// </summary>
        C14_1t = 1281,
        Phytosterols = 1283,
        Stigmasterol = 1285,
        Campesterol = 1286,
        BetaSitosterol = 1288,
        FattyAcidsTotalMonounsaturated = 1292,
        FattyAcidsTotalPolyunsaturated = 1293,
        /// <summary>
        /// C15:0 Pentadecanoic acid
        /// </summary>
        C15 = 1299,
        /// <summary>
        /// C17:0 Heptadecanoic acid
        /// </summary>
        C17 = 1300,
        /// <summary>
        /// C24:0 Tetracosanoic acid
        /// </summary>
        C24 = 1301,
        /// <summary>
        /// C16:1 t
        /// </summary>
        C16_1t = 1303,
        /// <summary>
        /// C18:1 t
        /// </summary>
        C18_1t = 1304,
        /// <summary>
        /// C22:1 t
        /// </summary>
        C22_1t = 1305,
        /// <summary>
        /// C18:2 t not further defined
        /// </summary>
        C18_2tNotFurtherDefined = 1306,
        /// <summary>
        /// C18:2 i
        /// </summary>
        C18_2i = 1307,
        /// <summary>
        /// C18:2 t,t
        /// </summary>
        C18_2t_t = 1310,
        /// <summary>
        /// C18:2 CLAs
        /// </summary>
        C18_2CLAs = 1311,
        /// <summary>
        /// C24:1 c
        /// </summary>
        C24_1c = 1312,
        /// <summary>
        /// C20:2(n-6) c,c
        /// </summary>
        C20_2n_6c_c = 1313,
        /// <summary>
        /// C16:1 c
        /// </summary>
        C16_1c = 1314,
        /// <summary>
        /// C18:1 c
        /// </summary>
        C18_1c = 1315,
        /// <summary>
        /// C18:2(n-6) c,c
        /// </summary>
        C18_2n_6c_c = 1316,
        /// <summary>
        /// C22:1 c
        /// </summary>
        C22_1c = 1317,
        /// <summary>
        /// C18:3(n-6) c,c,c
        /// </summary>
        C18_3n_6c_c_c = 1321,
        /// <summary>
        /// C17:1
        /// </summary>
        C17_1 = 1323,
        /// <summary>
        /// C20:3
        /// </summary>
        C20_3 = 1325,
        FattyAcidsTotalTransmonoenoic = 1329,
        FattyAcidsTotalTransdienoic = 1330,
        FattyAcidsTotalTranspolyenoic = 1331,
        /// <summary>
        /// C13:0 Tridecanoic acid
        /// </summary>
        C13 = 1332,
        /// <summary>
        /// C15:1
        /// </summary>
        C15_1 = 1333,
        /// <summary>
        /// C22:2
        /// </summary>
        C22_2 = 1334,
        /// <summary>
        /// C11:0 Undecanoic acid
        /// </summary>
        C11 = 1335,
        Epigallocatechin3Gallate = 1368,
        Inulin = 1403,
        /// <summary>
        /// C18:3(n-3) c,c,c (ALA)
        /// </summary>
        C18_3n_3c_c_c = 1404,
        /// <summary>
        /// C20:3(n-3)
        /// </summary>
        C20_3n_3 = 1405,
        /// <summary>
        /// C20:3(n-6)
        /// </summary>
        C20_3n_6 = 1406,
        /// <summary>
        /// C20:4(n-6)
        /// </summary>
        C20_4n_6 = 1408,
        /// <summary>
        /// C18:3 i
        /// </summary>
        C18_3i = 1409,
        /// <summary>
        /// C21:5
        /// </summary>
        C21_5 = 1410,
        /// <summary>
        /// C22:4
        /// </summary>
        C22_4 = 1411,
        /// <summary>
        /// 18:1-11 t (18:1t n-7)
        /// </summary>
        C18_1_11t = 1412,
        /// <summary>
        /// C20:3(n-9)
        /// </summary>
        C20_3n_9 = 1414,
        SugarsTotalIncludingNLEA = 2000,
        /// <summary>
        /// C5:0 Pentanoic acid
        /// </summary>
        C5 = 2003,
        /// <summary>
        /// C7:0 Heptanoic acid
        /// </summary>
        C7 = 2004,
        /// <summary>
        /// C9:0 Nonanoic acid
        /// </summary>
        C9 = 2005,
        /// <summary>
        /// C21:0 Heneicosanoic acid
        /// </summary>
        C21 = 2006,
        /// <summary>
        /// C23:0 Tricosanoic acid
        /// </summary>
        C23 = 2007,
        /// <summary>
        /// C12:1
        /// </summary>
        C12_1 = 2008,
        /// <summary>
        /// C14:1 c
        /// </summary>
        C14_1c = 2009,
        /// <summary>
        /// C17:1 c
        /// </summary>
        C17_1c = 2010,
        /// <summary>
        /// C20:1 c
        /// </summary>
        C20_1c = 2012,
        /// <summary>
        /// C20:1 t
        /// </summary>
        C20_1t = 2013,
        /// <summary>
        /// C22:1(n-9)
        /// </summary>
        C22_1n_9 = 2014,
        /// <summary>
        /// C22:1(n-11)
        /// </summary>
        C22_1n_11 = 2015,
        /// <summary>
        /// C18:2 c
        /// </summary>
        C18_2c = 2016,
        /// <summary>
        /// C18:3 c
        /// </summary>
        C18_3c = 2018,
        /// <summary>
        /// C18:3 t
        /// </summary>
        C18_3t = 2019,
        /// <summary>
        /// C20:3 c
        /// </summary>
        C20_3c = 2020,
        /// <summary>
        /// C22:3
        /// </summary>
        C22_3 = 2021,
        /// <summary>
        /// C20:4 c
        /// </summary>
        C20_4c = 2022,
        /// <summary>
        /// C20:5 c
        /// </summary>
        C20_5c = 2023,
        /// <summary>
        /// C22:5 c
        /// </summary>
        C22_5c = 2024,
        /// <summary>
        /// C22:6 c
        /// </summary>
        C22_6c = 2025,
        /// <summary>
        /// C20:2 c
        /// </summary>
        C20_2c = 2026,
        TransBetaCarotene = 2028,
        TransLycopene = 2029,
        CryptoxanthinAlpha = 2032
    }
}
