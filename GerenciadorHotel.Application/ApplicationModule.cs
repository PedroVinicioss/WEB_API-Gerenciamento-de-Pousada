using GerenciadorHotel.Application.Interfaces.Customers.Commands.CreateCustomer;
using GerenciadorHotel.Application.Interfaces.Customers.Queries.GetCustomerById;
using GerenciadorHotel.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorHotel.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers();

        return services;
    }
    
    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>());
        
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<GetCustomerByIdQuery>());

        services.AddTransient<IPipelineBehavior<CreateCustomerCommand, ResultViewModel<int>>, ValidateCreateCustomerCommandBehavior>();
        
        return services;
    }
}