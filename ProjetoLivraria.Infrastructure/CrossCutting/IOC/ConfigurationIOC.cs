using Autofac;
using AutoMapper;
using ProjetoLivraria.Application;
using ProjetoLivraria.Application.Interfaces;
using ProjetoLivraria.Application.Mapper;
using ProjetoLivraria.Domain.Core.Interfaces.Repositories;
using ProjetoLivraria.Domain.Core.Interfaces.Services;
using ProjetoLivraria.Domain.Services;
using ProjetoLivraria.Infrastructure.Data.Repositories;

namespace ProjetoLivraria.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceLivro>().As<IApplicationServiceLivro>();

            builder.RegisterType<ServiceLivro>().As<IServiceLivro>();

            builder.RegisterType<RepositoryLivro>().As<IRepositoryLivro>();

            // builder.RegisterType<MapperLivro>().As<IMapperLivro>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingLivro());
                cfg.AddProfile(new ModelToDtoMappingLivro());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            #endregion IOC

        }
    }
}