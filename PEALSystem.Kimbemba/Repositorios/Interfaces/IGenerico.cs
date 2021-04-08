using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Repositorios.Interfaces
{
    public interface IGenerico<T>
    {
        Task Inserir(T obj);
        void Alterar(T obj);
        void Remover(T obj);
        Task<ICollection<T>> ListarTodos();
        Task<T> BuscarPorId(int id);
        Task<ICollection<T>> Listar(Expression<Func<T, bool>> predicate = null);
    }
}
