using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Banco
    {

        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<Sucursal> Sucursales = new List<Sucursal>();

        public List<OrdenPago> OrdenPagos()
        {
            List<OrdenPago> objpgs = new List<OrdenPago>();
            foreach (Sucursal item in Sucursales)
            {
                objpgs.AddRange(item.OrdenesPago);
            }
            return objpgs;
        }

        public Banco()
        {
            Sucursal nueva1 = new Sucursal();
            nueva1.Nombre = "Sucursal A";
            nueva1.Direccion = "Av. Arequipa 1245";
            nueva1.FechaRegistro = DateTime.Parse("01/01/2017");
            nueva1.banco = this;
            List<OrdenPago> ordenesA = new List<OrdenPago>();
            ordenesA.Add(new OrdenPago()
            {
                Monto = 150,
                Moneda = TipoMoneda.Soles,
                Estado = EstadoPago.Pagada,
                FechaRegistro = DateTime.Parse("04/06/2017"),
                sucursal = nueva1.Nombre
            });
            ordenesA.Add(new OrdenPago()
            {
                Monto = 850,
                Moneda = TipoMoneda.Soles,
                Estado = EstadoPago.Fallida,
                FechaRegistro = DateTime.Parse("04/02/2017"),
                sucursal = nueva1.Nombre
            });
            ordenesA.Add(new OrdenPago()
            {
                Monto = 460,
                Moneda = TipoMoneda.Soles,
                Estado = EstadoPago.Anulada,
                FechaRegistro = DateTime.Parse("04/01/2017"),
                sucursal = nueva1.Nombre
            });
            ordenesA.Add(new OrdenPago()
            {
                Monto = 360,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Pagada,
                FechaRegistro = DateTime.Parse("10/02/2017"),
                sucursal = nueva1.Nombre
            });
            ordenesA.Add(new OrdenPago()
            {
                Monto = 790,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Fallida,
                FechaRegistro = DateTime.Parse("09/05/2017"),
                sucursal = nueva1.Nombre
            });
            ordenesA.Add(new OrdenPago()
            {
                Monto = 2000,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Declinada,
                FechaRegistro = DateTime.Parse("07/06/2017"),
                sucursal = nueva1.Nombre
            });
            nueva1.OrdenesPago = ordenesA;


            //////////////// 2 /////////////////




            Sucursal nueva2 = new Sucursal();
            nueva2.Nombre = "Sucursal B";
            nueva2.Direccion = "Av. Angamos 520";
            nueva2.FechaRegistro = DateTime.Parse("01/01/2017");
            nueva2.banco = this;

            List<OrdenPago> ordenesB = new List<OrdenPago>();
            ordenesB.Add(new OrdenPago()
            {
                Monto = 4580,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Pagada,
                FechaRegistro = DateTime.Parse("07/02/2017"),
                sucursal = nueva2.Nombre
            });
            ordenesB.Add(new OrdenPago()
            {
                Monto = 4920,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Declinada,
                FechaRegistro = DateTime.Parse("07/07/2017"),
                sucursal = nueva2.Nombre
            });
            ordenesB.Add(new OrdenPago()
            {
                Monto = 10000,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Pagada,
                FechaRegistro = DateTime.Parse("02/06/2017"),
                sucursal = nueva2.Nombre
            });
            ordenesB.Add(new OrdenPago()
            {
                Monto = 59000,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Fallida,
                FechaRegistro = DateTime.Parse("03/05/2017"),
                sucursal = nueva2.Nombre
            });
            ordenesB.Add(new OrdenPago()
            {
                Monto = 74500,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Anulada,
                FechaRegistro = DateTime.Parse("05/05/2017"),
                sucursal = nueva2.Nombre
            });
            ordenesB.Add(new OrdenPago()
            {
                Monto = 56000,
                Moneda = TipoMoneda.Soles,
                Estado = EstadoPago.Pagada,
                FechaRegistro = DateTime.Parse("01/06/2017"),
                sucursal = nueva2.Nombre
            });
            ordenesB.Add(new OrdenPago()
            {
                Monto = 1200,
                Moneda = TipoMoneda.Dolares,
                Estado = EstadoPago.Fallida,
                FechaRegistro = DateTime.Parse("06/09/2017"),
                sucursal = nueva2.Nombre
            });
            ordenesB.Add(new OrdenPago()
            {
                Monto = 12600,
                Moneda = TipoMoneda.Soles,
                Estado = EstadoPago.Pagada,
                FechaRegistro = DateTime.Parse("09/09/2017"),
                sucursal = nueva2.Nombre
            });
            nueva2.OrdenesPago = ordenesB;

            Sucursales.Add(nueva1);
            Sucursales.Add(nueva2);
        }
    }
}
