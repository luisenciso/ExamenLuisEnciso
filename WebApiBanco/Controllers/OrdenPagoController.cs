using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiBanco.Controllers
{
    [Route("api/[controller]")]
    public class OrdenPagoController : Controller
    {
        Datos.Models.ConstructorContext conscontext;

        // POST api/values
        [HttpPost]
        public IQueryable<Datos.Models.OrdenPago> Post()
        {
            conscontext = new Datos.Models.ConstructorContext();
            List<Datos.Models.OrdenPago> ordnspg = Datos.Models.ConstructorContext.banco.OrdenPagos();
            return ordnspg.AsQueryable();
        }

    }
}
