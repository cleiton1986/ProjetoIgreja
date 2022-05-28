using System;
using System.Threading.Tasks;
using AutoMapper;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Application.Model;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class EventoApp : IEventoApp
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;
        public EventoApp(IEventoRepository eventoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _eventoRepository = eventoRepository;
        }
        public async Task<EventoViewModel[]> GetAllEventosByAsync(bool includePalestrantes)
        {
            EventoViewModel[] eventoViewModeL = null;
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByAsync(includePalestrantes);
                if (eventos == null) return null;

                 eventoViewModeL = _mapper.Map<EventoViewModel[]>(eventos);
                return eventoViewModeL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoViewModel[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                EventoViewModel[] eventoViewModeL = null;
                if (!string.IsNullOrWhiteSpace(tema))
                {
                    var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);
                    eventoViewModeL = _mapper.Map<EventoViewModel[]>(eventos);
                }

                return eventoViewModeL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
        public EventoViewModel GetEventoById(int enventoId, bool includeEndereco)
        {
            var eventoViewModel = new EventoViewModel();
            try
            {
                if (enventoId > 0){
                   var envento = _eventoRepository.GetEventoById(enventoId, includeEndereco);
                   eventoViewModel = _mapper.Map<EventoViewModel>(envento);
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return eventoViewModel;
        }
        public async Task<EventoViewModel> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            var eventoViewModel = new EventoViewModel();
            try
            {
                if (eventoId > 0)
                {
                    var evento =  await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);
                    eventoViewModel = _mapper.Map<EventoViewModel>(evento);
                }
                    
                return eventoViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoViewModel> AddEvento(EventoViewModel model)
        {
            var eventoViewModel = new EventoViewModel();
            try
            {
                if (model != null)
                {
                    var evento = _mapper.Map<Evento>(model);
                    if (await _eventoRepository.InserirAsync(evento))
                    {
                         var eventoRetorno = await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                        eventoViewModel = _mapper.Map<EventoViewModel>(eventoRetorno);
                        return eventoViewModel;
                    }       
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
        public async Task<EventoViewModel> AleterarEvento(EventoViewModel model)
        {
            var eventoViewModel = new EventoViewModel();
            try
            {
                
                if (model != null)
                {
                    var evento = await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                    if (evento == null)
                    {
                        throw new Exception("O evento para exluir não foi encontrado");
                    }
                    else
                    {

                        model.Id = evento.Id;
                         var envento = _mapper.Map<Evento>(model);

                        if (await _eventoRepository.Alterar(envento)){
                            var eventos =  await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                            eventoViewModel = _mapper.Map<EventoViewModel>(eventos);
                        }
  
                    }
                }

                return eventoViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ExcluirEvento(int eventoId)
        {
            try
            {
                if (eventoId > 0)
                {
                    var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                    if (evento == null)
                        throw new Exception("O evento para exluir não foi encontrado");
                    else
                        return await _eventoRepository.Excluir(evento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public async Task<bool> ExcluirEventoRange(EventoViewModel[] model)
        {
            
            try
            {
                if (model != null){
                   var eventos = _mapper.Map<Evento[]>(model);
                   return await _eventoRepository.ExcluirRange(eventos);
                }
                   
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