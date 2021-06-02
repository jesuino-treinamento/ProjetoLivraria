using ProjetoLivraria.Application.DTOs;
using ProjetoLivraria.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLivraria.Application.Interfaces
{
    public interface IMapperLivro
    {
        abstract Livro MapperDTOToEntity(LivroDTO livroDTO);

        abstract IEnumerable<LivroDTO> MapperListLivrosDTO(IEnumerable<Livro> livros);

        abstract LivroDTO MapperEntityToDTO(Livro livro);
    }
}