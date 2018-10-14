using Microsoft.EntityFrameworkCore;
using Todo.Models;
using System.Collections.Immutable;
using Todo.Data.TaskList;
using Todo.Providers.TaskList.Interface;
using System.Linq;
using System;

namespace Todo.Providers.TaskList.Database
{
    /// <summary>
    /// 
    /// </summary>
	public class DbTaskListProvider : ITaskListProvider
    {

		/// <summary>
        /// The database context option is use to construct a database connection
        /// </summary>
        private readonly DbContextOptions<TaskContext> _dbContextOptions;

		/// <summary>
        /// Contructs a database task list provider object
        /// </summary>
        /// <param name="dBContextOptions"></param>
        public DbTaskListProvider(DbContextOptions<TaskContext> dbContextOptions) => _dbContextOptions = dbContextOptions;

		/// <summary>
        /// Create new task in the storage
        /// </summary>
        /// <param name="newTask"></param>
        /// <returns></returns>
		public int CreateTask(KnownTask newTask)
        {
			if (newTask != null)
            {
                Models.TaskList task = new Models.TaskList()
                {
                    TaskId = newTask.TaskId,
                    Details = newTask.Details,
                    Status = newTask.Status,   
                };

				using (var dbContext = new TaskContext(_dbContextOptions))
                {
                    dbContext.TaskLists.Add(task);
                    dbContext.SaveChanges();
                    return task.TaskId;
                }
            }
			else
            {
                return 0;
            }
        }

		/// <summary>
        /// Get the list of all the tasks
        /// </summary>
        /// <returns></returns>
        public ImmutableList<KnownTask> GetAllTasksList()
        {
            using (var dbContext = new TaskContext(_dbContextOptions))
            {
                ImmutableList<KnownTask> alltasks = dbContext.TaskLists
                    .Select(n => new KnownTask(
                        n.TaskId,
                        n.Details,
                        n.Status))
                    .ToImmutableList();
                return alltasks;
            }
        }


		/// <summary>
        /// Delete the task from the database
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
		public bool DeleteTask(int taskId)
        {
            if (taskId != 0)
            {
                using (var dbContext = new TaskContext(_dbContextOptions))
                {
                    Models.TaskList task = dbContext.TaskLists.Find(taskId);
					if (null == task)
                    {
                        return false;
                    }
					else
                    {
                        dbContext.TaskLists.Remove(task);
                        dbContext.SaveChanges();
                        return true;
                    }
                    
                }
            }
            else
            {
                return false;
            }
        }

		/// <summary>
        /// Update the status from pending to done or done to pending
        /// Pending means true
        /// Done means false
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
		public bool UpdateTaskStatus(int taskId)
        {
			if (taskId != 0)
            {
                using (var dbContext = new TaskContext(_dbContextOptions))
                {
                    Models.TaskList task = dbContext.TaskLists.Find(taskId);
                    if (null == task)
                    {
                        return false;
                    }
                    else
                    {
                        if(false == task.Status)
                        {
                            task.Status = true;
                        }
                        else
                        {
                            task.Status = false;
                        }
                        
                        dbContext.SaveChanges();
                        return true;
                    }

                }
            }
			else
            {
                Console.WriteLine("id is");
                return false;
            }
        }
    }
}