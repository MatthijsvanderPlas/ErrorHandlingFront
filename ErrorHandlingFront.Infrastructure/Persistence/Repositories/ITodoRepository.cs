using ErrorHandlingFront.Application.Entities;
using Refit;

namespace ErrorHandlingFront.Infrastructure.Persistence.Repositories;

[Headers("Accept: application/json")]
public interface ITodoRepository
{
    [Get("/")]
    Task<List<Todo>> GetTodos();
}