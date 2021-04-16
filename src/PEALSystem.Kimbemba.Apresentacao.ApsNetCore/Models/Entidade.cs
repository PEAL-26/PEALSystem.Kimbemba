using Flunt.Notifications;
using System;

namespace PEALSystem.Kimbemba.Models
{
    public abstract class Entidade : Notifiable<Notification>
    {
        public int Id { get; set; }

        public abstract void Validar();
    }
}
