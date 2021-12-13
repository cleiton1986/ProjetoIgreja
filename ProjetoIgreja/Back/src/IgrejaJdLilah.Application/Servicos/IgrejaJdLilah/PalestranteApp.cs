using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class PalestranteApp: IPalestrantesApp
    {
        private readonly IPalestranteRepository _palestranteRepository;
        public PalestranteApp( IPalestranteRepository palestranteRepository)
        {
            _palestranteRepository = palestranteRepository;
        }
        public async Task<Palestrante[]> GetAllPalestrantesByDenominacaoAsync(string denominacao, bool include)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(denominacao))
                   return await _palestranteRepository.GetAllPalestrantesByDenominacaoAsync(denominacao, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        public async Task<Palestrante[]> GetAllPalestrantesByMesmaDenominacaoAsync(bool mesmaDenominacao, bool include)
        {
            try
            {
                return await _palestranteRepository.GetAllPalestrantesByMesmaDenominacaoAsync(mesmaDenominacao, include);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante[]> GetAllPalestrantesByAsync(bool include)  
        {
            try
            {
                return await _palestranteRepository.GetAllPalestrantesByAsync(include);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool include)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(nome))
                   return await _palestranteRepository.GetAllPalestrantesByNomeAsync(nome, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        public Palestrante GetPalestranteById(int palestrantesId, bool include)
        {
            try
            {
                if(palestrantesId > 0)
                   return  _palestranteRepository.GetPalestranteById(palestrantesId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestrantesId, bool include)
        {
            try
            {
                if(palestrantesId > 0)
                   return  await _palestranteRepository.GetPalestranteByIdAsync(palestrantesId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<bool> InseriAsync(Palestrante palestrante)
        {
            try
            {
                if(palestrante != null)
                   return await _palestranteRepository.InserirAsync(palestrante);
                else
                 throw new Exception("O palestrante para inserir não foi encontrado");
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante> AddeEvento(Palestrante model)
        {
            try
            {
                if(model != null)
                {
                   if(await _palestranteRepository.InserirAsync(model))
                      return await _palestranteRepository.GetPalestranteByIdAsync(model.Id, false);
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
        public async Task<bool> ExcluirPalestrante(int palestranteId, bool include)
        {
            try
            {
                if(palestranteId > 0 )
                {
                     var palestrante =  await  _palestranteRepository.GetPalestranteByIdAsync(palestranteId, include);
                     if(palestrante == null)
                         throw new Exception("O palestrante para exluir não foi encontrado");
                     else
                       return await _palestranteRepository.Excluir(palestrante);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public async Task<bool> ExcluirPalestranteRange(Palestrante[] palestrante)
        {
            try
            {
                if(palestrante != null)
                   return await _palestranteRepository.ExcluirRange(palestrante);
                else
                 throw new Exception("O palestrante para exluir em lote não foi encontrado");
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante> AleterarEvento(Palestrante model)
        {
            try
            {
               if(model != null)
                {
                    var evento =  await _palestranteRepository.GetPalestranteByIdAsync(model.Id, false);
                    if(evento == null)
                    {
                       throw new Exception("O evento para exluir não foi encontrado");
                    }
                    else
                    {
                        model.Id = evento.Id;
                        if(await _palestranteRepository.Alterar(model))
                           return  await _palestranteRepository.GetPalestranteByIdAsync(model.Id, false);
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