using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrimeraPracticaNetCore.Models;

namespace PrimeraPracticaNetCore.Data
{
    public class ZapatillasContext : DbContext
    {
        public ZapatillasContext(DbContextOptions<ZapatillasContext> options) : base(options) { }

        public DbSet<Zapatilla> Zapatillas { get; set; }
        public DbSet<Imagen> ImagenesZapatillas { get; set; }

        public DbSet<DetallesZapatilla> DetallesZapatillas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar ModelPaginacionCubos como una entidad sin clave primaria
            modelBuilder.Entity<DetallesZapatilla>().HasNoKey();
        }


    }
}
