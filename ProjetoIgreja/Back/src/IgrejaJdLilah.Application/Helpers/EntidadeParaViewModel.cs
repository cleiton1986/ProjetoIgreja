using AutoMapper;
using IgrejaJdLilah.Application.Model;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Helpers
{
    public class EntidadeParaViewModel : Profile
    {
        public EntidadeParaViewModel()
        {
            CreateMap<EventoViewModel, Evento>();
        }
    }
}