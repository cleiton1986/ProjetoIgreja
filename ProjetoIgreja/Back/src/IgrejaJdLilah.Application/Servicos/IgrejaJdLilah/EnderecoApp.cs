using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class EnderecoApp: IEnderecoApp
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoApp(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<Endereco[]> GetAllEnderecoByAsync()
        {

            try
            {
                return await _enderecoRepository.GetAllEnderecoByAsync();
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }

        }
        public async Task<Endereco[]> GetAllEnderecosByCepAsync(string cep)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(cep))
                  return await _enderecoRepository.GetAllEnderecosByCepAsync(cep);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public Endereco GetEnderecoById(int enderecoId)
        {
            var endereco = new Endereco();
            try
            {
                if(enderecoId > 0)
                   endereco =  _enderecoRepository.GetEnderecoById(enderecoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return endereco;
        }
        public async Task<Endereco> GetEnderecoByIdAsync(int enderecoId)
        {
            try
            {
                if(enderecoId > 0)
                  return await _enderecoRepository.GetEnderecoByEventoIdAsync(enderecoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<Endereco> GetEventoByIdAsync(int eventoId)
        {
            try
            {
                if(eventoId > 0)
                   return await _enderecoRepository.GetEnderecoByEventoIdAsync(eventoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        } 
        public async Task<Endereco> AddEnderco(Endereco model)
        {
            try
            {
                if(model != null)
                {
                   if(await _enderecoRepository.InserirAsync(model))
                      return await _enderecoRepository.GetEnderecoByIdAsync(model.Id);
                   else
                      throw new Exception("O endereco para inserir não foi encontrado");
                } 
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }

            return null;
        }
        public async Task<Endereco> AlterarEndereco(Endereco model)
        {
             try
            {
               if(model != null)
                {
                    var evento =  await _enderecoRepository.GetEnderecoByIdAsync(model.Id);
                    if(evento == null)
                    {
                       throw new Exception("O endereço para exluir não foi encontrado");
                    }
                    else
                    {
                        model.Id = evento.Id;
                        if(await _enderecoRepository.Alterar(model))
                           return  await _enderecoRepository.GetEnderecoByIdAsync(model.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<bool> ExcluirEndereco(int enderecoId)
        {
            try
            {
                if(enderecoId > 0)
                {
                   var endereco =  _enderecoRepository.GetEnderecoById(enderecoId);
                    return await _enderecoRepository.Excluir(endereco);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        public async Task<bool> ExcluirEnderecoRange(Endereco[] endereco)
        {
            try
            {
                if(endereco != null)
                   return await _enderecoRepository.ExcluirRange(endereco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

    }
 }