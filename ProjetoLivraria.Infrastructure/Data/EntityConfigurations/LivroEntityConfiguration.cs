using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLivraria.Domain.Entities;

namespace ProjetoLivraria.Infrastructure.Data.EntityConfigurations
{
    public class LivroEntityConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> livroConfiguration)
        {
            livroConfiguration.ToTable("livros");
            livroConfiguration.HasKey(u => u.ID);

            livroConfiguration.Property(u => u.ISBN).IsRequired(true);

            livroConfiguration.Property(u => u.Autor).IsRequired(false);

            livroConfiguration.Property(u => u.Nome).IsRequired(false);

            livroConfiguration.Property(u => u.Preco).IsRequired(true);

            livroConfiguration.Property(u => u.DataPublicacao).IsRequired(true);

            livroConfiguration.Property(u => u.ImagemCapa).IsRequired(false);
        }
    }
}