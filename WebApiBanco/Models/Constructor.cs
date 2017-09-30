using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBanco.Models.Seguridad;


namespace WebApiBanco.Models
{
    public class ConstructorContext
    {
        public static Banco banco {get; set;}
        public static List<Usuario> usuarios { get; set; }

        public ConstructorContext()
        {

            //Banco
            Banco ojbbanco = new Banco();
            ojbbanco.Direccion = "Av La marina 1245";
            ojbbanco.Nombre = "Efectiva";

            //Logueo
            Rol rol1 = new Rol();
            rol1.Nombre = "Banco";
            rol1.Pagina = "";

            Rol rol2 = new Rol();
            rol2.Nombre = "Sucursal";
            rol2.Pagina = "";

            Rol rol3 = new Rol();
            rol3.Nombre = "Orden Pago";
            rol3.Pagina = "";

            Perfil perfil1 = new Perfil();
            perfil1.Nombre = "Operador1";
            perfil1.roles.Add(rol1);
            perfil1.roles.Add(rol2);

            Perfil perfil2 = new Perfil();
            perfil2.Nombre = "Operador2";
            perfil2.roles.Add(rol3);

            Perfil perfil3 = new Perfil();
            perfil3.Nombre = "Administrador";
            perfil3.roles.Add(rol1);
            perfil3.roles.Add(rol2);
            perfil3.roles.Add(rol3);

            Usuario user1 = new Usuario("Manuel", "Contreras", "user001", "user001", perfil1);
            Usuario user2 = new Usuario("Pedro", "Ventura", "user002", "user002", perfil2);
            Usuario user3 = new Usuario("Juan", "Panta", "user003", "user003", perfil3);

        }

    }
}
