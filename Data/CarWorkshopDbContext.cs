using CarWorkshopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopAPI.Data;

public class CarWorkshopDbContext : DbContext
{
    public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) 
        : base(options) { }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<TechnicalPassport> TechnicalPassports { get; set; }
    public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TechnicalPassport>()
            .HasOne(tp => tp.Vehicle)
            .WithOne(tp => tp.TechnicalPassport)
            .HasForeignKey<TechnicalPassport>(tp => tp.VehicleId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<TechnicalPassport>()
            .HasIndex(tp => tp.VehicleId)
            .IsUnique();
        
        modelBuilder.Entity<MaintenanceRecord>()
            .HasOne(mr => mr.Vehicle)
            .WithMany(v => v.MaintenanceRecords)
            .HasForeignKey(mr => mr.VehicleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle
            {
                Id = 1,
                Brand = "BMW",
                Model = "F10",
                Year = 2018
            },
            new Vehicle
            {
                Id = 2,
                Brand = "BMW",
                Model = "E30",
                Year = 1987
            },
            new Vehicle
            {
                Id = 3,
                Brand = "Mercedes",
                Model = "W123",
                Year = 1982
            }
            );
        modelBuilder.Entity<TechnicalPassport>().HasData(
            new TechnicalPassport
            {
                Id = 1,
                RegistrationNumber = "GD 9321",
                OwnerName = "Jakub",
                VehicleId = 1
            },
            new TechnicalPassport
            {
                Id = 2,
                RegistrationNumber = "WA 1234",
                OwnerName = "Marcin",
                VehicleId = 2
            },
            new TechnicalPassport
            {
                Id = 3,
                RegistrationNumber = "KK 2244",
                OwnerName = "Jan",
                VehicleId = 3
            }
            );
        modelBuilder.Entity<MaintenanceRecord>().HasData(
            new MaintenanceRecord
            {
                Id = 1,
                Description = "Wymiana oleju",
                Cost = 100,
                VehicleId = 1
            },
            new MaintenanceRecord
            {
                Id = 2,
                Description = "Wymiana Filtrów",
                Cost = 300,
                VehicleId = 1
            },
            new MaintenanceRecord
            {
                Id = 3,
                Description = "Zmiana opon",
                Cost = 50,
                VehicleId = 2
            },
            new MaintenanceRecord
            {
                Id = 4,
                Description = "Wymiana tarcz hamulcowych",
                Cost = 400,
                VehicleId = 3
            },
            new MaintenanceRecord
            {
                Id = 5,
                Description = "Wymiana klockow hamulcowych",
                Cost = 200,
                VehicleId = 3
            },
            new MaintenanceRecord
            {
                Id = 6,
                Description = "Wymiana glowicy",
                Cost = 1500,
                VehicleId = 3
            },
            new MaintenanceRecord
            {
                Id = 7,
                Description = "Wymiana panewek",
                Cost = 300,
                VehicleId = 3
            }
            );
    }
}