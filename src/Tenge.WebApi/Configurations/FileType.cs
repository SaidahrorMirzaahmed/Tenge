using System.Text.Json.Serialization;

namespace Tenge.Service.Configurations;

[JsonConverter(typeof(EnumStringConverter))]
public enum FileType
{
    Pictures = 1,
    Videos
}
