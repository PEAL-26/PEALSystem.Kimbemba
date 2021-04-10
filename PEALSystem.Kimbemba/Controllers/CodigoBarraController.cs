using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PEALSystem.Kimbemba.Servicos.Interfaces;
using PEALSystem.Kimbemba.ViewModels;
using System.IO;
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
            if (string.IsNullOrWhiteSpace(codigo)) return NotFound();

            var codigoBarra = await _codigoBarraServico.BuscarPorCodigo(codigo);

            if (codigoBarra == null) return NotFound();

            return View(codigoBarra);
        }

        public async Task<IActionResult> Remove(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return NotFound();

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
            if (resultado.Success) 
                return RedirectToAction(nameof(Index));
            return View();
        }

        public FileResult ExportarPDF()
        {
            using var doc = new PdfDocument();
            var page = doc.AddPage();
            page.Size = PageSize.A4;
            page.Orientation = PageOrientation.Portrait;

            var graphic = XGraphics.FromPdfPage(page);
            var corFonte = XBrushes.Black;
            var textFormatter = new XTextFormatter(graphic);
            var fonteOrganizacao = new XFont("Arial", 10);
            var fontDecricao = new XFont("Arial", 8, XFontStyle.BoldItalic);
            var tituloDetalhes = new XFont("Arial", 14, XFontStyle.BoldItalic);
            var fonteDetalheDecricao = new XFont("Arial", 7);

            var qtdPaginas = doc.PageCount;
            textFormatter.DrawString(qtdPaginas.ToString(),
                new XFont("Arial", 10), corFonte,
                new XRect(578, 825, page.Width, page.Height));

            //var logo = "";// "c:\\logo.jpg";
            //XImage imagem = XImage.FromFile(logo);
            //graphic.DrawImage(imagem, 20, 5, 300, 50);

            using MemoryStream stream = new MemoryStream();
            var contentType = "application/pdf";
            doc.Save(stream, false);
            var nomeArquivo = "CodigosBarras.pdf";

            return File(stream.ToArray(), contentType, nomeArquivo);
        }

    }
}
