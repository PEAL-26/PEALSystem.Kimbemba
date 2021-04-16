using Microsoft.Extensions.DependencyInjection;
using PEALSystem.Kimbemba.Repositorios;
using PEALSystem.Kimbemba.Repositorios.Interfaces;
using PEALSystem.Kimbemba.Servicos;
using PEALSystem.Kimbemba.Servicos.Interfaces;

namespace PEALSystem.Kimbemba.Configuracoes
{
    public class NativeInjetorMapping
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<Contexto>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped(typeof(IGenerico<>), typeof(GenericoRepositorio<>));

            service.AddScoped<ICodigoBarraRepositorio, CodigoBarraRepositorio>();
            service.AddScoped<ICodigoBarraServico, CodigoBarraServico>();
        }
    }
}
