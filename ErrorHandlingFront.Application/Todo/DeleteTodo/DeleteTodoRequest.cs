using FluentResults;
using MediatR;

namespace ErrorHandlingFront.Application.Todo.DeleteTodo;

public record DeleteTodoRequest(Guid Id) : IRequest<Result>;
    