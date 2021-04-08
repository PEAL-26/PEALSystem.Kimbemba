using PEALSystem.Kimbemba.SeedWorks.Interfaces;

namespace PEALSystem.Kimbemba.SeedWorks
{
    public class Resultado : IResultado
    {
        public Resultado()
        {

        }

        public Resultado(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
