using FluentResults;
using MediatR;

namespace ErrorHandlingFront.Application.Todo.GetTodos;

public class GetTodosRequest : IRequest<Result<List<Entities.Todo>>>
{
    
}