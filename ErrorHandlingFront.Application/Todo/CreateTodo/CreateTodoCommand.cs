using FluentResults;
using MediatR;

namespace ErrorHandlingFront.Application.Todo.CreateTodo;

public record CreateTodoCommand(CreateTodoRequest Request) : IRequest<Result<Entities.Todo>>;

    