using Microsoft.EntityFrameworkCore;

namespace SistemaWeb.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Tipo> Tipo{ get; set; }
        public DbSet<Classificacao> Classificacao { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Conta> Contas{ get; set; }

    }
}
