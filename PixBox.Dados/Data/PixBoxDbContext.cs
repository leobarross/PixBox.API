using Microsoft.EntityFrameworkCore;
using PixBox.Dados.Entidades;

namespace PixBox.Dados.Data
{
    public class PixBoxDbContext : DbContext
    {
        public PixBoxDbContext(DbContextOptions<PixBoxDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
