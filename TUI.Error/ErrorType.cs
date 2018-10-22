using System.Runtime.Serialization;
using TUI.Error.Helpers;
using Newtonsoft.Json;

namespace TUI.Error
{
    [JsonConverter(typeof(StringEnumConverterHelper))]
    public enum ErrorType
    {
        None = 0,

        [EnumMember(Value = "network_error")]
        NetworkError = 50,
        [EnumMember(Value = "invalid_parameter")]
        InvalidParameter = 51,
        [EnumMember(Value = "unauthorized_action")]
        UnauthorizedAction = 52,
        [EnumMember(Value = "not_found")]
        NotFound = 53,
        [EnumMember(Value = "forbidden")]
        Forbidden = 54,

        [EnumMember(Value = "aircraft_already_flying")]
        AircraftAlreadyFlying = 100,
    }
}