using System.Runtime.Serialization;

namespace Todo.Messages.Responses.TaskList
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TaskIdResponse : ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        public TaskIdResponse(int taskId) : base(ResponseStatus.Success)
        {
            TaskId = taskId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        protected TaskIdResponse(ResponseStatus status) : base(status)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int TaskId { get; }
    }
}
