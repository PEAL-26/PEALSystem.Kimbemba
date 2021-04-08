using PEALSystem.Kimbemba.Models;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Servicos.Interfaces
{
    public interface ICodigoBarraServico : IGenerico<CodigoBarra>
    {
        Task GerarCodigoBarra(int qtd);
        Task<CodigoBarra> BuscarPorCodigo(string codigo);
        Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN);
    }
}
