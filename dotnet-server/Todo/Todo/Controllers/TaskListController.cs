using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Providers.TaskList.Interface;
using Todo.Messages.Responses;
using Todo.Messages.Responses.TaskList;
using System.Collections.Immutable;
using Todo.Data.TaskList;
using Todo.Providers.TaskList.Database;
using Microsoft.AspNetCore.Cors;

namespace Todo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : Controller
    {

        private readonly ITaskListProvider _taskListProvider;

        public TaskListController(ITaskListProvider taskListProvider)
        {
            _taskListProvider = taskListProvider;
        }


        // GET api/values
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            ImmutableList<KnownTask> taskList = _taskListProvider.GetAllTasksList();
            if (taskList != null)
            {
                return Json(new TaskListResponse(taskList));
            }
            else
            {
                return BadRequest(Json(new ErrorResponse(String.Format("List is not getting generated"))));
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] KnownTask newTask)
        {
            if (newTask != null)
            {
                int taskId = _taskListProvider.CreateTask(newTask);
                if (0 == taskId)
                {
                    return BadRequest(Json(new ErrorResponse(String.Format("Task is not created"))));
                }
                else
                {
                    return Json(new TaskIdResponse(taskId));
                }
            }
            else
            {
                return BadRequest(Json(new ErrorResponse(String.Format("Data is not received"))));
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            if (id != 0)
            {
                bool flag = _taskListProvider.UpdateTaskStatus(id);
                if (flag == true)
                {
                    return Json(new TaskIdResponse(id));
                }
                else
                {
                    return BadRequest(Json(new ErrorResponse(String.Format("Task status is not updated"))));
                }
            }
            else
            {
                return BadRequest(Json(new ErrorResponse(String.Format("Id or status is not received", id))));
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return Json(new TaskIdResponse(id));
            if (id != 0)
            {
//                return Json(new TaskIdResponse(id));
                //  return Json(new TaskKnownResponse(deleteTask));
                bool flag = _taskListProvider.DeleteTask(id);
                if (true == flag)
                {
                    return Json(new TaskIdResponse(id));
                }
                else
                {
                    return BadRequest(Json(new ErrorResponse(String.Format("Task is not deleted"))));
                }
            }
            else
            {
                return BadRequest(Json(new ErrorResponse(String.Format("Id is not received for delete function"))));
            }
        }
    }
}
