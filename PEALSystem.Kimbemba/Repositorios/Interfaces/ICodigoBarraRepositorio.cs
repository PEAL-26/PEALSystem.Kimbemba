using PEALSystem.Kimbemba.Models;
using System;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Repositorios.Interfaces
{
    public interface ICodigoBarraRepositorio : IGenerico<CodigoBarra>
    {
        Task<CodigoBarra> BuscarPorCodigo(string codigo);
        Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN);
    }
}
