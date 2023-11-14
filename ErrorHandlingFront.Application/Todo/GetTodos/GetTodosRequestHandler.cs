using ErrorHandlingFront.Application.Interfaces;
using Mediator;

namespace ErrorHandlingFront.Application.Todo.GetTodos;

public class GetTodosRequestHandler : IRequestHandler<GetTodosRequest, List<Entities.Todo>>
{
    readonly ITodoService _todoService;

    public GetTodosRequestHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async ValueTask<List<Entities.Todo>> Handle(GetTodosRequest request, CancellationToken cancellationToken)
    {
       var todos = await _todoService.GetTodos();
       return todos;
    }
}