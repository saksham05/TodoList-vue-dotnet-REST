using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Todo.Messages.Responses
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ErrorResponse : ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reason"></param>
        public ErrorResponse(string reason) : base(ResponseStatus.Failure)
        {
            Reason = reason;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reason")]
        public string Reason { get; }
    }
}
