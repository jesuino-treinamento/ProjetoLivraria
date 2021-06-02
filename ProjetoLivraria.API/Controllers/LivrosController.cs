using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.API.Util;
using ProjetoLivraria.Application.DTOs;
using ProjetoLivraria.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace ProjetoLivraria.API.Controllers
{
    [Route("Livros/")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly IApplicationServiceLivro _applicationServiceLivro;

        //Define uma instância de IHostingEnvironment
        public readonly IWebHostEnvironment _webHostEnvironment;

        public LivrosController(IApplicationServiceLivro applicationServiceLivro, IWebHostEnvironment webHostEnvironment)
        {
            _applicationServiceLivro = applicationServiceLivro;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Lista todos os livros.
        /// </summary>
        /// <remarks>
        /// * Opções de consulta.
        /// <![CDATA[https://docs.microsoft.com/en-us/odata/client/query-options
        /// -> <a href="https://docs.microsoft.com/en-us/odata/client/query-options" target="_blank">Clique</a>]]>
        ///
        /// * Busca ordenada por qualquer atributo do livro.
        /// <![CDATA[Ex1. : https://localhost:5000/livros/listar_livros?$filter=startsWith(autor,'L')&$orderby=autor desc
        /// -> <a href="https://localhost:5000/livros/listar_livros?$filter=startsWith(autor,%27L%27)&$orderby=autor%20desc" target="_blank">Clique</a>]]>
        ///
        /// * Busca ordenada por qualquer atributo do livro.
        /// <![CDATA[Ex2. : https://localhost:5000/livros/listar_livros?$orderby=autor&filter=autor eq 'autor'
        /// -> <a href="https://localhost:5000/livros/listar_livros?$orderby=autor&$filter=autor%20eq%20%27autor%27" target="_blank">Clique</a>]]>
        ///
        /// * Filtrar a seleção dos livros por qualquer atributo do livro.
        /// <![CDATA[Ex1. : https://localhost:5000/livros/listar_livros?&$select=autor,nome
        /// -> <a href="https://localhost:5000/livros/listar_livros?&$select=autor,nome" target="_blank">Clique</a>]]>
        ///
        ///  * Filtrar a seleção dos livros por qualquer atributo do livro.
        /// <![CDATA[Ex2. : https://localhost:5000/livros/listar_livros?$filter=autor in ('busca1','busca2')
        /// -> <a href="https://localhost:5000/livros/listar_livros?$filter=autor%20in%20(%27busca1%27,%27busca2%27)" target="_blank">Clique</a>]]>
        /// </remarks>
        [HttpGet("Listar_livros")]
        [EnableQuery]
        public IQueryable<LivroDTO> Get()
        {
            return _applicationServiceLivro.GetAll().AsQueryable();
        }

        /// <summary>
        /// Busca pelo ID. do livro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            try
            {
                var livroDTO = _applicationServiceLivro.GetById(id);

                if (livroDTO.ID == 0)
                    return Ok("Livro não encontrado!");

                return Ok(livroDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Remover livro
        /// </summary>
        /// <param name="livroDTO"></param>
        /// <returns></returns>
        [HttpDelete("Deletar")]
        public ActionResult Delete([FromBody] LivroDTO livroDTO)
        {
            try
            {
                if (livroDTO == null)
                    return NotFound();

                _applicationServiceLivro.Remove(livroDTO);
                return Ok("Livro Removido com sucesso");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adicionar livro.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Adicionar")]
        public ActionResult SubmitForm([FromForm] LivroForm form)
        {
            try
            {
                var livroDTO = CarregaModelo(form);
                return Ok(_applicationServiceLivro.ExisteLivro(livroDTO));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar livro.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Atualizar/{id}")]
        public ActionResult SubmitFormAtualizar([FromForm] LivroForm form, int id)
        {
            try
            {
                var livroDTO = CarregaModelo(form, id);

                if (livroDTO == null)
                    return NotFound();

                _applicationServiceLivro.Update(livroDTO);
                return Ok("Livro Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Visualizar imagem da capa
        /// </summary>
        /// <param name="nomeDoArquivo">Nome do arquivo</param>
        /// <returns></returns>
        [HttpGet("ImagemCapa/{nomeDoArquivo}")]
        public IActionResult Get([FromRoute] string nomeDoArquivo)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + nomeDoArquivo + ".jpg";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/jpg");
            }
            return null;
        }

        #region Uso interno: Classe e Método

            public class LivroForm
            {
                [Required] public string ISBN { get; set; }
                [Required] public string Autor { get; set; }
                public string Nome { get; set; }
                [Required] public decimal Preco { get; set; }
                [Required] public DateTime DataPublicacao { get; set; }
                [Required] public IFormFile LivroFile { get; set; }
            }

            private LivroDTO CarregaModelo([FromForm] LivroForm form, int id = 0)
            {
                var livroDTO = new LivroDTO()
                {
                    ID = id,
                    ISBN = form.ISBN,
                    Nome = form.Nome,
                    Autor = form.Autor,
                    Preco = form.Preco,
                    DataPublicacao = form.DataPublicacao
                };

                string pastaFotos = Path.Combine(_webHostEnvironment.WebRootPath, "uploads\\");

                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + form.LivroFile.FileName))
                {
                    form.LivroFile.CopyTo(fileStream);
                    fileStream.Flush();
                    livroDTO.ImagemCapa = path + form.LivroFile.FileName;
                    //livroDTO.Foto = form.LivroFile.ToByteArray();
                }

                return livroDTO;
            }

        #endregion Uso interno: Classe e Método

    }
}