using Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Extensions;

public static class RequestLoggingMiddlewareExtensions
{
	public static IApplicationBuilder UseRequestLogging(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<RequestLoggingMiddleware>();
	}
}
