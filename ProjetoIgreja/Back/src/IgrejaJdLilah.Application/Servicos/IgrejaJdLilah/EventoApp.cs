using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class EventoApp : IEventoApp
    {
        private readonly IEventoRepository _eventoRepository;
        public EventoApp(IEventoRepository eventoRepository) 
        {
            _eventoRepository = eventoRepository;        
        }
        public async Task<Evento[]> GetAllEventosByAsync(bool includePalestrantes)
        {
            try
            {
                var eventos =  await _eventoRepository.GetAllEventosByAsync(includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(tema))
                   return await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        public async Task<string[]> GetAllEventosImagensByAsync()
        {
            try
            {
                var imagens = await _eventoRepository.GetAllEventosImagensByAsync();
                if (imagens == null) return null;

                return imagens;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Evento GetEventoById(int enventoId, bool includeEndereco)
        {
            var envento = new Evento();
            try
            {
                if(enventoId > 0 )
                   envento =  _eventoRepository.GetEventoById(enventoId, includeEndereco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return envento;
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            try
            {
                if(eventoId > 0)
                   return await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                if(model != null)
                {
                   if(await _eventoRepository.InserirAsync(model))
                      return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                   else
                      throw new Exception("O evento para inserir não foi encontrado");
                } 
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }

            return null;

        }
        public async Task<Evento> AleterarEvento(Evento model)
        {
            try
            {
               if(model != null)
                {
                    var evento =  await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                    if(evento == null)
                    {
                       throw new Exception("O evento para exluir não foi encontrado");
                    }
                    else
                    {
                        model.Id = evento.Id;
                        if(await _eventoRepository.Alterar(model))
                           return  await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                    }
                      
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<bool> ExcluirEvento(int eventoId)
        {
             try
            {
                if(eventoId > 0 )
                {
                     var evento = await  _eventoRepository.GetEventoByIdAsync(eventoId, false);
                     if(evento == null)
                         throw new Exception("O evento para exluir não foi encontrado");
                     else
                        return  await _eventoRepository.Excluir(evento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public async Task<bool> ExcluirEventoRange(Evento[] model)
        {
            try
            {
                if(model != null)
                   return await _eventoRepository.ExcluirRange(model);
                else
                   throw new Exception("O evento para exluir em lote não foi encontrado");
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

    }
}