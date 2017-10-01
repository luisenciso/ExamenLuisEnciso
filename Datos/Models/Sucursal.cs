using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Sucursal
    {
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Banco banco { get; set; }
        public List<OrdenPago> OrdenesPago { get; set; }

        public Sucursal()
        {

        }
    }
}
