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
    public class CodigoBarraRepositorio : ICodigoBarraRepositorio
    {
        private readonly Contexto _db;
        protected readonly DbSet<CodigoBarra> DbSet;

        public CodigoBarraRepositorio(Contexto db)
        {
            _db = db;
            DbSet = _db.Set<CodigoBarra>();
        }


        public virtual async Task Inserir(CodigoBarra obj) =>
            await DbSet.AddAsync(obj);

        public async Task<CodigoBarra> BuscarPorCodigo(string codigo) =>
         await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Codigo == codigo);

        public async Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN) =>
             await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.CodigoAEN == codigoAEN);

        public async void RemoverTodos()
        {
            var all = await ListarTodos();
            var codigos = new List<CodigoBarra>();

            foreach (var item in all)
            {
                codigos.Add(item);
            }

            DbSet.RemoveRange(codigos);
        }

        void ICodigoBarraRepositorio.Remover(CodigoBarra obj) =>
            DbSet.Remove(obj);

        public virtual async Task<ICollection<CodigoBarra>> ListarTodos() =>
              await DbSet.AsNoTracking().ToListAsync();

        public async Task<ICollection<CodigoBarra>> Listar(Expression<Func<CodigoBarra, bool>> predicate = null)
        {
            if (predicate != null)
                return await DbSet.AsNoTracking().Where(predicate).ToListAsync();

            return await DbSet.AsNoTracking().ToListAsync();
        }
    }
}
