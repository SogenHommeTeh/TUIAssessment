using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TUI.Error.Helpers
{
    public class StringEnumConverterHelper : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.ValueType != typeof(string) &&
                    Nullable.GetUnderlyingType(objectType) == null &&
                    !Enum.IsDefined(objectType, Convert.ToInt32(reader.Value))) return 0;
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return 0;
            }
        }
    }
}
