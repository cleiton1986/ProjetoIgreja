using System.Globalization;
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
            CreateMap<EventoViewModel, Evento>()
              .AfterMap((x, y) => x.DataEvento = y.DataEvento.HasValue ? "" : y.DataEvento.Value.ToString("dd/MM/yyyy", new CultureInfo("pt-BR")))
              .AfterMap((x, y) => x.Email = y.Email)
              .AfterMap((x, y) => x.Id = y.Id)
              .AfterMap((x, y) => x.ImagemURL = y.ImagemURL)
              .AfterMap((x, y) => x.Local = y.Local)
              .AfterMap((x, y) => x.Observacao = y.Observacao)
              .AfterMap((x, y) => x.QtdPessoas = y.QtdPessoas)
              .AfterMap((x, y) => x.Telefone = y.Telefone)
              .AfterMap((x, y) => x.Tema = y.Tema);
             
            CreateMap<EnderecoViewModel, Endereco>()
            .AfterMap((x, y) => x.Cep = y.Cep)
            .AfterMap((x, y) => x.Complemento = y.Complemento)
            .AfterMap((x, y) => x.Id = y.Id)
            .AfterMap((x, y) => x.Local = y.Local)
            .AfterMap((x, y) => x.Numero = y.Numero);

            CreateMap<LoteViewModel, Lote>()
             .AfterMap((x, y) => x.EventoId = y.EventoId)
             .AfterMap((x, y) => x.Id = y.Id)
             .AfterMap((x, y) => x.Nome = y.Nome)
             .AfterMap((x, y) => x.Quantidade = y.Quantidade)
             .AfterMap((x, y) => x.DataFim = y.DataFim.HasValue ? "" : y.DataFim.Value.ToString("dd/MM/yyyy", new CultureInfo("pt-BR")))
             .AfterMap((x, y) => x.DataInicio = y.DataInicio.HasValue ? "" : y.DataInicio.Value.ToString("dd/MM/yyyy", new CultureInfo("pt-BR")));
             
            CreateMap<PalestranteEventoViewModel, PalestranteEvento>()
             .AfterMap((x, y) => x.EventoId = y.EventoId)
             .AfterMap((x, y) => x.PalestranteId = y.PalestranteId);

            CreateMap<PalestranteViewModel, Palestrante>()
              .AfterMap((x, y) => x.Email = y.Email)
              .AfterMap((x, y) => x.Denominacao = y.Denominacao)
              .AfterMap((x, y) => x.EnderecoId = y.EnderecoId)
              .AfterMap((x, y) => x.FazParteMesmaDenominacao = y.FazParteMesmaDenominacao)
              .AfterMap((x, y) => x.Id = y.Id)
              .AfterMap((x, y) => x.ImagemUrl = y.ImagemUrl)
              .AfterMap((x, y) => x.MiniCurriculo = y.MiniCurriculo)
              .AfterMap((x, y) => x.DataCadastro = y.DataCadastro != null ? "" : y.DataCadastro.ToString("dd/MM/yyyy", new CultureInfo("pt-BR")));

            CreateMap<RedeSocialViewModel, RedeSocial>()
              .AfterMap((x, y) => x.EventoId = y.EventoId)
              .AfterMap((x, y) => x.Id = y.Id)
              .AfterMap((x, y) => x.Nome = y.Nome)
              .AfterMap((x, y) => x.PalestranteId = y.PalestranteId)
              .AfterMap((x, y) => x.Url = y.Url);
            
        }
    }
}