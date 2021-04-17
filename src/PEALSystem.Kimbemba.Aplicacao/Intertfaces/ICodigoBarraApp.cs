using PEALSystem.Kimbemba.Aplicacao.ViewModels;
using PEALSystem.Kimbemba.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Aplicacao.Intertfaces
{
    public interface ICodigoBarraApp
    {
        Task<bool> Gerar(GerarCodigoBarraViewModel obj);
        Task<CodigoBarra> Remover(CodigoBarra obj);
        Task<bool> RemoverTodos();
        Task<ICollection<CodigoBarra>> ListarTodos();
        Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null);
        Task<CodigoBarra> BuscarPorCodigo(string codigo);
        Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN);
    }
}
