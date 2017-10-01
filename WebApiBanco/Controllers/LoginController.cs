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
        public Datos.Models.Seguridad.Sesion Post(string vusuario,string vcontrasenia)
        {
            Datos.Models.Seguridad.Sesion ses = new Datos.Models.Seguridad.Sesion();
            conscontext = new Datos.Models.ConstructorContext();            
            Datos.Models.Seguridad.Usuario  vuser = Datos.Models.ConstructorContext.usuarios.Find(x => x.usuario == vusuario && x.Contrasenia == vcontrasenia);
            if (vuser != null)
            {
                ses.msg = "OK";
                ses.user = vuser;
                ses.roles = vuser.perfil.roles;
            }
            else
            {
                ses.msg = "NO EXISTE";
                ses.user = null;
                ses.roles = null;
            }            
            return ses;
        }


    }
}
