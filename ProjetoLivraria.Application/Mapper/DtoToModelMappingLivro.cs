using AutoMapper;
using ProjetoLivraria.Application.DTOs;
using ProjetoLivraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoLivraria.Application.Mapper
{
    public class DtoToModelMappingLivro : Profile
    {
        public DtoToModelMappingLivro()
        {
            LivroMap();
        }

        private void LivroMap()
        {
            CreateMap<LivroDTO, Livro>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(x => x.ISBN))
                .ForMember(dest => dest.Autor, opt => opt.MapFrom(x => x.Autor))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Preco, opt => opt.MapFrom(x => x.Preco))
                .ForMember(dest => dest.DataPublicacao, opt => opt.MapFrom(x => x.DataPublicacao))
                .ForMember(dest => dest.ImagemCapa, opt => opt.MapFrom(x => x.ImagemCapa));
               // .ForMember(dest => dest.Foto, opt => opt.MapFrom(x => x.Foto));
        }
    }
}
