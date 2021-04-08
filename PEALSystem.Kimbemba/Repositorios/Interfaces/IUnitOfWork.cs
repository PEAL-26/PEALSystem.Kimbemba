using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Repositorios.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
