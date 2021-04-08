using PEALSystem.Kimbemba.Models;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using PEALSystem.Kimbemba.SeedWorks;
using PEALSystem.Kimbemba.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Servicos.Interfaces
{
    public interface ICodigoBarraServico
    {
        Task<Resultado> Gerar(GerarCodigoBarraViewModel obj);
        Task<Resultado> Remover(CodigoBarra obj);
        Task<Resultado> RemoverTodos();
        Task<ICollection<CodigoBarra>> ListarTodos();
        Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null);
        Task<CodigoBarra> BuscarPorCodigo(string codigo);
        Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN);
    }
}
