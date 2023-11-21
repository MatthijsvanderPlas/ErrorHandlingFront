using ErrorHandlingFront.Application.Interfaces;
using FluentResults;
using MediatR;

namespace ErrorHandlingFront.Application.Todo.DeleteTodo;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, Result>
{
    readonly ITodoService _todoService;

    public DeleteTodoCommandHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<Result> Handle(DeleteTodoCommand command, CancellationToken 
        cancellationToken)
    {
        var result = await _todoService.DeleteTodoAsync(command.Request.Id);
        
        return result;
    }
}