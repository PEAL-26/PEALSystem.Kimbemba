using Microsoft.EntityFrameworkCore;
using PEALSystem.Kimbemba.Configuracoes;
using PEALSystem.Kimbemba.Models;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Repositorios
{
    public class CodigoBarraRepositorio : GenericoRepositorio<CodigoBarra>, ICodigoBarraRepositorio
    {
        public CodigoBarraRepositorio(Contexto contextoDatabase) : base(contextoDatabase)
        {
        }

        public async Task<CodigoBarra> BuscarPorCodigo(string codigo)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c=> c.Codigo == codigo);
        }

        public  async Task<CodigoBarra> BuscarPorCodigoAEN(string codigoAEN)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c=>c.CodigoAEN == codigoAEN);
        }
    }
}
