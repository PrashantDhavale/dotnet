using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PeopleWithPets.Domain.Enums
{
    /// <summary>
    /// Enum for Pet type
    /// Decorated for handling json to return string enums instead of number values
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PetType
    {
        Cat = 0,
        Dog = 1,
        Fish = 2
    }
}