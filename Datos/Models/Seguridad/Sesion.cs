using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models.Seguridad
{
    public class Sesion
    {
        public string msg { get; set; }
        public Usuario user { get; set; }
        public List<Rol> roles { get; set; }
        
        public Sesion() { }

    }
}
