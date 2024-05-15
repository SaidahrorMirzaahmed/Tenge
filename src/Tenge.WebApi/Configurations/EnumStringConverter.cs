﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tenge.Service.Configurations;

public class EnumStringConverter : StringEnumConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }
}