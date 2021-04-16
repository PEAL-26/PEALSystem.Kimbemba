using PEALSystem.Kimbemba.Configuracoes;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;

        public UnitOfWork(Contexto contexto) => _contexto = contexto;

        public async Task<bool> Commit() => (await _contexto.SaveChangesAsync()) > 0;

        public void Dispose() => _contexto.Dispose();

        public Task Rollback() => Task.CompletedTask;
    }
}
