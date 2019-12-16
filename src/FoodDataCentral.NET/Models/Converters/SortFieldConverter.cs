using Newtonsoft.Json;
using System;

namespace FoodDataCentral.Models.Converters
{
    internal class SortFieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            switch (enumString)
            {
                case "lowercaseDescription.keyword":
                    return SortField.LowercaseDescription;
                case "dataType.keyword":
                    return SortField.DataType;
                case "publishedDate":
                    return SortField.PublishedDate;
                case "fdcId":
                    return SortField.FdcId;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            SortField sortType = (SortField)value;

            switch (sortType)
            {
                case SortField.LowercaseDescription:
                    writer.WriteValue("lowercaseDescription.keyword");
                    break;
                case SortField.DataType:
                    writer.WriteValue("dataType.keyword");
                    break;
                case SortField.PublishedDate:
                    writer.WriteValue("publishedDate");
                    break;
                case SortField.FdcId:
                    writer.WriteValue("fdcId");
                    break;
                default:
                    writer.WriteValue("");
                    break;
            }
        }
    }
}
