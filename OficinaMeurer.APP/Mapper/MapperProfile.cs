using AutoMapper;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.APP.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            CreateMap<IncluirOSViewModel, OrdemDeServico>();

            CreateMap<ServicoViewModel, ServicoOrdemDeServico>()
                .ForMember(dst => dst.IdServico, map => map.MapFrom(src => src.Id));

            CreateMap<ProdutoViewModel, ProdutoOrdemDeServico>()
                .ForMember(dst => dst.IdProduto, map => map.MapFrom(src => src.Id));

            CreateMap<OrdemDeServico, ResumoOSViewModel>()
                .ForMember(dst => dst.Valor, map => map.MapFrom(src =>
                    src.ServicosOS.Sum(s => s.Servico.ValorMaoDeObra) +
                    src.ProdutosOS.Sum(p => p.Produto.Valor)));

            CreateMap<OrdemDeServico, OrdemDeServicoViewModel>()
                .ForMember(dst => dst.Valor, map => map.MapFrom(src =>
                    src.ServicosOS.Sum(s => s.Servico.ValorMaoDeObra) +
                    src.ProdutosOS.Sum(p => p.Produto.Valor)));

            CreateMap<ServicoOrdemDeServico, ServicoViewModel>()
                .ForMember(src => src.Id, map => map.MapFrom(src => src.IdServico))
                .ForMember(src => src.Descricao, map => map.MapFrom(src => src.Servico.Descricao))
                .ForMember(src => src.Observacoes, map => map.MapFrom(src => src.Servico.Observacoes))
                .ForMember(src => src.ValorMaoDeObra, map => map.MapFrom(src => src.Servico.ValorMaoDeObra));

            CreateMap<ProdutoOrdemDeServico, ProdutoViewModel>()
                .ForMember(src => src.Id, map => map.MapFrom(src => src.IdProduto))
                .ForMember(src => src.Descricao, map => map.MapFrom(src => src.Produto.Descricao))
                .ForMember(src => src.Nome, map => map.MapFrom(src => src.Produto.Nome))
                .ForMember(src => src.Valor, map => map.MapFrom(src => src.Produto.Valor));

            CreateMap<ProdutoViewModel, ProdutoOrdemDeServico>()
                .ForMember(dst => dst.IdProduto, map => map.MapFrom(src => src.Id));




        }

    }
}
