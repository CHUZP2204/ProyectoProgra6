using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{

    public class PaisFabricacionController : Controller
    {
        progra6Entities3 modeloBD = new progra6Entities3();

        // GET: Registro PaisFabricacion
        public ActionResult NuevoPaisFabricante()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoPaisFabricante(sp_RetornaPaisFabricante_Result modeloVista)
        {
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";
            try
            {
                cantidadRegistrosAfectados =
                    this.modeloBD.sp_InsertaPaisFabricante(
                        modeloVista.CodigoPaisFabricante,
                        modeloVista.PaisFabricante
                        );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;
                
            }
            finally
            {
                if (cantidadRegistrosAfectados >0)
                {
                    resultado = "Registro Insertado";
                }
                else
                {
                    resultado += "No se pudo Insertar";            
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            return View();
        }
    }
}