using Microsoft.EntityFrameworkCore;
using ProjetoLivraria.Domain.Entities;
using ProjetoLivraria.Infrastructure.Data.EntityConfigurations;

namespace ProjetoLivraria.Infrastructure.Data
{
    public class SQLContext : DbContext
    {
        public SQLContext() { }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) {  }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroEntityConfiguration());

            //TODO: Comente esta linha para executar testes do xUnit
            //modelBuilder.Seed();
        }
    }
}