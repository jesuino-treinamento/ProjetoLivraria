using ProjetoLivraria.Domain.Core.Interfaces.Repositories;
using ProjetoLivraria.Domain.Core.Interfaces.Services;
using ProjetoLivraria.Domain.Entities;

namespace ProjetoLivraria.Domain.Services
{
    public class ServiceLivro : ServiceBase<Livro>, IServiceLivro
    {
        private readonly IRepositoryLivro repositoryLivro;

        public ServiceLivro(IRepositoryLivro repositoryLivro) : base(repositoryLivro)
        {
            this.repositoryLivro = repositoryLivro;
        }
    }
}