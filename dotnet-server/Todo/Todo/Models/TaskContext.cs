using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Todo.Models;

namespace Todo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskContext : DbContext
    {
        
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options) 
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<TaskList> TaskLists { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {

            optionsBuilder.UseSqlite("Data Source = todolist.db");
        }


    }
    
    
}