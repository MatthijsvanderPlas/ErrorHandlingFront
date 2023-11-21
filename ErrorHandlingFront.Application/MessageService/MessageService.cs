using Microsoft.AspNetCore.Mvc;
using Radzen;

namespace ErrorHandlingFront.Application.MessageService;

public class MessageService
{
    readonly NotificationService _notificationService;
    
    public MessageService(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public event Action OnChange;
    public List<string> Messages { get; set; } = new List<string>();
    public int MessageCount = 0;
    
    public void AddMessage(string message)
    {
        Messages.Add(" > " + message);
        _notificationService.Notify(new NotificationMessage(){Summary = message, Severity = 
            NotificationSeverity.Info, Duration = 5000});
        MessageCount++;
        OnChange.Invoke();
    }
    
    public void AddMessages(List<string> messages)
    {
        Messages.AddRange(messages);
    }
    
    public void ClearMessages()
    {
        Messages.Clear();
        MessageCount = 0;
        OnChange.Invoke();
    }
    
    public void ResetCount()
    {
        MessageCount = 0;
        OnChange.Invoke();
    }
    
    public void AddError(ProblemDetails message)
    {
        Messages.Add(" > " + message.Title);
        _notificationService.Notify(new NotificationMessage(){Summary = message.Title, Detail = 
            message.Detail, Severity = NotificationSeverity.Error, Duration = 5000});
        MessageCount++;
        OnChange.Invoke();
    }
    
    public void AddInfo(ProblemDetails message)
    {
        Messages.Add(" > " + message.Title);
        _notificationService.Notify(new NotificationMessage(){Detail = message.Detail, Summary = message
            .Title, Severity = NotificationSeverity.Info, Duration = 5000});
        MessageCount++;
        OnChange.Invoke();
    }

    public void AddInfo(string title, string? detail = null)
    {
        Messages.Add(" > " + title);
        _notificationService.Notify(new NotificationMessage(){Summary = title, Detail = 
            detail, Severity = NotificationSeverity.Info, Duration = 5000});
        MessageCount++;
        OnChange.Invoke();
    }
 
}