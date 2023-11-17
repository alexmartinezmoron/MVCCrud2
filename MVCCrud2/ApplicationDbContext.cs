using Microsoft.EntityFrameworkCore;
using MVCCrud2.Models;
using System.Reflection;
using MVCCrud2.VeiwModels;


namespace MVCCrud2

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Coche> Coches => Set<Coche>();
        public DbSet<Marca> Marcas => Set<Marca>();


        public DbSet<MVCCrud2.VeiwModels.AddClienteVeiwModel> AddClienteVeiwModel { get; set; } = default!;
        

    }
}
