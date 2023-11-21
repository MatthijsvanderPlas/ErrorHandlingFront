using ErrorHandlingFront.Application.Interfaces;
using FluentResults;
using MediatR;

namespace ErrorHandlingFront.Application.Todo.GetTodos;

public class GetTodosRequestHandler : IRequestHandler<GetTodosRequest, Result<List<Entities.Todo>>>
{
    readonly ITodoService _todoService;

    public GetTodosRequestHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<Result<List<Entities.Todo>>> Handle(GetTodosRequest request, 
        CancellationToken cancellationToken)
    {
       var todos = await _todoService.GetTodos();
       return todos;
    }
}