using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Todo.Data.TaskList
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class KnownTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="details"></param>
        /// <param name="status"></param>
        [JsonConstructor]
        public KnownTask(string details, bool status)
        {
            Details = details;
            Status = status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="details"></param>
        /// <param name="status"></param>
        public KnownTask(int taskId, string details, bool status)
        {
            TaskId = taskId;
            Details = details;
            Status = status;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name ="taskId")]
        public int TaskId { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "details")]
        public string Details { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status")]
        public bool Status { get; }
    }
}