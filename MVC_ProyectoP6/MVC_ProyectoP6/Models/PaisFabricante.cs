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
    
    public partial class PaisFabricante
    {
        public PaisFabricante()
        {
            this.MarcaVehiculos = new HashSet<MarcaVehiculos>();
        }
    
        public int idPaisFabricante { get; set; }
        public string CodigoPaisFabricante { get; set; }
        public string PaisFabricante1 { get; set; }
    
        public virtual ICollection<MarcaVehiculos> MarcaVehiculos { get; set; }
    }
}
