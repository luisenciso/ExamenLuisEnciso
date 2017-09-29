using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBanco.Models
{
    public class Sucursal
    {
        public Decimal Monto { get; set; }
        public String Moneda { get; set; }
        public String Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
