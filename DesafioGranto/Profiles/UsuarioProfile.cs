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
                    dest => dest.Oportunidades,
                    opt => opt.Ignore()
                )
                .ReverseMap();

            CreateMap<UsuarioCadastroDTO, Usuario>()
                .ForMember(
                    dest => dest.Oportunidades,
                    opt => opt.Ignore()
                )
                .ReverseMap();
        }
    }
}
