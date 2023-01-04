using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
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
		catch (NotFoundException e)
		{
			await BodyFromMessage(e, 404, context);
        }
		catch (UnauthorizedException e)
		{
            await BodyFromMessage(e, 401, context);

        }
        catch (ForbiddenException e)
		{
            await BodyFromMessage(e, 403, context);

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

	private async Task BodyFromMessage(Exception e, int statusCode, HttpContext context)
	{
		context.Response.StatusCode = statusCode;
		await context.Response.WriteAsync(e.Message);
	}

	private async Task SomethingWentWrong(HttpContext context)
	{
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Something went wrong.");
    }
}
