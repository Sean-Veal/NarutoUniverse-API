using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ProblemDetails problemDetails;
        if (exception is ApplicationException applicationException)
        {
            problemDetails = new ProblemDetails
            {
                Status = applicationException.Error.statusCode,
                Title = applicationException.Error.Code,
                Detail = applicationException.Error.Message
            };
        }
        else
        {
            logger.LogError(exception, exception.Message);
            problemDetails = new ProblemDetails
            {
                Status = 500,
                Title = "Internal Server Error",
                Detail = "An Unexpected Error has Occurred."
            };
        }

        httpContext.Response.StatusCode = problemDetails.Status ?? 500;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}