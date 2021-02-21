using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class UsuariosController : Controller
    {
        //Conexion Con Modelo BD
        progra6Entities3 modeloBD = new progra6Entities3();

        // GET: Usuarios
        public ActionResult ListaUsuario()
        {
            List<sp_RetornaClientes_Result> modeloVista = new List<sp_RetornaClientes_Result>();

            modeloVista = this.modeloBD.sp_RetornaClientes("", "").ToList();

            return View(modeloVista);
        }

        public ActionResult NuevoUsuario()
        {
            this.AgregaProvinciasViewBag();
            return View();
        }

        void AgregaProvinciasViewBag()
        {
            this.ViewBag.ListaProvincias = this.modeloBD.sp_RetornaProvincias("", null).ToList();
        }

        /// <summary>
        /// Metodo Que Retorna Los Cantones Por Id de Provincia 
        /// y Se Accede Por Medio de Jquery Ajax
        /// </summary>
        /// <param name="id_Provincia"></param>
        /// <returns></returns>
        public ActionResult AgregaCantones(int id_Provincia)
        {
            List<sp_RetornaCantones_Result> modeloVista = new List<sp_RetornaCantones_Result>();
            modeloVista = modeloBD.sp_RetornaCantones("", id_Provincia).ToList();

            /// Los Parametros Dentro De 
            /// SelectList(dataValueField,dataTextField)
            /// 
            return Json(new SelectList(modeloVista, "id_Canton", "Canton"));

        }

        /// <summary>
        /// Metodo Que Retorna Los Distritos Por Id de Canton 
        /// y Se Accede Por Medio de Jquery Ajax
        /// </summary>
        /// <param name="id_Canton"></param>
        /// <returns></returns>
        public ActionResult AgregaDistritos(int id_Canton)
        {
            List<sp_RetornaDistritos_Result> modeloVista = new List<sp_RetornaDistritos_Result>();
            modeloVista = modeloBD.sp_RetornaDistritos("", id_Canton).ToList();

            /// Los Parametros Dentro De 
            /// SelectList(dataValueField,dataTextField)
            /// Se Convierte a un objeto de tipo JSON
            return Json(new SelectList(modeloVista, "id_Distrito", "Distrito"));

        }
    }

}