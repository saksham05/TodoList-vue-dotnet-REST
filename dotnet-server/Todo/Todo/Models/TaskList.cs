
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskList
    {
        /// <summary>
        /// The database id for the Task 
        /// </summary>
        [Key]
        public int TaskId { get; set; }
        
        /// <summary>
        /// Task details or description
        /// </summary>
        [Required]
        public string Details { get; set; }
        
        /// <summary>
        /// Status of task either pending (true) or done (false)
        /// </summary>
        [Required]
        public bool Status { get; set; }
    }
}