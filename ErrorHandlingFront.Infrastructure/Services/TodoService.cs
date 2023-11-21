using System.Text.Json;
using ErrorHandlingFront.Application.Entities;
using ErrorHandlingFront.Application.Interfaces;
using ErrorHandlingFront.Infrastructure.Common.Extensions;
using ErrorHandlingFront.Infrastructure.Persistence.Repositories;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingFront.Infrastructure.Services;

public class TodoService : ITodoService
{
    const string ProblemDetailsKey = "details";
    readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<List<Todo>>> GetTodos()
    {
        try
        {
            var todos = await _todoRepository.GetTodos();
            if (!todos.IsSuccessStatusCode)
            {
                var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(todos.Error.Content);
                var error = new Error(problemDetails.Title).WithMetadata(ProblemDetailsKey, problemDetails);
                return Result.Fail(error);
            }

            return Result.Ok(todos.Content).WithSuccess("Todos retrieved successfully");
        }
        catch (Exception e)
        {
            var error = new Error(e.Message).WithMetadata(ProblemDetailsKey, e.ToProblemDetails());
            return Result.Fail(error);
        }
    }

    public async Task<Result<Todo>> Create(Todo todo)
    {
        try
        {
            var result = await _todoRepository.Create(todo.Title);
            if (!result.IsSuccessStatusCode)
            {
                var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(result.Error.Content);
                var error = new Error(problemDetails.Title).WithMetadata(ProblemDetailsKey, problemDetails);
                return Result.Fail(error);
            }

            return Result.Ok(result.Content).WithSuccess("Todo created successfully");
        }
        catch (Exception e)
        {
            var error = new Error(e.Message).WithMetadata(ProblemDetailsKey, e.ToProblemDetails());
            return Result.Fail(error);
        }
    }

    public async Task<Result> DeleteTodoAsync(Guid requestId)
    {
        try
        {
            var result = await _todoRepository.Delete(requestId.ToString());
            if (!result.IsSuccessStatusCode)
            {
                var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(result.Error.Content);
                var error = new Error(problemDetails.Title).WithMetadata("details", problemDetails);
                return Result.Fail(error);
            }

            return Result.Ok().WithSuccess($"Todo with id {requestId} deleted successfully");
        }
        catch (Exception e)
        {
            var error = new Error(e.Message).WithMetadata(ProblemDetailsKey, e.ToProblemDetails());
            return Result.Fail(error);
        }
    }
}