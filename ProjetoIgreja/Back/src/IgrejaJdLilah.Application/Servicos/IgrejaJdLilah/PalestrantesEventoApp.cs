using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;

namespace IgrejaJdLilah.Application.Servicos.IgrejaJdLilah
{
    public class PalestrantesEventoApp : IPalestrantesEventoApp
    {
        private readonly IPalestranteEventoRepository _palestranteEventoRepository;
        public PalestrantesEventoApp(IPalestranteEventoRepository palestranteEventoRepository)
        {
            _palestranteEventoRepository = palestranteEventoRepository;
        }
        public async Task<PalestranteEvento[]> GetAllPalestranteEventoAllAsync(bool include)
        {
            try
            {
                return await _palestranteEventoRepository.GetAllPalestranteEventoAllAsync(include);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<PalestranteEvento[]> GetPalestranteEventoByIdEventoAsync(int eventoId, bool includeEvento)
        {
            try
            {
                return await _palestranteEventoRepository.GetPalestranteEventoByIdEventoAsync(eventoId, includeEvento);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<PalestranteEvento[]> GetPalestranteEventoByPalestranteIdAsync(int palestranteId, bool includePalestrante)
        {
            try
            {
                return await _palestranteEventoRepository.GetPalestranteEventoByPalestranteIdAsync(palestranteId, includePalestrante);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
    }
}