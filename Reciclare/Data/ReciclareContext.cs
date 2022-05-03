using Microsoft.EntityFrameworkCore;

namespace Reciclare.Data
{
    public class ReciclareContext : DbContext
    {
        public ReciclareContext(DbContextOptions<ReciclareContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<MaterialDTO> Material { get; set; }
        public DbSet<ProdusDTO> Produs { get; set; }
        public DbSet<ContainerDTO> Container { get; set; }
    }
}