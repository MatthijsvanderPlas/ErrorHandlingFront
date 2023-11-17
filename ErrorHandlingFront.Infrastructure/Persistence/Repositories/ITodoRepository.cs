using Ardalis.Result;
using ErrorHandlingFront.Application.Entities;
using Refit;

namespace ErrorHandlingFront.Infrastructure.Persistence.Repositories;

[Headers("Accept: application/json", "Accept: application/problem+json")]
public interface ITodoRepository
{
    [Get("/")]
    Task<List<Todo>> GetTodos();

    [Post("/")]
    Task<ApiResponse<Result<Guid>>> Create([Query] string title);
}