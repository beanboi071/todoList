using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using todoList.Models;

namespace todoList.Controllers
{
    [Route("api/todoList")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository todoRepository;
        public ToDoController(IToDoRepository todorepo)
        {
            todoRepository = todorepo;
        }

        [HttpGet("GetList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(todoRepository.GetAll());
        }

        [HttpGet("GetTask{id:int}",Name = "GetTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTask(int id) {
            if(id == 0)
            {
                return BadRequest();
            }
            var task = todoRepository.Gettask(id);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost("CreateTask" , Name = "Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTask([FromBody] Todo task)
        {
            if(task == null)
            {
                return BadRequest();
            }
            todoRepository.AddTask(task);
            return CreatedAtRoute("GetTask", new {id = task.Id},task);
        }

        [HttpPut("Update", Name = "Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromBody] Todo task)
        {
            //var checkTask = GetTask(task.Id);
            //if (checkTask == null)
            //{
            //    return NotFound(task);
            //}
            //checkTask = null;
            var updatedTask = todoRepository.UpdateTask( task);
            return Ok(updatedTask);

        }
        [HttpDelete("Delete{id:int}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var task = GetTask(id);
            if(task == null)
            {
                return NotFound();
            }
            todoRepository.DeleteTask(id);
            return Ok(task);
        }
    }
}
