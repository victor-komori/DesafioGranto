using AutoMapper;
using DesafioGranto.Models.DTO;
using DesafioGranto.Models.Entities;

namespace DesafioGranto.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Regiao,
                    opt => opt.MapFrom(src => $"{src.Regiao}")
                )
                .ForMember(
                    dest => dest.Oportunidades,
                    opt => opt.Ignore()
                );

            CreateMap<UsuarioCadastroDTO, Usuario>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Regiao,
                    opt => opt.MapFrom(src => $"{src.Regiao}")
                )
                .ForMember(
                    dest => dest.Oportunidades,
                    opt => opt.Ignore()
                );
        }
    }
}
