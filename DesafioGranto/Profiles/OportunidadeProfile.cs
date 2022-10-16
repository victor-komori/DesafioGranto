using AutoMapper;
using DesafioGranto.Models.DTO;
using DesafioGranto.Models.Entities;
using DesafioGranto.Models.Utils;

namespace DesafioGranto.Profiles
{
    public class OportunidadeProfile : Profile
    {
        public OportunidadeProfile()
        {
            CreateMap<Oportunidade, OportunidadeDTO>().ReverseMap();

            CreateMap<OportunidadeCadastroDTO, Oportunidade>()
                .ForMember(
                    dest => dest.Cnpj,
                    opt => opt.MapFrom(src => $"{CpfCnpjUtils.SemFormatacao(src.Cnpj)}")
                )
                .ReverseMap();
        }
    }
}
