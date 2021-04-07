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
            List<sp_RetornaServiciosXCliente_Result> listaMarcaServicioXCliente =
                this.modeloBD.sp_RetornaServiciosXCliente("","","").ToList();

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
            List<sp_RetornaServiciosXVehiculo_Result> listaServicioXVehiculo =
                this.modeloBD.sp_RetornaServiciosXVehiculo("", "").ToList();

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
            List<sp_RetornaVEHICULOSXCLIENTES_Result> listaVehiculosXCliente =
                this.modeloBD.sp_RetornaVEHICULOSXCLIENTES("","").ToList();

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