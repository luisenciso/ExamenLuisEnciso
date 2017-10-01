using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models.Seguridad
{
    public class Perfil
    {
        public String Nombre { get; set; }
        public List<Rol> roles { get; set; }
    }
}
