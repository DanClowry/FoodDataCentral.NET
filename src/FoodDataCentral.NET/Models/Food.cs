namespace FoodDataCentral.Models
{
    public class Food
    {
        public string foodClass { get; set; }
        public string description { get; set; }
        public Foodnutrient[] foodNutrients { get; set; }
        public Foodcomponent[] foodComponents { get; set; }
        public Foodattribute[] foodAttributes { get; set; }
        public string tableAliasName { get; set; }
        public Nutrientconversionfactor[] nutrientConversionFactors { get; set; }
        public bool isHistoricalReference { get; set; }
        public int ndbNumber { get; set; }
        public int fdcId { get; set; }
        public string dataType { get; set; }
        public Foodcategory foodCategory { get; set; }
        public Foodportion[] foodPortions { get; set; }
        public Inputfood[] inputFoods { get; set; }
        public string changes { get; set; }
        public string publicationDate { get; set; }
    }

    public class Foodcategory
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Foodnutrient
    {
        public string type { get; set; }
        public Nutrient nutrient { get; set; }
        public int id { get; set; }
        public int dataPoints { get; set; }
        public Foodnutrientderivation foodNutrientDerivation { get; set; }
        public float amount { get; set; }
    }

    public class Nutrient
    {
        public int id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public string unitName { get; set; }
    }

    public class Foodnutrientderivation
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public Foodnutrientsource foodNutrientSource { get; set; }
    }

    public class Foodnutrientsource
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Foodcomponent
    {
        public int id { get; set; }
        public string name { get; set; }
        public float percentWeight { get; set; }
        public float gramWeight { get; set; }
        public int dataPoints { get; set; }
        public bool isRefuse { get; set; }
    }

    public class Foodattribute
    {
        public int id { get; set; }
        public string value { get; set; }
        public Foodattributetype foodAttributeType { get; set; }
        public int sequenceNumber { get; set; }
    }

    public class Foodattributetype
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Nutrientconversionfactor
    {
        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public float proteinValue { get; set; }
        public float fatValue { get; set; }
        public float carbohydrateValue { get; set; }
    }

    public class Foodportion
    {
        public int id { get; set; }
        public Measureunit measureUnit { get; set; }
        public string modifier { get; set; }
        public float gramWeight { get; set; }
        public float amount { get; set; }
        public int sequenceNumber { get; set; }
    }

    public class Measureunit
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
    }

    public class Inputfood
    {
        public int id { get; set; }
        public string foodDescription { get; set; }
        public Inputfood1 inputFood { get; set; }
    }

    public class Inputfood1
    {
        public string foodClass { get; set; }
        public string description { get; set; }
        public string tableAliasName { get; set; }
        public int fdcId { get; set; }
        public string dataType { get; set; }
        public string publicationDate { get; set; }
        public Foodcategory1 foodCategory { get; set; }
    }

    public class Foodcategory1
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

}
