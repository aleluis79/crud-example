using System;
using api.Models;

namespace api.Services;

public interface ITodoRepo
{
    public List<TodoModel> Todos { get; }
}
