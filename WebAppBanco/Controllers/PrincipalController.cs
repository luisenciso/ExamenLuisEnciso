using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppBanco.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(Datos.Models.Seguridad.Sesion ses)
        {
            ses = HttpContext.Session.Get<Datos.Models.Seguridad.Sesion>("sesion");
            return View(ses);
        }
    }
}
