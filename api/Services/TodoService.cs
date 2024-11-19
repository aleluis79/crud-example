using api.Models;

namespace api.Services;

public class TodoService : ITodoService
{

    private readonly ILogger<TodoService> _logger;

    private readonly ITodoRepo _repository;

    public TodoService(ILogger<TodoService> logger, ITodoRepo repository) {
        _logger = logger;
        _repository = repository;
    }

    public TodoModel? GetTodo(int id)
    {
        var todo = _repository.Todos.FirstOrDefault(t => t.Id == id);

        if (todo == null) {
            _logger.LogInformation("Todo {id} not found", id);
            return null;
        } else {
            return todo;
        }
    }

    public List<TodoModel> GetTodos()
    {
        return _repository.Todos.OrderBy(t => t.IsComplete).ThenByDescending(t => t.Created).ToList();
    }

    public TodoModel AddTodo(string name, string descripcion)
    {
        int maxId =  _repository.Todos.Count > 0 ? _repository.Todos.Max(t => t.Id) + 1: 1;
        var todo = new TodoModel {
            Id = maxId,
            Name = name,
            Description = descripcion,
            Created = DateTime.UtcNow,
            IsComplete = false
        };
        _repository.Todos.Add(todo);
        _logger.LogInformation("Todo {id} created", maxId);
        return todo;
    }

    public TodoModel? UpdateTodo(int id, string name, string descripcion, bool completed)
    {
        var todo = _repository.Todos.FirstOrDefault(t => t.Id == id);
        if (todo != null) {
            todo.Name = name;
            todo.Description = descripcion;
            todo.IsComplete = completed;
            _logger.LogInformation("Todo {id} updated", id);
            return todo;
        } else {
            _logger.LogInformation("Todo {id} not found", id);
            return null;
        }
    }

    public bool DeleteTodo(int id)
    {
        var todo = _repository.Todos.FirstOrDefault(t => t.Id == id);
        if (todo != null) {
            _repository.Todos.Remove(todo);
            _logger.LogInformation("Todo {id} deleted", id);
            return true;
        } else {
            _logger.LogInformation("Todo {id} not found", id);
            return false;
        }
    }

}

