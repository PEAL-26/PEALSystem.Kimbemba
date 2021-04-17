using Microsoft.Extensions.DependencyInjection;
using PEALSystem.Kimbemba.Aplicacao.Aplicacao;
using PEALSystem.Kimbemba.Aplicacao.Intertfaces;
using PEALSystem.Kimbemba.Configuracoes;
using PEALSystem.Kimbemba.Dominio.Interfaces;
using PEALSystem.Kimbemba.Dominio.Servicos;
using PEALSystem.Kimbemba.Infra.Data.Repositorios;
using PEALSystem.Kimbemba.Repositorios.Interfaces;

namespace PEALSystem.Kimbemba.Infra.CrossCutting.IoC
{
    public class NativeInjetorMapping
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<Contexto>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped(typeof(IGenerico<>), typeof(GenericoRepositorio<>));

            service.AddScoped<ICodigoBarraApp,CodigoBarraApp>();
            service.AddScoped<ICodigoBarraRepositorio, CodigoBarraRepositorio>();
            service.AddScoped<ICodigoBarraServico, CodigoBarraServico>();
        }
    }
}
