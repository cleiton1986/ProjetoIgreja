using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Domain.Repository.Contrato
{
    public interface IPalestranteEventoRepository : IRepositoryBase<PalestranteEvento>
    {
        Task<PalestranteEvento[]>GetAllPalestranteEventoAllAsync(bool include = false);
        Task<PalestranteEvento[]>GetPalestranteEventoByPalestranteIdAsync(int palestranteId, bool includePalestrante);
        Task<PalestranteEvento[]>GetPalestranteEventoByIdEventoAsync(int eventoId, bool includeEvento);
    }
}