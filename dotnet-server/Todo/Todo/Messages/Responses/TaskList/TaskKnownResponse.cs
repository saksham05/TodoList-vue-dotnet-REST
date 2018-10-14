using System.Runtime.Serialization;
using Todo.Data.TaskList;

namespace Todo.Messages.Responses.TaskList
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TaskKnownResponse : ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        public TaskKnownResponse(KnownTask knowntask) : base(ResponseStatus.Success)
        {
            KnownTask = knowntask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        protected TaskKnownResponse(ResponseStatus status) : base(status)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public KnownTask KnownTask { get; }
    }
}
