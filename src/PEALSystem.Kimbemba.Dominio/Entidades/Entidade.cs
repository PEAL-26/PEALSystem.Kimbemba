using Flunt.Notifications;
using System;

namespace PEALSystem.Kimbemba.Dominio.Entidades
{
    public abstract class Entidade : Notifiable<Notification>
    {
        public int Id { get; set; }

        public abstract void Validar();
    }
}
