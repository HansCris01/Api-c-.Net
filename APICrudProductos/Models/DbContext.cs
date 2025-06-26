// Models/ApplicationDbContext.cs
using APICrudProductos.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }

    // Opcional: Puedes sobrescribir OnModelCreating para configurar el modelo
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ejemplo de configuración de datos iniciales (seeding)
        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200.50m, Stock = 10 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25.00m, Stock = 50 }
        );
    }
}
