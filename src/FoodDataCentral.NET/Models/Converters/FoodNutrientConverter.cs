using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FoodDataCentral.Models.Converters
{
    /// <summary>
    /// Converts an array of nutrients to a dictionary with nutrient's ID as the key
    /// </summary>
    class FoodNutrientConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, FoodNutrient>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dict = new Dictionary<NutrientType, FoodNutrient>();
            var jArray = JArray.Load(reader);

            foreach (var nutrient in jArray)
            {
                NutrientType id = (NutrientType)(int)nutrient["nutrient"]["id"];
                dict.Add(id, nutrient.ToObject<FoodNutrient>());
            }

            return dict;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
