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
    
    public partial class VehiculosXCliente
    {
        public int idVehiculoXCliente { get; set; }
        public int idVehiculo { get; set; }
        public int idCliente { get; set; }
    
        public virtual Vehiculos Vehiculos { get; set; }
        public virtual Clientes Clientes { get; set; }
    }
}
