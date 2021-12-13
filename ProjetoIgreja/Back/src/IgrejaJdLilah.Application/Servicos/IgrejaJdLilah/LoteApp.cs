using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class LoteApp: ILoteApp
    {
        private readonly ILoteRepository _loteRepository;
        public LoteApp(ILoteApp loteApp, ILoteRepository loteRepository)
        {
            _loteRepository = loteRepository;
        }
        public async Task<Lote> GetLoteByIdAsync(int loteId, bool include)
        {
             try
            {
                if(loteId > 0)
                   return await _loteRepository.GetLoteByLoteIdAsync(loteId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Lote[]> GetAllLotesByAsync(bool include)
        {
            try
            {
                return await _loteRepository.GetAllLoteByAsync(include);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public Lote GetLoteById(int loteId, bool include)
        {
           try
            {
                if(loteId > 0)
                   return   _loteRepository.GetLoteById(loteId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Lote[]> GetLotesByIdAsync(int loteId, bool include)
        {
            try
            {
                if(loteId > 0)
                   return  await _loteRepository.GetLotesByIdAsync(loteId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }  
        public async Task<bool> ExcluirLote(int loteId, bool include)
        {
            try
            {
                if(loteId > 0 )
                {
                     var lote = await _loteRepository.GetLoteByLoteIdAsync(loteId, include);
                     if(lote == null)
                         throw new Exception("O lote para exluir não foi encontrado");
                     else
                        return await _loteRepository.Excluir(lote);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public async Task<bool> ExcluirLoteRange(Lote[] model)
        {
            try
            {
                if(model != null)
                   return  await _loteRepository.ExcluirRange(model);
                else
                 throw new Exception("O lote para exluir em lote não foi encontrado");
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Lote> AlterarLote(Lote model)
        {
            try
            {
               if(model != null)
                {
                    var evento =  await _loteRepository.GetLoteByLoteIdAsync(model.Id, false);
                    if(evento == null)
                    {
                       throw new Exception("O lote para exluir não foi encontrado");
                    }
                    else
                    {
                        model.Id = evento.Id;
                        if(await _loteRepository.Alterar(model))
                           return  await _loteRepository.GetLoteByLoteIdAsync(model.Id, false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Lote> AddLote(Lote model)
        {
            try
            {
                if(model != null)
                {
                   if(await _loteRepository.InserirAsync(model))
                      return await _loteRepository.GetLoteByLoteIdAsync(model.Id, false);
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

    }
}