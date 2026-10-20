
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace RockPaperScissor.CrossCutting.Extensions;

public static class ApiDocumentationExtension
{
    public static IServiceCollection AddServiceDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(doc =>
        {
            doc.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Rock, Paper & Scissor game",
                Version = "v1",
                Description = "A `simple` game of Rock, Paper & Scissor..."
            });
        });
        return services;
    }

    public static IApplicationBuilder UseServiceDocumentation(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseSwagger();
        appBuilder.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rock, Paper & Scissor API v1");
            c.RoutePrefix = string.Empty;
        });
        return appBuilder;
    }
}
