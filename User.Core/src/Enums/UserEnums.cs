using System.Text.Json.Serialization;

namespace User.Core.src.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Scholarity
    {
        Infantil,
        Fundamental,
        Médio,
        Superior
    }
}