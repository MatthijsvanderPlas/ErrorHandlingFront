using ErrorHandlingFront.Application.Interfaces;
using FluentResults;
using MediatR;

namespace ErrorHandlingFront.Application.Todo.CreateTodo;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Result<Entities.Todo>>
{
    readonly ITodoService _todoService;

    public CreateTodoCommandHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<Result<Entities.Todo>> Handle(CreateTodoCommand command, CancellationToken 
            cancellationToken)
    {
        var todo = new Entities.Todo
        {
            Title = command.Request.Title
        };
        
        var result = await _todoService.Create(todo);
        
        return result;
    }
}