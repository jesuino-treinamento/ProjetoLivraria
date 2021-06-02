using AutoMapper;
using ProjetoLivraria.Application.DTOs;
using ProjetoLivraria.Application.Interfaces;
using ProjetoLivraria.Domain.Core.Interfaces.Services;
using ProjetoLivraria.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLivraria.Application
{
    public class ApplicationServiceLivro : IApplicationServiceLivro
    {
        private readonly IServiceLivro serviceLivro;
        private readonly IMapper mapperLivro;
        private string result;

        public ApplicationServiceLivro(IServiceLivro serviceLivro, IMapper mapperLivro)
        {
            this.serviceLivro = serviceLivro;
            this.mapperLivro = mapperLivro;
        }

        public void Add(LivroDTO livroDTO)
        {
            var livro = mapperLivro.Map<Livro>(livroDTO);
            serviceLivro.Add(livro);
        }

        public IEnumerable<LivroDTO> GetAll()
        {
            var livros = serviceLivro.GetAll();
            return mapperLivro.Map<IEnumerable<LivroDTO>>(livros); 
        }

        public LivroDTO GetById(int id)
        {
            var livro = serviceLivro.GetById(id);
            var livroDTO = mapperLivro.Map<LivroDTO>(livro);
            
            if (livro == null)
                return new LivroDTO();

            return livroDTO;
        }

        public void Remove(LivroDTO livroDTO)
        {
            var livro = mapperLivro.Map<Livro>(livroDTO);
            serviceLivro.Remove(livro);
        }

        public void Update(LivroDTO livroDTO)
        {
            var livro = mapperLivro.Map<Livro>(livroDTO);
            serviceLivro.Update(livro);
        }

        public string ExisteLivro(LivroDTO livroDTO)
        {
            var livros = serviceLivro.GetAll();
            var LivrosDTO = mapperLivro.Map<IEnumerable<LivroDTO>>(livros);

           // IEnumerable<LivroDTO> TodosLivros = mapperLivro.Map.(serviceLivro.GetAll());

            var resultLivro = LivrosDTO.SeExisteISBN(livroDTO.ISBN);

            if (resultLivro.Count() == 0)
            {
                Add(livroDTO);// Adicionar livro
                result = "Livro Cadastrado com sucesso!";
            }
            else
                result = "Já existe livro com ISBN";

            return result;
        }
    }

    public static partial class Queries
    {
        public static IEnumerable<LivroDTO> SeExisteISBN(this IEnumerable<LivroDTO> query, string ISBN)
        {
            return query.Where(x => x.ISBN == ISBN);
        }
    }
}