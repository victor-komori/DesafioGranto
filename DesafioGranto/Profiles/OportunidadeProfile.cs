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
            CreateMap<Oportunidade, OportunidadeDTO>()
                .ForMember(
                    dest => dest.Cnpj,
                    opt => opt.MapFrom(src => $"{src.Cnpj}")
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.ValorMonetario,
                    opt => opt.MapFrom(src => $"{src.ValorMonetario}")
                )
                .ForMember(
                    dest => dest.RazaoSocial,
                    opt => opt.MapFrom(src => $"{src.RazaoSocial}")
                )
                .ForMember(
                    dest => dest.DescricaoAtividade,
                    opt => opt.MapFrom(src => $"{src.DescricaoAtividade}")
                )
                .ForMember(
                    dest => dest.DataOportunidade,
                    opt => opt.MapFrom(src => $"{src.DataOportunidade}")
                );

            CreateMap<OportunidadeCadastroDTO, Oportunidade>()
                .ForMember(
                    dest => dest.Cnpj,
                    opt => opt.MapFrom(src => $"{CpfCnpjUtils.SemFormatacao(src.Cnpj)}")
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome}")
                )
                .ForMember(
                    dest => dest.ValorMonetario,
                    opt => opt.MapFrom(src => $"{src.Valor}")
                );
        }
    }
}
