using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingFront.Application.Common.Pipelines;

public class
    NotificationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    readonly MessageService.MessageService _messageService;

    public NotificationPipelineBehavior(MessageService.MessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var response = await next();

        if (response.IsFailed)
        {
            var hasDetails = response.Errors.First().Metadata.TryGetValue("details", out var details);
            if (hasDetails)
            {
                var problemDetails = details as ProblemDetails;
                _messageService.AddError(problemDetails);
            }
            else
            {
                var problemDetails = new ProblemDetails()
                {
                    Title = response.Errors.First().Message
                };
                _messageService.AddError(problemDetails);
            }
        }
        else if (response.IsSuccess)
        {
            var firstMessage = response.Successes.First().Message;
            var secondMessage = response.Successes.Count > 1 ? response.Successes[1].Message : ""; 
            _messageService.AddInfo(firstMessage, secondMessage);
        }

        return response;
    }
}