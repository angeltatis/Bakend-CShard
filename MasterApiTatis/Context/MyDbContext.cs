
using MasterApiTatis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection;

namespace MasterApiTatis.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Products { get; set; }
        public DbSet<Unidad> Unids { get; set; }
        public DbSet<Unidad_producto> ProductUnids { get; set; }
        public DbSet<Departamento> departamentos { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<SubGrupo> subGrupos { get; set; }
        public DbSet<TipoProduct> tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //constraing
            modelBuilder.Entity<SubGrupo>().HasIndex(sbg => sbg.dessubgrup).IsUnique(true);
            modelBuilder.Entity<TipoProduct>().HasIndex(tip => tip.destippro).IsUnique(true);
            modelBuilder.Entity<Grupo>().HasIndex(sbg => sbg.desgrup).IsUnique(true);
            modelBuilder.Entity<Departamento>().HasIndex(dep => dep.desdep).IsUnique(true);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            // Configurar la precisión global para los decimales
            configurationBuilder.Properties<decimal>().HavePrecision(11, 2);

            // Configurar todas las columnas DateTime para que sean de tipo 'Date'
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");

            // Desactivar la eliminación en cascada globalmente
            configurationBuilder.Conventions.Remove<CascadeDeleteConvention>();
        }
    }
}
