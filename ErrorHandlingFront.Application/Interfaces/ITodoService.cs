using FluentResults;

namespace ErrorHandlingFront.Application.Interfaces;

public interface ITodoService
{
    Task<Result<List<Entities.Todo>>> GetTodos();
    Task<Result<Entities.Todo>> Create(Entities.Todo todo);
    Task<Result> DeleteTodoAsync(Guid requestId);
}