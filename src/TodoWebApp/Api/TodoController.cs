using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo.Application.TodoLists.Command.CreateTodo;
using Todo.Application.TodoLists.Queries.GetTodos;

namespace TodoWebApp.Api
{
    [Route("api/todo")]
    public class TodoController : BaseApiController
    {
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetTodosQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoItemCommand command) 
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
