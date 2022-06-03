using System;
using System.Collections.Generic;
using AutoMapper;
using IgrejaJdLilah.Application.Model;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.API.Dtos.Helpers
{
    public class ViewModelParaEntidade : Profile
    {
        public ViewModelParaEntidade()
        {

            CreateMap<Evento, EventoViewModel>()
              .AfterMap((x, y) => x.DataEvento = !string.IsNullOrEmpty(y.DataEvento) ? (DateTime?)null : Convert.ToDateTime(y.DataEvento))
              .AfterMap((x, y) => x.Email = y.Email)
              .AfterMap((x, y) => x.Id = y.Id)
              .AfterMap((x, y) => x.ImagemURL = y.ImagemURL)
              .AfterMap((x, y) => x.Local = y.Local)
              .AfterMap((x, y) => x.Observacao = y.Observacao)
              .AfterMap((x, y) => x.QtdPessoas = y.QtdPessoas)
              .AfterMap((x, y) => x.Telefone = y.Telefone)
              .AfterMap((x, y) => x.Tema = y.Tema);
             

            CreateMap<Endereco, EnderecoViewModel>()
             .AfterMap((x, y) => x.Cep = y.Cep)
             .AfterMap((x, y) => x.Complemento = y.Complemento)
             .AfterMap((x, y) => x.Id = y.Id)
             .AfterMap((x, y) => x.Local = y.Local)
             .AfterMap((x, y) => x.Numero = y.Numero);

            CreateMap<Lote, LoteViewModel>()
              .AfterMap((x, y) => x.EventoId = y.EventoId)
              .AfterMap((x, y) => x.Id = y.Id)
              .AfterMap((x, y) => x.Nome = y.Nome)
              .AfterMap((x, y) => x.Quantidade = y.Quantidade)
              .AfterMap((x, y) => x.DataFim = !string.IsNullOrEmpty(y.DataFim) ? (DateTime?)null : Convert.ToDateTime(y.DataFim))
              .AfterMap((x, y) => x.DataInicio = !string.IsNullOrEmpty(y.DataInicio) ? (DateTime?)null : Convert.ToDateTime(y.DataInicio));
             

            CreateMap<PalestranteEvento, PalestranteEventoViewModel>()
              .AfterMap((x, y) => x.EventoId = y.EventoId)
              .AfterMap((x, y) => x.PalestranteId = y.PalestranteId);


            CreateMap<Palestrante, PalestranteViewModel>()
              .AfterMap((x, y) => x.Email = y.Email)
              .AfterMap((x, y) => x.Denominacao = y.Denominacao)
              .AfterMap((x, y) => x.EnderecoId = y.EnderecoId)
              .AfterMap((x, y) => x.FazParteMesmaDenominacao = y.FazParteMesmaDenominacao)
              .AfterMap((x, y) => x.Id = y.Id)
              .AfterMap((x, y) => x.ImagemUrl = y.ImagemUrl)
              .AfterMap((x, y) => x.MiniCurriculo = y.MiniCurriculo)
              .AfterMap((x, y) => x.DataCadastro =  Convert.ToDateTime(y.DataCadastro));
             
             
            CreateMap<RedeSocial, RedeSocialViewModel>()
              .AfterMap((x, y) => x.EventoId = y.EventoId)
              .AfterMap((x, y) => x.Id = y.Id)
              .AfterMap((x, y) => x.Nome = y.Nome)
              .AfterMap((x, y) => x.PalestranteId = y.PalestranteId)
              .AfterMap((x, y) => x.Url = y.Url);

        }
        
    }
}