using Flunt.Notifications;
using System;

namespace PEALSystem.Kimbemba.Dominio.Entidades
{
    public class CodigoBarra : Notifiable<Notification>
    {
        public string Codigo { get; private set; }
        public string CodigoAEN { get; private set; }
        public int Numero { get; private set; }
        public DateTime Data { get; private set; }

        public CodigoBarra()
        {

        }

        public CodigoBarra(string codigo, string codigoAEN, int numero, DateTime data)
        {
            Codigo = codigo;
            CodigoAEN = codigoAEN;
            Numero = numero;
            Data = data;

            Validar();
        }

        public void Validar()
        {
            //if (Codigo.Length != 14) AddNotification(nameof(Codigo), $"{nameof(Codigo)} tem que ser 14 caracteres");

        }
    }
}
