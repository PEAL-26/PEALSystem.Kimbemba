using PEALSystem.Kimbemba.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Repositorios.Interfaces
{
    public interface ICodigoBarraRepositorio
    {
        Task Inserir(CodigoBarra obj);
        void Remover(CodigoBarra obj);
        void RemoverTodos();
        Task<ICollection<CodigoBarra>> ListarTodos();
        Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null);
        Task<CodigoBarra> BuscarPorCodigo(string codigo);
        Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN);
        Task<int> BuscarUltimoNumeroPorData(DateTime data);

    }
}
