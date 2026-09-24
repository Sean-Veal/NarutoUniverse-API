using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Exception;

public class GlobalExceptionHandler: IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
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
            problemDetails = new ProblemDetails
            {
                Status = 500,
                Title = "Internal Server Error",
                Detail = exception.Message
            };
        }

        httpContext.Response.StatusCode = problemDetails.Status ?? 500;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}