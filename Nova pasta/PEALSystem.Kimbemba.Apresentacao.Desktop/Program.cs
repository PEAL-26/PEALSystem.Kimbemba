using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEALSystem.Kimbemba.Apresentacao.Desktop
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            RegisterServices(services);

            using var serviceProvider = services.BuildServiceProvider();
            var _frmHome = serviceProvider.GetRequiredService<frmHome>();
            Application.Run(_frmHome);
        }

        private static void RegisterServices(IServiceCollection service)
        {
            service.AddTransient<frmHome>();

            service.AddTransient<frmConfirmacao>();
            service.AddTransient<frmMensagem>();

        }
    }
}
