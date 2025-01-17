using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;

    private readonly ITodoService _todoService;

    public TodoController(ILogger<TodoController> logger, ITodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }

    [HttpGet("ping")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public ActionResult<string> Ping()
    {
        return Ok("pong");
    }

    [HttpGet]
    [ProducesResponseType<List<TodoModel>>(StatusCodes.Status200OK)]
    public ActionResult<List<TodoModel>> GetTodos() {
        return Ok(_todoService.GetTodos());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<TodoModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TodoModel> GetTodo(int id) {
        var todo = _todoService.GetTodo(id);
        if (todo is null) {
            return NotFound();
        } else {
            return Ok(todo);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<TodoModel> AddTodo(TodoCreateModel todoCreate) {
        var todo = _todoService.AddTodo(todoCreate.Name, todoCreate.Description);
        return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateTodo(int id, TodoUpdateModel todoUpdate) {
        var todo = _todoService.UpdateTodo(id, todoUpdate.Name, todoUpdate.Description, todoUpdate.IsComplete);
        if (todo is null) {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTodo(int id) {
        var ok = _todoService.DeleteTodo(id);
        if (!ok) {
            return NotFound();
        }
        return NoContent();
    }

}
