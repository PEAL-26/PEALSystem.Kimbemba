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
        public async Task<IActionResult> GerarCodigoBarra(GerarCodigoBarraViewModel obj)
        {
                var codigoBarra = await _codigoBarraServico.Gerar(obj);

                if (codigoBarra.Success) return RedirectToAction(nameof(Index));
              
            return View(obj);

        }

        public async Task<IActionResult> Detalhes(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))  return NotFound();

            var codigoBarra = await _codigoBarraServico.BuscarPorCodigo(codigo);

            if (codigoBarra == null) return NotFound();

            return View(codigoBarra);
        }

        public async Task<IActionResult> Remove(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))  return NotFound();

            var codigoBarra = await _codigoBarraServico.BuscarPorCodigo(codigo);

            if (codigoBarra == null) return NotFound();

            return View(codigoBarra);
        }

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(string codigo)
        {
            var codigoBarra = await _codigoBarraServico.BuscarPorCodigo(codigo);

            var resultado = await _codigoBarraServico.Remover(codigoBarra);

            if (resultado.Success) return RedirectToAction(nameof(Index));

            return View(codigoBarra);
        }

        public IActionResult RemoveAll()
        {            
            return View();
        }

        [HttpPost, ActionName("RemoveAll")]
        public async Task<IActionResult> RemoveAllConfirmed()
        {
            var resultado = await _codigoBarraServico.RemoverTodos();

            if (resultado.Success) return RedirectToAction(nameof(Index));

            return View();
        }



    }
}
