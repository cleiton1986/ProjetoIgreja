using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class ContratoApp : IContatoApp
    {
        private readonly IContatoRepository _contatoRepository;
        public ContratoApp(IContatoRepository contatoRepository) 
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Contato[]> GetAllContatoByDenominacaoAsync(string denominacao, bool include)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(denominacao))
                   return await _contatoRepository.GetAllContatoByDenominacaoAsync(denominacao, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        public async Task<Contato> GetContatoByContatoIdAsync(int contatoId, bool include)
        {
            try
            {
                if(contatoId > 0)
                   return await _contatoRepository.GetContatoByContatoIdAsync(contatoId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Contato> GetContatoByEmailAsync(string email, bool include)
        {
             try
            {
                if(!string.IsNullOrWhiteSpace(email))
                   return await _contatoRepository.GetContatoByEmailAsync(email, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Contato[]> GetContatosAllAsync(bool include)
        {
            try
            {
                return await _contatoRepository.GetContatosAllAsync(include);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ExcluirContato(int contatoId)
        {
             try
            {
                if(contatoId > 0 )
                {
                     var contato =  await _contatoRepository.GetContatoByContatoIdAsync(contatoId, false);
                     if(contato == null)
                         throw new Exception("O evento para exluir não foi encontrado");
                     else
                      return await _contatoRepository.Excluir(contato);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public Contato GetContatoByContatoId(int contatoId, bool include)
        {
            var contato = new Contato();
            try
            {
                if(contatoId > 0 )
                   contato =  _contatoRepository.GetContatoByContatoId(contatoId, include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return contato;
        }
        public async Task<Contato> AddContato(Contato model)
        {
            try
            {
                if(model != null)
                {
                   if(await _contatoRepository.InserirAsync(model))
                      return await _contatoRepository.GetContatoByContatoIdAsync(model.Id, true);
                   else
                      throw new Exception("O contato para inserir não foi encontrado");
                } 
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }

            return null;
        }
        public async Task<Contato> AlterarContato(Contato model)
        {
            try
            {
               if(model != null)
                {
                    var contato =  await _contatoRepository.GetContatoByContatoIdAsync(model.Id, false);
                    if(contato == null)
                    {
                       throw new Exception("O contato para exluir não foi encontrado");
                    }
                    else
                    {
                        model.Id = contato.Id;
                        if(await _contatoRepository.Alterar(model))
                           return  await _contatoRepository.GetContatoByContatoIdAsync(model.Id, false);
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