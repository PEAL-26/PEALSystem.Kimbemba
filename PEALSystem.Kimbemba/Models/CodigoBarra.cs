using Flunt.Notifications;
using System;

namespace PEALSystem.Kimbemba.Models
{
    public class CodigoBarra :  Notifiable<Notification>
    {
        public string Codigo { get; private set; }   
        public string CodigoAEN { get; private set; }
        public int Numero { get; private set; }
        public DateTime Data { get; private set; }

        public CodigoBarra(string codigo, string codigoAEN, int numero)
        {
            Codigo = codigo;
            CodigoAEN = codigoAEN;
            Numero = numero;
            Data = DateTime.Now;
        } 

        public void Validar()
        {

        }
    }
}
