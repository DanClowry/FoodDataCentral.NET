using System;

namespace FoodDataCentral.Models
{
    public class Food
    {
        public string FoodClass { get; set; }
        public string Description { get; set; }
        public FoodNutrient[] FoodNutrients { get; set; }
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
}
