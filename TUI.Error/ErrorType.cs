using System.Runtime.Serialization;
using TUI.Error.Helpers;
using Newtonsoft.Json;

namespace TUI.Error
{
    [JsonConverter(typeof(StringEnumConverterHelper))]
    public enum ErrorType
    {
        [EnumMember(Value = "network_error")]
        NetworkError = 0,
        [EnumMember(Value = "invalid_parameter")]
        InvalidParameter = 1,
        [EnumMember(Value = "unauthorized_action")]
        UnauthorizedAction = 2,
        [EnumMember(Value = "not_found")]
        NotFound = 3,
        [EnumMember(Value = "forbidden")]
        Forbidden = 4,

        [EnumMember(Value = "aircraft_already_flying")]
        AircraftAlreadyFlying = 100,
    }
}