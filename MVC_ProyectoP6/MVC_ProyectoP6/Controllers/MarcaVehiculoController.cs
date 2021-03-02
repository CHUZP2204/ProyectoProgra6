using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class MarcaVehiculoController : Controller
    {
        progra6Entities3 modeloBD = new progra6Entities3();

        // GET: MarcaVehiculo
        public ActionResult ListaMarcaVehiculos()
        {

            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaMarcaVehiculo_Result> modeloVista =
                new List<sp_RetornaMarcaVehiculo_Result>();

            //asignar a la variable el resultado de llamar al SP
            modeloVista = this.modeloBD.sp_RetornaMarcaVehiculo("", "").ToList();

            //enciar el modelo a la vista
            return View(modeloVista);
        }

        public ActionResult NuevaMarcaVehiculo()
        {
            this.AgregarPaisesViewBag();
            return View();
        }

        void AgregarPaisesViewBag()
        {
            this.ViewBag.ListaPaises =
                 this.modeloBD.sp_RetornaPaisFabricante("", "").ToList();
        }


        [HttpPost]
        public ActionResult NuevaMarcaVehiculo(sp_RetornaMarcaVehiculo_Result modeloVista)
        {
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";
            try
            {
                cantidadRegistrosAfectados =
                    this.modeloBD.sp_InsertaMarcaVehiculo(
                        modeloVista.CodigoMarcaVehiculo,
                        modeloVista.TipoMarcaVehiculo,
                        modeloVista.idPaisFabricante
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
            this.AgregarPaisesViewBag();
            return View();
        }

        public ActionResult ModificaMarcaVehiculo(int idMarcaVehiculo)
        {
             sp_RetornaMarcasVehiculo_ID_Result modeloVista = new sp_RetornaMarcasVehiculo_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaMarcasVehiculo_ID(idMarcaVehiculo).FirstOrDefault();
            this.AgregarPaisesViewBag();
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult ModificaMarcaVehiculo(sp_RetornaMarcasVehiculo_ID_Result modeloVista)
        {
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            try
            {
                cantidadRegistrosAfectados =
                       this.modeloBD.sp_ModificaMarcaVehiculo(
                           modeloVista.idMarcaVehiculo,
                           modeloVista.CodigoMarcaVehiculo,
                           modeloVista.TipoMarcaVehiculo,
                           modeloVista.idPaisFabricante
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
            this.AgregarPaisesViewBag();
            return View(modeloVista);
        }

        public ActionResult EliminaMarcaVehiculo(int idMarcaVehiculo)
        {
            sp_RetornaMarcasVehiculo_ID_Result modeloVista = new sp_RetornaMarcasVehiculo_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaMarcasVehiculo_ID(idMarcaVehiculo).FirstOrDefault();
            this.AgregarPaisesViewBag();
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult EliminaMarcaVehiculo(sp_RetornaMarcasVehiculo_ID_Result modeloVista)
        {
            ///varable que registra la cantidad de registro afectados
            ///si un SP que se ejecute Insert,UPDATE,DELETE
            ///no afecta registros implica que hubo un error 
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            try
            {
                cantidadRegistrosAfectados =
                       this.modeloBD.sp_EliminaMarcaVehiculos(
                          modeloVista.idMarcaVehiculo);
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un Error" + error.Message;

            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "Registro Eliminado";
                }
                else
                {
                    resultado = "No se pudo Eliminar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            this.AgregarPaisesViewBag();
            return View(modeloVista);
        }
    }
}
