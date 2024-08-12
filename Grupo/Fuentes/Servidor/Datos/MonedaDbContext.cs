using Microsoft.EntityFrameworkCore;
using Servidor.Datos.Configuracion;
using Servidor.Dominio;

namespace Servidor.Datos
{
    public class MonedaDbContext : DbContext
    {
        public MonedaDbContext(DbContextOptions<MonedaDbContext> options) : base(options)
        {

        }

        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MonedaConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
        }

    }
}
