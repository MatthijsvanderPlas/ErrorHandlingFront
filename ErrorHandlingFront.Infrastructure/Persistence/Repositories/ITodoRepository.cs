using ErrorHandlingFront.Application.Entities;
using FluentResults;
using Refit;

namespace ErrorHandlingFront.Infrastructure.Persistence.Repositories;

[Headers("Accept: application/json", "Accept: application/problem+json")]
public interface ITodoRepository
{
    [Get("/")]
    Task<ApiResponse<List<Todo>>> GetTodos();

    [Post("/")]
    Task<ApiResponse<Todo>> Create([Query] string title);

    [Delete("/{requestId}")]
    Task<ApiResponse<Result>> Delete(string requestId);
}