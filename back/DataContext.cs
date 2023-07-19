using Microsoft.EntityFrameworkCore;

namespace CatalogoVeiculos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
