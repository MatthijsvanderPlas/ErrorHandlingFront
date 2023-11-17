using Ardalis.Result;
using Mediator;

namespace ErrorHandlingFront.Application.Todo.CreateTodo;

public record CreateTodoCommand(CreateTodoRequest Request) : ICommand<Result<Guid>>;

    