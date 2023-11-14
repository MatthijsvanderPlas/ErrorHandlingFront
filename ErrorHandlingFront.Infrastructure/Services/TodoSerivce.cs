using ErrorHandlingFront.Application.Entities;
using ErrorHandlingFront.Application.Interfaces;
using ErrorHandlingFront.Infrastructure.Persistence.Repositories;

namespace ErrorHandlingFront.Infrastructure.Services;

public class TodoSerivce : ITodoService
{
    readonly ITodoRepository _todoRepository;

    public TodoSerivce(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<Todo>> GetTodos()
    {
        var todos = await _todoRepository.GetTodos();
        return todos;
    }
}