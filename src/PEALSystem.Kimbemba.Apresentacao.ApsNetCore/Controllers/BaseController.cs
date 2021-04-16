using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using PEALSystem.Kimbemba.SeedWorks;
using System.Collections.Generic;

namespace PEALSystem.Kimbemba.Controllers
{
    public class BaseController : Controller
    {
        public bool EstadoModelo(IReadOnlyCollection<Notification> notifications)
        {
            if (notifications == null || notifications.Count == 0) return false;
            
            foreach (var erro in notifications)
            {
                ModelState.AddModelError(erro.Key, erro.Message);
            }

            return true;
        }
        
    }
}
