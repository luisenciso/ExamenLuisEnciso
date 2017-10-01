using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models.Seguridad
{
    public class Usuario
    {
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String usuario { get; set; }
        public String Contrasenia { get; set; }
        public Perfil perfil { get; set; }

        public Usuario(String vNombre, String vApellido, String vusuario, String vContraseña, Perfil vperfil)
        {
            this.Nombre = vNombre;
            this.Apellidos = vApellido;
            this.usuario = vusuario;
            this.Contrasenia = vContraseña;
            this.perfil = vperfil;
        }
    }
}
