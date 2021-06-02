using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using ProjetoLivraria.Application;
using ProjetoLivraria.Application.DTOs;
using ProjetoLivraria.Domain.Core.Interfaces.Services;
using ProjetoLivraria.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ProjetoLivraria.UnitTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ApplicationServiceLivroTests
    {
        private static Fixture _fixture;
        private Mock<IServiceLivro> _mockServiceLivros;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockServiceLivros = new Mock<IServiceLivro>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void ApplicationServiceLivros_GetAll_ShouldReturnLivros()
        {
            //Arrange
            var livros = _fixture.Build<Livro>()
                                   .CreateMany(5);
            var livrosDTO = _fixture.Build<LivroDTO>()
                                  .CreateMany(5);

            _mockServiceLivros.Setup(x => x.GetAll()).Returns(livros);

            _mockMapper.Setup(x => x.Map<IEnumerable<LivroDTO>>(livros)).Returns(livrosDTO);

            var applicationServiceCliente = new ApplicationServiceLivro(_mockServiceLivros.Object, _mockMapper.Object);

            //Act
            var result = applicationServiceCliente.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            _mockServiceLivros.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}