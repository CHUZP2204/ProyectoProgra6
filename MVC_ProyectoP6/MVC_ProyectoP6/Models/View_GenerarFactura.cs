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
    
    public partial class View_GenerarFactura
    {
        public int idEncabezadoFact { get; set; }
        public int idDetalleFac { get; set; }
        public int idSOP { get; set; }
        public int idCliente { get; set; }
        public int idVehiculo { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string TipoUsuario { get; set; }
        public string PlacaVehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public string TipoMarcaVehiculo { get; set; }
        public string CodigoTipoVehiculo { get; set; }
        public string CodigoMarcaVehiculo { get; set; }
        public string EstadoFactura { get; set; }
        public string CodigoSOP { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string ProductoServicio { get; set; }
        public int CantidadAdquirida { get; set; }
        public decimal PrecioXunidad { get; set; }
        public decimal MontoFinal { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}
