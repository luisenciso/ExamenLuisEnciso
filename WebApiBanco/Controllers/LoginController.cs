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

        Datos.Models.ConstructorContext conscontext;

        // POST api/values
        [HttpPost]
        public string Post(string vusuario,string vcontrasenia)
        {
            string result = string.Empty;
            Datos.Models.Seguridad.Sesion ses = new Datos.Models.Seguridad.Sesion();
            conscontext = new Datos.Models.ConstructorContext();            
            Datos.Models.Seguridad.Usuario  vuser = Datos.Models.ConstructorContext.usuarios.Find(x => x.usuario == vusuario && x.Contrasenia == vcontrasenia);
            ses.user = vuser;
            ses.roles = vuser.perfil.roles;
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
