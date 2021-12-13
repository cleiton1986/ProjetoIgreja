using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class RedeSocialApp: IRedeSocialApp
    {
        private readonly IRedeSocialRepository _redeSocialRepository;
        public RedeSocialApp(IRedeSocialRepository redeSocialRepository) 
        {
            _redeSocialRepository = redeSocialRepository;
        }
        public async Task<RedeSocial[]> GetAllRedeSocialAllAsync(bool includeEventosPalestrentes)
        {
            try
            {
                return await _redeSocialRepository.GetAllRedeSocialAllAsync(includeEventosPalestrentes);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<RedeSocial[]> GetAllRedeSocialByNomeAsync(string nome, bool includeEventosPalestrentes)
        {
            try
            {
                return await _redeSocialRepository.GetAllRedeSocialByNomeAsync(nome, includeEventosPalestrentes);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public RedeSocial GetRedeSocialById(int redeSocialId, bool include)
        {
            var redeSocial = new RedeSocial();
            try
            {
                if(redeSocialId > 0 )
                   redeSocial =  _redeSocialRepository.GetRedeSocialById(redeSocialId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return redeSocial;
        }
        public async Task<RedeSocial> GetRedeSocialByRedeSocialIdAsync(int redeSocialId, bool includeEventosPalestrentes)
        {
            try
            {
                if(redeSocialId > 0)
                   return  await _redeSocialRepository.GetRedeSocialByIdAsync(redeSocialId, includeEventosPalestrentes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<RedeSocial[]> GetRedeSocialByIdEventoAsync(int eventoId, bool includeEvento)
        {
            try
            {
                if(eventoId > 0)
                   return  await _redeSocialRepository.GetRedeSocialByIdEventoAsync(eventoId, includeEvento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<RedeSocial[]> GetRedeSocialByPalestranteIdAsync(int palestranteId, bool includePalestrante)
        {
            try
            {
                if(palestranteId > 0)
                   return  await _redeSocialRepository.GetRedeSocialByPalestranteIdAsync(palestranteId, includePalestrante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<bool> ExcluirRedeSocial(int redeSocialId)
        {
            try
            {
                if(redeSocialId > 0 )
                {
                     var redeSocial = await _redeSocialRepository.GetRedeSocialByIdAsync(redeSocialId, false);
                     if(redeSocial == null)
                         throw new Exception("A redeSocial para exluir não foi encontrado");
                     else
                       return await _redeSocialRepository.Excluir(redeSocial);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public async Task<bool> ExcluirRedeSocialRange(RedeSocial[] model)
        {
            try
            {
                if(model != null)
                   return await _redeSocialRepository.ExcluirRange(model);
                else
                 throw new Exception("O redeSocial para exluir em lote não foi encontrado");
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<RedeSocial> AddRedeSocial(RedeSocial model)
        {
            try
            {
                if(model != null)
                {
                   if(await _redeSocialRepository.InserirAsync(model))
                      return await _redeSocialRepository.GetRedeSocialByIdAsync(model.Id, false);
                   else
                      throw new Exception("O rede social para inserir não foi encontrado");
                } 
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }

            return null;
        }
        public async Task<RedeSocial> AleterarEvento(RedeSocial model)
        {
            try
            {
               if(model != null)
                {
                    var evento =  await _redeSocialRepository.GetRedeSocialByIdAsync(model.Id, false);
                    if(evento == null)
                    {
                       throw new Exception("O Rede social para exluir não foi encontrado");
                    }
                    else
                    {
                        model.Id = evento.Id;
                        if(await _redeSocialRepository.Alterar(model))
                           return  await _redeSocialRepository.GetRedeSocialByIdAsync(model.Id, false);
                    }
                      
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}