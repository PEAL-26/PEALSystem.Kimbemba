using System.ComponentModel.DataAnnotations;

namespace PEALSystem.Kimbemba.ViewModels
{
    public class GerarCodigoBarraViewModel
    {
        [Required]
        public int Quantidade { get; set; }
    }
}
