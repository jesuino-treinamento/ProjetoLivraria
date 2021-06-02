using ProjetoLivraria.Application.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLivraria.Application.Interfaces
{
    public interface IApplicationServiceLivro
    {
        void Add(LivroDTO livroDTO);

        void Update(LivroDTO livroDTO);

        void Remove(LivroDTO livroDTO);

        IEnumerable<LivroDTO> GetAll();

        LivroDTO GetById(int id);

       string ExisteLivro(LivroDTO livroDTO);

    }
}