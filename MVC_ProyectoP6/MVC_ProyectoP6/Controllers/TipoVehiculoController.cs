using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class TipoVehiculoController : Controller
    {
        progra6Entities3 modeloBD = new progra6Entities3();
        // GET: TipoVehiculo
        public ActionResult ListaTipoVehiculos()
        {
            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaTipoVehiculo_Result> modeloVista =
                  new List<sp_RetornaTipoVehiculo_Result>();

            //asignar a la variable el resultado de llamar al sp
            modeloVista = this.modeloBD.sp_RetornaTipoVehiculo("", "").ToList();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        public ActionResult NuevoTipoVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoTipoVehiculo(sp_RetornaTipoVehiculo_Result modeloVista)
        {
            List<sp_RetornaTipoVehiculo_Result> modeloVista1 = new List<sp_RetornaTipoVehiculo_Result>();

            ///Asignar a la variable el resultado de llamar o invocar al Procedimiento almacenado
            modeloVista1 = this.modeloBD.sp_RetornaTipoVehiculo(modeloVista.CodigoTipoVehiculo, "").ToList();

            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantidadRegistrosAfectados = 0;
            string resultado = " ";


            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {
                ///Variable Que Guardara 1 si se encuentra un Dato, de lo contrario sera 0
                int NombreEncontrado = 0;
                ///Recorrer El Modelo Obtenido Con Los Datos Ingresados Por usuario "modeloVista"
                ///Y Compararlo con el modelovista del view
                for (int i = 0; i < modeloVista1.Count; i++)
                {
                    ///Aqui Se Verifica Si Existe O No El Mismo Codigo
                    if (modeloVista1[i].CodigoTipoVehiculo.Equals(modeloVista.CodigoTipoVehiculo))
                    {

                        NombreEncontrado = 1;

                    }
                }

                ///Si la variable permanece en 0 significa que no hay ningun dato con 
                ///ese nombre en la BD, Y Se Podra Asignar Los Nuevos Datos
                if (NombreEncontrado == 0)
                {
                    cantidadRegistrosAfectados =
                   this.modeloBD.sp_InsertaTipoVehiculo(
                       modeloVista.CodigoTipoVehiculo,
                            modeloVista.TipoVehiculo
                       );
                }
                else
                {
                    cantidadRegistrosAfectados = 0;
                }

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
                    resultado += "No se pudo Insertar el codigo ya existe";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            return View();
        }

        public ActionResult ModificaTipoVehiculo(int idTipoVehiculo)
        {
            ///obtener el registro que se desea modificar
            /// utilizando el parametro del metodo idPaisFabricante
            sp_RetornaTipoVehiculos_ID_Result modeloVista = new sp_RetornaTipoVehiculos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaTipoVehiculos_ID(idTipoVehiculo).FirstOrDefault();

            //enviar modelo a la vista
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult ModificaTipoVehiculo(sp_RetornaTipoVehiculos_ID_Result modeloVista)
        {
            List<sp_RetornaTipoVehiculo_Result> modeloVista1 = new List<sp_RetornaTipoVehiculo_Result>();

            ///Asignar a la variable el resultado de llamar o invocar al Procedimiento almacenado
            modeloVista1 = this.modeloBD.sp_RetornaTipoVehiculo(modeloVista.CodigoTipoVehiculo, "").ToList();

            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantidadRegistrosAfectados = 0;
            string resultado = " ";


            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {
                ///Variable Que Guardara 1 si se encuentra un Dato, de lo contrario sera 0
                int NombreEncontrado = 0;
                ///Recorrer El Modelo Obtenido Con Los Datos Ingresados Por usuario "modeloVista"
                ///Y Compararlo con el modelovista del view
                for (int i = 0; i < modeloVista1.Count; i++)
                {
                    ///Aqui Se Verifica Si Existe O No El Mismo Codigo
                    if (modeloVista1[i].CodigoTipoVehiculo.Equals(modeloVista.CodigoTipoVehiculo))
                    {

                        NombreEncontrado = 1;

                    }
                }

                ///Si la variable permanece en 0 significa que no hay ningun dato con 
                ///ese nombre en la BD, Y Se Podra Asignar Los Nuevos Datos
                if (NombreEncontrado == 0)
                {
                    cantidadRegistrosAfectados =
                   this.modeloBD.sp_ModificaTipoVehiculo(
                       modeloVista.idTipoVehiculo,
                       modeloVista.CodigoTipoVehiculo,
                            modeloVista.TipoVehiculo
                       );
                }
                else
                {
                    cantidadRegistrosAfectados = 0;
                }

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
        public ActionResult EliminaTipoVehiculo(int idTipoVehiculo)
        {
            ///obtener el registro que se desea modificar
            /// utilizando el parametro del metodo idPaisFabricante
            sp_RetornaTipoVehiculos_ID_Result modeloVista = new sp_RetornaTipoVehiculos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaTipoVehiculos_ID(idTipoVehiculo).FirstOrDefault();

            //enviar modelo a la vista
            return View(modeloVista);

        }

        [HttpPost]
        public ActionResult EliminaTipoVehiculo(sp_RetornaTipoVehiculos_ID_Result modeloVista)
        {
            ///varable que registra la cantidad de registro afectados
            ///si un SP que se ejecute Insert,UPDATE,DELETE
            ///no afecta registros implica que hubo un error 
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            try
            {
                cantidadRegistrosAfectados =
                       this.modeloBD.sp_EliminaTipoVehiculos(
                          modeloVista.idTipoVehiculo);
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
            return View(modeloVista);
        }

    }
}