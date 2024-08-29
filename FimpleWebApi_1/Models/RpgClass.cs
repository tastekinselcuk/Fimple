using System.Text.Json.Serialization;

namespace FimpleWebApi_1.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,

        Mage = 2,

        Cleric = 3

    }
}