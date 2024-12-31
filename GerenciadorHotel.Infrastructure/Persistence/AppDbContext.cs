using GerenciadorHotel.Core.Entities;
using GerenciadorHotel.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHotel.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Calendary> Calendars { get; set; }
    public DbSet<Cash> Cash { get; set; }
    public DbSet<Consumption> Consumptions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Calendary>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(c => c.Room)
                    .WithMany(r => r.Calendars)
                    .HasForeignKey(c => c.IdRoom)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(c => c.Reservation)
                    .WithMany()
                    .HasForeignKey(c => c.IdReservation)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Cash>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(c => c.Admin)
                    .WithMany()
                    .HasForeignKey(c => c.IdAdmin)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(c => c.Reservations)
                    .WithOne(r => r.Cash)
                    .HasForeignKey(r => r.IdCash)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Consumption>(e =>
            {
                e.HasKey(c => c.Id);

                e.HasOne(c => c.Reservation)
                    .WithMany(r => r.Consumptions)
                    .HasForeignKey(c => c.IdReservation)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(c => c.Product)
                    .WithMany(p => p.Consumptions)
                    .HasForeignKey(c => c.IdProduct)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        

        builder
            .Entity<Product>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.Consumptions)
                    .WithOne(c => c.Product)
                    .HasForeignKey(c => c.IdProduct)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Reservation>(e =>
            {
                e.HasKey(r => r.Id);

                e.HasOne(r => r.Room)
                    .WithMany(r => r.Reservations)
                    .HasForeignKey(r => r.IdRoom)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Customer)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.IdCustomer)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Cash)
                    .WithMany(c => c.Reservations)
                    .HasForeignKey(r => r.IdCash)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Calendary)
                    .WithOne(c => c.Reservation)
                    .HasForeignKey<Reservation>(r => r.IdCalendary)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(r => r.Consumptions)
                    .WithOne(c => c.Reservation)
                    .HasForeignKey(c => c.IdReservation)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Room>(e =>
            {
                e.HasKey(r => r.Id);

                e.HasMany(r => r.Reservations)
                    .WithOne(r => r.Room)
                    .HasForeignKey(r => r.IdRoom)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(r => r.Calendars)
                    .WithOne(c => c.Room)
                    .HasForeignKey(c => c.IdRoom)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<User>(e =>
            {
                // Configuração do discriminador usando a coluna 'UserType' no banco
                e.HasDiscriminator<string>("UserType")
                    .HasValue<Admin>("Admin")
                    .HasValue<Customer>("Customer");

                // Configuração da chave primária
                e.HasKey(u => u.Id);

                // Configuração do mapeamento da propriedade Role
                e.Property(u => u.Role)
                    .HasConversion(
                        role => role.ToString(), // Enum -> String para o banco
                        role => (RoleEnum)Enum.Parse(typeof(RoleEnum), role) // String -> Enum para a aplicação
                    );
            });



        
        builder
            .Entity<Customer>(e =>
            {
                e.HasBaseType<User>();
                
                e.HasMany(c => c.Reservations)
                    .WithOne(r => r.Customer)
                    .HasForeignKey(r => r.IdCustomer)
                    .OnDelete(DeleteBehavior.Restrict);
                
            });
        
        builder
            .Entity<Admin>(e =>
            {
                e.HasBaseType<User>();
                
                e.HasMany(a => a.Cashes)
                    .WithOne(c => c.Admin)
                    .HasForeignKey(c => c.IdAdmin)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        base.OnModelCreating(builder);
    }
}