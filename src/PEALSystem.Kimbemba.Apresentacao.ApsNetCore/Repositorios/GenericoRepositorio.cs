using Microsoft.EntityFrameworkCore;
using PEALSystem.Kimbemba.Configuracoes;
using PEALSystem.Kimbemba.Models;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Repositorios
{
    public class GenericoRepositorio<T> : IGenerico<T> where T: class
    {
        private readonly Contexto _db;
        protected readonly DbSet<T> DbSet;

        public GenericoRepositorio(Contexto db)
        {
            _db = db;
            DbSet = _db.Set<T>();
        }

        public virtual async Task Inserir(T obj) =>
            await DbSet.AddAsync(obj);

        public virtual async Task Inserir(ICollection<T> obj) =>
           await DbSet.AddRangeAsync(obj);

        public virtual void Alterar(T obj) =>
             DbSet.Update(obj);

        public virtual void Alterar(ICollection<T> obj) =>
             DbSet.UpdateRange(obj);

        public virtual void Remover(T obj) =>
            DbSet.Remove(obj);

        public virtual void Remover(ICollection<T> obj) =>
            DbSet.RemoveRange(obj);

        public virtual async Task<ICollection<T>> ListarTodos() =>
            await DbSet.AsNoTracking().ToListAsync();

        public async Task<ICollection<T>> Listar(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return await DbSet.AsNoTracking().Where(predicate).ToListAsync();

            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> BuscarPorId(int id) =>
             await DbSet.AsNoTracking().FirstOrDefaultAsync();


        private readonly bool _disposed = false;

        ~GenericoRepositorio() =>
           Dispose();

        public void Dispose()
        {
            if (!_disposed)
                _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
