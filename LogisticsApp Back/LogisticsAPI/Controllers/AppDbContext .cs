using LogisticsApp.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Bodega> Bodegas { get; set; }
    public DbSet<Puerto> Puertos { get; set; }
    public DbSet<EnvioTerrestre> EnviosTerrestres { get; set; }
    public DbSet<EnvioMaritimo> EnviosMaritimos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de las entidades y relaciones

        modelBuilder.Entity<Cliente>().ToTable("Clientes");
        modelBuilder.Entity<Cliente>().Property(c => c.Nombre).IsRequired();
        modelBuilder.Entity<Cliente>().Property(c => c.Email).IsRequired();

        modelBuilder.Entity<Producto>().ToTable("Productos");
        modelBuilder.Entity<Producto>().Property(p => p.Nombre).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.Tipo).IsRequired();

        modelBuilder.Entity<Bodega>().ToTable("Bodegas");
        modelBuilder.Entity<Bodega>().Property(c => c.Nombre).IsRequired();
        modelBuilder.Entity<Bodega>().Property(c => c.Ubicacion).IsRequired();

        modelBuilder.Entity<Puerto>().ToTable("Puertos");
        modelBuilder.Entity<Puerto>().Property(c => c.Nombre).IsRequired();
        modelBuilder.Entity<Puerto>().Property(c => c.Ubicacion).IsRequired();

        modelBuilder.Entity<Producto>().ToTable("Productos");
        modelBuilder.Entity<Producto>().Property(p => p.Nombre).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.Tipo).IsRequired();
        modelBuilder.Entity<Producto>().Property(e => e.PrecioUnidad).IsRequired();

        modelBuilder.Entity<EnvioTerrestre>().ToTable("EnviosTerrestres");
        modelBuilder.Entity<EnvioTerrestre>().Property(e => e.TipoProducto).IsRequired();
        modelBuilder.Entity<EnvioTerrestre>().Property(e => e.CantidadProducto).IsRequired();
        modelBuilder.Entity<EnvioTerrestre>().Property(e => e.FechaRegistro).IsRequired();
        modelBuilder.Entity<EnvioTerrestre>().Property(e => e.FechaEntrega).IsRequired();
        modelBuilder.Entity<EnvioTerrestre>().HasOne(e => e.Bodega).WithMany().HasForeignKey(e => e.BodegaId);
        modelBuilder.Entity<EnvioTerrestre>().Property(e => e.PrecioEnvio).IsRequired();
        modelBuilder.Entity<EnvioTerrestre>().Property(e => e.PlacaVehiculo).IsRequired();
        modelBuilder.Entity<EnvioTerrestre>().Property(e => e.NumeroGuia).IsRequired();
        modelBuilder.Entity<EnvioTerrestre>().HasOne(e => e.Cliente).WithMany().HasForeignKey(e => e.ClienteId);
        modelBuilder.Entity<EnvioTerrestre>().HasOne(e => e.Producto).WithMany().HasForeignKey(e => e.ProductoId);

        modelBuilder.Entity<EnvioMaritimo>().ToTable("EnviosMaritimos");
        modelBuilder.Entity<EnvioMaritimo>().Property(e => e.TipoProducto).IsRequired();
        modelBuilder.Entity<EnvioMaritimo>().Property(e => e.CantidadProducto).IsRequired();
        modelBuilder.Entity<EnvioMaritimo>().Property(e => e.FechaRegistro).IsRequired();
        modelBuilder.Entity<EnvioMaritimo>().Property(e => e.FechaEntrega).IsRequired();
        modelBuilder.Entity<EnvioMaritimo>().HasOne(e => e.Puerto).WithMany().HasForeignKey(e => e.PuertoId);
        modelBuilder.Entity<EnvioMaritimo>().Property(e => e.PrecioEnvio).IsRequired();
        modelBuilder.Entity<EnvioMaritimo>().Property(e => e.NumeroFlota).IsRequired();
        modelBuilder.Entity<EnvioMaritimo>().Property(e => e.NumeroGuia).IsRequired();
        modelBuilder.Entity<EnvioMaritimo>().HasOne(e => e.Cliente).WithMany().HasForeignKey(e => e.ClienteId);
        modelBuilder.Entity<EnvioMaritimo>().HasOne(e => e.Producto).WithMany().HasForeignKey(e => e.ProductoId);
    }
}
