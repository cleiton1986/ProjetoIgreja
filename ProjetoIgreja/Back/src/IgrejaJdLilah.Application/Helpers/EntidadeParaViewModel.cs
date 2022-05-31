using AutoMapper;
using IgrejaJdLilah.Application.Model;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Helpers
{
    public class EntidadeParaViewModel : Profile
    {
        public EntidadeParaViewModel()
        {
           // CreateMap<EventoViewModel, Evento>().ReverseMap();
             CreateMap<EventoViewModel, Evento>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<LoteViewModel, Lote>();
            CreateMap<PalestranteEventoViewModel, PalestranteEvento>();
            CreateMap<PalestranteViewModel, Palestrante>();
            CreateMap<RedeSocialViewModel, RedeSocial>();
            
        }
    }
}