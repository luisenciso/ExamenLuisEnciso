using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBanco.Models
{
    public class OrdenPago
    {
        public Decimal Monto { get; set; }
        public TipoMoneda Moneda { get; set; }
        public EstadoPago Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Sucursal sucursal { get; set; }
    }

    public enum EstadoPago
    {
        Pagada,
        Declinada,
        Fallida,
        Anulada
    }

    public enum TipoMoneda
    {
        Soles,
        Dolares
    }

}
