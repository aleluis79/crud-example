using api.Models;

namespace api.Services;

public interface ITodoService
{
    public List<TodoModel> GetTodos();

    public TodoModel? GetTodo(int id);

    public TodoModel AddTodo(string name, string descripcion);

    public TodoModel? UpdateTodo(int id, string name, string descripcion, bool completed);

    public bool DeleteTodo(int id);

}
