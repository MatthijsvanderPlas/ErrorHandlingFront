namespace ErrorHandlingFront.Application.Interfaces;

public interface ITodoService
{
    Task<List<Entities.Todo>> GetTodos();
}