//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_ProyectoP6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EncabezadoFactura
    {
        public int idEncabezadoFac { get; set; }
        public int idCliente { get; set; }
        public int idVehiculo { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal MontoTotalServicios { get; set; }
        public string EstadoFactura { get; set; }
        public int idDetalleFac { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual DetalleFactura DetalleFactura { get; set; }
    }
}
