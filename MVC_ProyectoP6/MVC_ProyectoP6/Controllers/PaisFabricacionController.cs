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
                if (cantidadRegistrosAfectados > 0)
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
        public ActionResult ListaPaisFabricante()
        {
            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaPaisFabricante_Result> modeloVista =
                new List<sp_RetornaPaisFabricante_Result>();

            //asignar a la variable el resultado de llamar al SP
            modeloVista = this.modeloBD.sp_RetornaPaisFabricante("", "").ToList();

            //enciar el modelo a la vista
            return View(modeloVista);
        }
        public ActionResult ModificaPaisFabricante(int idPaisFabricante)
        {    ///obtener el registro que se desea modificar
             /// utilizando el parametro del metodo idPaisFabricante
            sp_RetornaPaisFabricante_ID_Result modeloVista = new sp_RetornaPaisFabricante_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaPaisFabricante_ID(idPaisFabricante).FirstOrDefault();

            //enviar modelo a la vista
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult ModificaPaisFabricante(sp_RetornaPaisFabricante_ID_Result modeloVista)
        {
            ///varable que registra la cantidad de registro afectados
            ///si un SP que se ejecute Insert,UPDATE,DELETE
            ///no afecta registros implica que hubo un error 
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            try
            {
                cantidadRegistrosAfectados =
                       this.modeloBD.sp_ModificaPaisFabricante(
                           modeloVista.idPaisFabricante,
                           modeloVista.PaisFabricante,
                           modeloVista.CodigoPaisFabricante
                           );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un Error" + error.Message;
               
            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "El Registro Modificado";
                }
                else
                {
                    resultado = "No se pudo Modifcar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }

    }
}