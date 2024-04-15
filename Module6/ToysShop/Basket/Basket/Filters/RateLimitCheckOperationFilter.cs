using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Infrastructure.Filters;

public class RateLimitCheckOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hasRateLimit = context.MethodInfo.DeclaringType != null && (context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<RateLimitFilter>().Any() ||
                                                                        context.MethodInfo.GetCustomAttributes(true).OfType<RateLimitFilter>().Any());

        if (!hasRateLimit)
        {
            return;
        }

        operation.Responses.TryAdd("429", new OpenApiResponse { Description = "Too many requests" });
    }
}
