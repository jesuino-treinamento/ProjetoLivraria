using ProjetoLivraria.Domain.Core.Interfaces.Repositories;
using ProjetoLivraria.Domain.Entities;

namespace ProjetoLivraria.Infrastructure.Data.Repositories
{
    public class RepositoryLivro : RepositoryBase<Livro>, IRepositoryLivro
    {
        private readonly SQLContext sqlcontext;

        public RepositoryLivro(SQLContext sqlcontext) : base(sqlcontext)
        {
            this.sqlcontext = sqlcontext;
        }
    }
}