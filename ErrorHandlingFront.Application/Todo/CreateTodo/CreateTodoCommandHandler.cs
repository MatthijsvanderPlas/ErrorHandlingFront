using Ardalis.Result;
using ErrorHandlingFront.Application.Interfaces;
using Mediator;

namespace ErrorHandlingFront.Application.Todo.CreateTodo;

public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, Result<Guid>>
{
    readonly ITodoService _todoService;

    public CreateTodoCommandHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async ValueTask<Result<Guid>> Handle(CreateTodoCommand command, CancellationToken 
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