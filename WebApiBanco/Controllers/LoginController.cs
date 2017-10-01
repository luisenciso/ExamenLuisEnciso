using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiBanco.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        Models.ConstructorContext conscontext;


        // POST api/values
        [HttpPost]
        public string Post(string vusuario,string vcontrasenia)
        {
            string result = string.Empty;
            conscontext = new Models.ConstructorContext();            
            Models.Seguridad.Usuario  vuser = Models.ConstructorContext.usuarios.Find(x => x.usuario == vusuario && x.Contrasenia == vcontrasenia);
            if (vuser != null)
            {
                result = "OK";
            }
            else
            {
                result = "NO EXISTE";
            }           
            return result;
        }


    }
}
