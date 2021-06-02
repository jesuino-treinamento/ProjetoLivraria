using ProjetoLivraria.Application.DTOs;
using ProjetoLivraria.Application.Interfaces;
using ProjetoLivraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLivraria.Application.Mapper
{
    public class MapperLivro : IMapperLivro
    {
        private List<LivroDTO> livroDTO = new List<LivroDTO>();

        public Livro MapperDTOToEntity(LivroDTO livroDTO)
        {
            var livro = new Livro()
            {
                ID = livroDTO.ID,
                ISBN = livroDTO.ISBN,
                Nome = livroDTO.Nome,
                Autor = livroDTO.Autor,
                Preco = livroDTO.Preco,
                DataPublicacao = livroDTO.DataPublicacao,
                ImagemCapa = livroDTO.ImagemCapa
                //Foto = livroDTO.Foto
            };

            return livro;
        }

        public LivroDTO MapperEntityToDTO(Livro livro)
        {
            var livroDTO = new LivroDTO()
            {
                ID = livro.ID,
                ISBN = livro.ISBN,
                Nome = livro.Nome,
                Autor = livro.Autor,
                Preco = livro.Preco,
                DataPublicacao = livro.DataPublicacao,
                ImagemCapa = livro.ImagemCapa
               //Foto = livro.Foto
            };

            return livroDTO;
        }

        public IEnumerable<LivroDTO> MapperListLivrosDTO(IEnumerable<Livro> livros)
        {
            var dto = livros.Select(c => new LivroDTO
            {
                ID = c.ID,
                ISBN = c.ISBN,
                Nome = c.Nome,
                Autor = c.Autor,
                Preco = c.Preco,
                DataPublicacao = c.DataPublicacao,
                ImagemCapa = c.ImagemCapa//,
                //Foto = c.Foto
            }
            );

            return dto;
        }       
    }

}