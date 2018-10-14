using System.Collections.Immutable;
using Todo.Data.TaskList;

namespace Todo.Providers.TaskList.Interface
{
    /// <summary>
    /// 
    /// </summary>
	public interface ITaskListProvider
    {
		/// <summary>
        /// Create new task in the list
        /// </summary>
        /// <param name="newtask"></param>
        /// <returns></returns>
        int CreateTask(KnownTask newtask);

		/// <summary>
        /// Get the list of all the tasks
        /// </summary>
        /// <returns></returns>
        ImmutableList<KnownTask> GetAllTasksList();

		/// <summary>
        /// Delete the tasks from the database
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        bool DeleteTask(int taskId);

		/// <summary>
        /// Update the status from pending to done or done to pending
        /// Pending means true
        /// Done means false
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        bool UpdateTaskStatus(int taskId);
    }
}