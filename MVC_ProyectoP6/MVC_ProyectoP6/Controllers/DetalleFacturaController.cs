using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class DetalleFacturaController : Controller
    {
        //ModeloBD
        progra6Entities3 ModeloBD = new progra6Entities3();
        // GET: DetalleFactura
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListaDetalleFactura()
        {
            List<sp_RetornaDetalleFac_Result> modeloVista = new List<sp_RetornaDetalleFac_Result>();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFac(null).ToList();
            this.AgregTipoSOPViewBag();
            return View(modeloVista);
        }

        public ActionResult NuevoDetalleFac()
        {
            this.AgregTipoSOPViewBag();
            return View();
        }

        /// <summary>
        ///
        /// </summary>
        void AgregTipoSOPViewBag()
        {
            this.ViewBag.ListaTipoSOP = this.ModeloBD.sp_RetornaServicioOProducto(null, null).ToList();
        }
    }
}