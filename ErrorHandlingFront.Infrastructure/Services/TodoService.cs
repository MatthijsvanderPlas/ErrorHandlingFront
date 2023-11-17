using System.Net;
using System.Text.Json;
using Ardalis.Result;
using ErrorHandlingFront.Application.Entities;
using ErrorHandlingFront.Application.Interfaces;
using ErrorHandlingFront.Application.MessageService;
using ErrorHandlingFront.Infrastructure.Persistence.Repositories;
using Refit;

namespace ErrorHandlingFront.Infrastructure.Services;

public class TodoService : ITodoService
{
    readonly ITodoRepository _todoRepository;
    readonly MessageService _messageService;

    public TodoService(ITodoRepository todoRepository, MessageService messageService)
    {
        _todoRepository = todoRepository;
        _messageService = messageService;
    }

    public async Task<List<Todo>> GetTodos()
    {
        try
        {
            var todos = await _todoRepository.GetTodos();
            _messageService.AddMessage("Todos retrieved successfully");
            return todos;
        }
        catch (ApiException e)
        {
            _messageService.AddMessage(e.Content);
            return new List<Todo>();
        }
    }
    
    public async Task<Result<Guid>> Create(Todo todo)
    {
        try
        {
            var result = await _todoRepository.Create(todo.Title);
            if (!result.IsSuccessStatusCode)
            {
                var res = JsonSerializer.Deserialize<ProblemDetails>(result.Error.Content);
                _messageService.AddMessage($"{(HttpStatusCode)res.Status}");
                _messageService.AddMessage(res.Detail);
                _messageService.AddMessage("Todo creation failed");
                return Result.Invalid();
            }
            _messageService.AddMessage($"Todo: {result.Content.Value} created successfully");
            return result.Content;
        }
        catch (Exception e)
        {
            _messageService.AddMessage(e.Message);
            return Result.Invalid(new ValidationError(e.Message));
        }
    }
}