using System.Runtime.CompilerServices;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.API.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
	{
		_logger = logger;
	}

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next.Invoke(context);
		}
		catch (UnauthorizedException e)
		{
			context.Response.StatusCode = 401;
			await context.Response.WriteAsync(e.Message);
		}
		catch (ForbiddenException e)
		{
			context.Response.StatusCode = 403;
			await context.Response.WriteAsync(e.Message);
		}
		catch (LoggedException)
		{
			await SomethingWentWrong(context);
		}
		catch (Exception e)
		{
			_logger.LogError(e, "Internal server error.");
			await SomethingWentWrong(context);
		}
    }

	private async Task SomethingWentWrong(HttpContext context)
	{
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Something went wrong.");
    }
}
