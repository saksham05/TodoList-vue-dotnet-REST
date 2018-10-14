using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

/// <summary>
/// 
/// </summary>
namespace Todo.Messages.Responses
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResponseStatus
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "Success")]
        Success,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "Failure")]
        Failure,
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public abstract class ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        protected ApiResponse(ResponseStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status")]
        public ResponseStatus Status { get; }
    }
}
