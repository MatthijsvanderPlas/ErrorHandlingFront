namespace ErrorHandlingFront.Application.MessageService;

public class MessageService
{
    public event Action OnChange;
    public List<string> Messages { get; set; } = new List<string>();
    
    public void AddMessage(string message)
    {
        Messages.Add(" > " + message);
        OnChange.Invoke();
    }
    
    public void AddMessages(List<string> messages)
    {
        Messages.AddRange(messages);
    }
    
    public void ClearMessages()
    {
        Messages.Clear();
        OnChange.Invoke();
    }
    
}