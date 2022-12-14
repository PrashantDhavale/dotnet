using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PeopleWithPets.Domain.Enums
{
    /// <summary>
    /// Enum for Persons gender
    /// Decorated for handling json to return string enums instead of number values
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PersonGender
    {
        Female = 0,
        Male = 1
    }
}