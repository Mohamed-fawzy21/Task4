using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Behaviors;
using Products.Application.Features.Products.Commands;

namespace Products.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(CreateProductCommand).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(applicationAssembly));
        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
