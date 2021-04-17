using PEALSystem.Kimbemba.Dominio.Dtos;
using PEALSystem.Kimbemba.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Dominio.Interfaces
{
    public interface ICodigoBarraServico
    {
        Task<CodigoBarra> Gerar(GerarCodigoBarra obj);
        CodigoBarra Remover(CodigoBarra obj);
        Task<CodigoBarra> RemoverTodos();
        Task<ICollection<CodigoBarra>> ListarTodos();
        Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null);
        Task<CodigoBarra> BuscarPorCodigo(string codigo);
        Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN);
    }
}
