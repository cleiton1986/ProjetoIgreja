using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface IPalestrantesEventoApp
    {
        Task<PalestranteEvento[]>GetAllPalestranteEventoAllAsync(bool include);
        Task<PalestranteEvento[]>GetPalestranteEventoByPalestranteIdAsync(int palestranteId, bool includePalestrante);
        Task<PalestranteEvento[]>GetPalestranteEventoByIdEventoAsync(int eventoId, bool includeEvento);
    }
}