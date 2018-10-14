using System.Collections.Generic;
using System.Runtime.Serialization;
using Todo.Data.TaskList;

/// <summary>
/// 
/// </summary>
namespace Todo.Messages.Responses.TaskList
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TaskListResponse : ApiResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskList"></param>
        public TaskListResponse(IReadOnlyCollection<KnownTask> taskList) : base(ResponseStatus.Success)
        {
            TaskList = taskList;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name ="taskList")]
        public IReadOnlyCollection<KnownTask> TaskList { get; }
    }
}
