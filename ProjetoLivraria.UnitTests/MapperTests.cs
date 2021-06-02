using AutoMapper;
using NUnit.Framework;
using ProjetoLivraria.Application.Mapper;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoLivraria.UnitTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MapperTests
    {
        [Test]
        public void AutoMapperDtoToModel_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingLivro>());
            config.AssertConfigurationIsValid();
        }

        [Test]
        public void AutoMapperModelToDto_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingLivro>());
            config.AssertConfigurationIsValid();
        }       
    }
}