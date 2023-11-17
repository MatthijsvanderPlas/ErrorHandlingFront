using Ardalis.Result;

namespace ErrorHandlingFront.Application.Interfaces;

public interface ITodoService
{
    Task<List<Entities.Todo>> GetTodos();
    Task<Result<Guid>> Create(Entities.Todo todo);
}