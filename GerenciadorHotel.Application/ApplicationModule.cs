using GerenciadorHotel.Application.Interfaces.Authentication.Services;
using GerenciadorHotel.Application.Interfaces.Calendary.Services;
using GerenciadorHotel.Application.Interfaces.Cash.Services;
using GerenciadorHotel.Application.Interfaces.Consumption.Services;
using GerenciadorHotel.Application.Interfaces.Product.Services;
using GerenciadorHotel.Application.Interfaces.Reservation.Services;
using GerenciadorHotel.Application.Interfaces.Room.Services;
using GerenciadorHotel.Application.Interfaces.User.Commands.CreateUser;
using GerenciadorHotel.Application.Interfaces.User.Queries.GetUserById;
using GerenciadorHotel.Application.Interfaces.User.Services;
using GerenciadorHotel.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorHotel.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddServices();
        
        services
            .AddHandlers();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IConsumptionService, ConsumptionService>();
        services.AddScoped<ICashService, CashService>();
        services.AddScoped<ICalendaryService, CalendaryService>();
        
        return services;
    }
    
    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<CreateUserCommand>());
        
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<GetUserByIdQuery>());

        services.AddTransient<IPipelineBehavior<CreateUserCommand, ResultViewModel<int>>, ValidateCreateUserCommandBehavior>();
        
        return services;
    }
}