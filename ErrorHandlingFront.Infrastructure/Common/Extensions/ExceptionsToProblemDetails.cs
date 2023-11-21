using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingFront.Infrastructure.Common.Extensions;

public static class ExceptionsToProblemDetails
{
    public static ProblemDetails ToProblemDetails(this Exception e)
    {
        var problemDetails = new ProblemDetails()
        {
            Title = "Onverwachte fout opgetreden",
            Detail = e.Message,
            Status = 500,
            Instance = e.StackTrace
        };
        return problemDetails;
    }
}