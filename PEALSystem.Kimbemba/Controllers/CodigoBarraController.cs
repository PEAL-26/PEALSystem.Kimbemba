using Microsoft.AspNetCore.Mvc;
using PEALSystem.Kimbemba.Servicos.Interfaces;
using PEALSystem.Kimbemba.ViewModels;
using System.Threading.Tasks;

namespace PEALSystem.Kimbemba.Controllers
{
    public class CodigoBarraController : Controller
    {
        private readonly ICodigoBarraServico _codigoBarraServico;
        public CodigoBarraController(ICodigoBarraServico codigoBarraServico)
        {
            _codigoBarraServico = codigoBarraServico;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _codigoBarraServico.ListarTodos());
        }

        public IActionResult GerarCodigoBarra()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> GerarCodigoBarra(GerarCodigoBarraViewModel obj)
        {
            try
            {

                if (obj.Quantidade <= 0) {
                    ModelState.AddModelError("Quantidade","A quantidade tem que ser superior a zero (0).");
                    return View(obj);
                }
            
            await _codigoBarraServico.GerarCodigoBarra(obj.Quantidade);
                        
            return RedirectToAction(nameof(Index));

            }
            catch (System.Exception)
            {

                return View("Error");
            }
        }

        
    }
}
