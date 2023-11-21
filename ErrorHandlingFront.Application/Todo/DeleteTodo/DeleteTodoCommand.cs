using FluentResults;
using MediatR;

namespace ErrorHandlingFront.Application.Todo.DeleteTodo;

public record DeleteTodoCommand(DeleteTodoRequest Request) : IRequest<Result>;
    