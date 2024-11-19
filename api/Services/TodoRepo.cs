using api.Models;

namespace api.Services;

public class TodoRepo : ITodoRepo
{
    private List<TodoModel> todos = new List<TodoModel> {
        new TodoModel { Id = 1, Name = "Todo 1", Description = "Description 1", Created = DateTime.UtcNow, IsComplete = false },
        new TodoModel { Id = 2, Name = "Todo 2", Description = "Description 2", Created = DateTime.UtcNow, IsComplete = false },
        new TodoModel { Id = 3, Name = "Todo 3", Description = "Description 3", Created = DateTime.UtcNow, IsComplete = false },
        new TodoModel { Id = 4, Name = "Todo 4", Description = "Description 4", Created = DateTime.UtcNow, IsComplete = false },
        new TodoModel { Id = 5, Name = "Todo 5", Description = "Description 5", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 6, Name = "Todo 6", Description = "Description 6", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 7, Name = "Todo 7", Description = "Description 7", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 8, Name = "Todo 8", Description = "Description 8", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 9, Name = "Todo 9", Description = "Description 9", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 10, Name = "Todo 11", Description = "Description 10", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 11, Name = "Todo 12", Description = "Description 11", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 12, Name = "Todo 13", Description = "Description 12", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 13, Name = "Todo 14", Description = "Description 13", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 14, Name = "Todo 15", Description = "Description 14", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 15, Name = "Todo 16", Description = "Description 15", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 16, Name = "Todo 17", Description = "Description 16", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 17, Name = "Todo 18", Description = "Description 17", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 18, Name = "Todo 19", Description = "Description 18", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 19, Name = "Todo 20", Description = "Description 19", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 20, Name = "Todo 21", Description = "Description 20", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 21, Name = "Todo 22", Description = "Description 21", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 22, Name = "Todo 23", Description = "Description 22", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 23, Name = "Todo 24", Description = "Description 23", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 24, Name = "Todo 25", Description = "Description 24", Created = DateTime.UtcNow, IsComplete = false },
        // new TodoModel { Id = 25, Name = "Todo 26", Description = "Description 25", Created = DateTime.UtcNow, IsComplete = false },
    };

    List<TodoModel> ITodoRepo.Todos => todos;
}
