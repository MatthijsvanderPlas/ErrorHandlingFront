namespace ErrorHandlingFront.Application.Entities;

public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; } 
    public bool IsCompleted { get; set; } 
}