using AutoMapper;
using IgrejaJdLilah.Application.Model;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.API.Dtos.Helpers
{
    public class ViewModelParaEntidade : Profile
    {
        public ViewModelParaEntidade()
        {
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Lote, LoteViewModel>();
            CreateMap<PalestranteEvento, PalestranteEventoViewModel>();
            CreateMap<Palestrante, PalestranteViewModel>();
            CreateMap<RedeSocial, RedeSocialViewModel>();
        }
        
    }
}