using Microsoft.EntityFrameworkCore;
using Jardin.Models;

namespace Jardin
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=PETU-STI-52\\SQLEXPRESS;Initial Catalog=Jardin;Integrated Security=True;TrustServerCertificate=Yes");
        }

        public DbSet<Jardins> Jardins { get; set; }
        public DbSet<Legume> Legumes { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
    }
}
