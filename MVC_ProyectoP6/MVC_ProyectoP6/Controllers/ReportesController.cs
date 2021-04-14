using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class ReportesController : Controller
    {
        progra6Entities3 modeloBD = new progra6Entities3();
        // GET: Reportes
        [HttpPost]
        public ActionResult RetornaServicioXCliente()
        {
            List<sp_RetornaViewReportes_Result> listaMarcaServicioXCliente =
                this.modeloBD.sp_RetornaViewReportes(null,null,"","").ToList();

            return Json(new
            {
                resultado = listaMarcaServicioXCliente
            });


        }
        public ActionResult ReporteServicioXCliente()
        {
            return View();
        }

        public ActionResult RetornaServicioXVehiculo()
        {
            List<sp_RetornaViewReportes_Result> listaServicioXVehiculo =
                this.modeloBD.sp_RetornaViewReportes(null, null, "", "").ToList();

            return Json(new
            {
                resultado = listaServicioXVehiculo
            });


        }
        public ActionResult ReporteServicioXVehiculo()
        {
            return View();
        }

        public ActionResult RetornaVehiculosXCliente()
        {
            List<sp_RetornaVehiculosXCliente_Result> listaVehiculosXCliente =
                this.modeloBD.sp_RetornaVehiculosXCliente(null).ToList();

            return Json(new
            {
                resultado = listaVehiculosXCliente
            });


        }
        public ActionResult ReporteVehiculosXCliente()
        {
            return View();
        }
    }
}