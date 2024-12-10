using GerenciadorHotel.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorHotel.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddServices();

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
}