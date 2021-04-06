using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class VehiculosController : Controller
    {
        //Enlace BD
        progra6Entities3 ModeloBD = new progra6Entities3();
        // GET: Vehiculos
        public ActionResult Vehiculos()
        {
            return View();
        }
        public ActionResult ListaVehiculoS()
        {
            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaVehiculo_Result> modeloVista =
                  new List<sp_RetornaVehiculo_Result>();

            //asignar a la variable el resultado de llamar al sp
            modeloVista = this.ModeloBD.sp_RetornaVehiculo(null,null,null).ToList();

            this.AgregTipoVehiculoViewBag();
            this.AgregTipoMarcaViewBag();
            //enviar el modelo a la vista
            return View(modeloVista);
        
        
        }
        /// <summary>
        /// Vista Nuevo Vehiculo
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevoVehiculo()
        {
            this.AgregTipoVehiculoViewBag();
            this.AgregTipoMarcaViewBag();
            //enviar modelo a la vista
            return View();
        }

        [HttpPost]
        public ActionResult NuevoVehiculo(sp_RetornaVehiculo_Result modeloVista)
        {
            List<sp_RetornaVehiculo_Result> modeloVista1 = new List<sp_RetornaVehiculo_Result>();

            /////Asignar a la variable el resultado de llamar o invocar al Procedimiento almacenado
            modeloVista1 = this.ModeloBD.sp_RetornaVehiculo(modeloVista.PlacaVehiculo, null,null).ToList();
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
                    if (modeloVista1[i].PlacaVehiculo.Equals(modeloVista.PlacaVehiculo))
                    {

                        NombreEncontrado = 1;

                    }
                }
                if (NombreEncontrado == 0)
                {
                    cantidadRegistrosAfectados =
                                  this.ModeloBD.sp_InsertaVehiculo(
                                      modeloVista.PlacaVehiculo,
                                      modeloVista.idTipoVehiculo,
                                      modeloVista.idMarcaVehiculo,
                                      modeloVista.NumeroPuertas,
                                      modeloVista.NumeroRuedas
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
                    resultado = "El Registro Insertado / Debes Enlazarlo A Un Cliente";
                }
                else
                {
                    resultado = "No se pudo insertar, la placa ya existe";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            this.AgregTipoVehiculoViewBag();
            this.AgregTipoMarcaViewBag();
            //enviar modelo a la vista
            return View(modeloVista);
        }
        /// <summary>
        /// Modificar Vehiculo
        /// </summary>
        /// <param name="idVehiculo"></param>
        /// <returns></returns>
        public ActionResult ModificaVehiculo(int idVehiculo)
        {
            ///obtener el registro que se desea modificar
            /// utilizando el parametro del metodo idVehiculo
            sp_RetornaVehiculo_ID_Result modeloVista = new sp_RetornaVehiculo_ID_Result();
            modeloVista = this.ModeloBD.sp_RetornaVehiculo_ID(idVehiculo).FirstOrDefault();

            this.AgregTipoVehiculoViewBag();
            this.AgregTipoMarcaViewBag();
            //enviar modelo a la vista
            return View(modeloVista);
        }
        /// <summary>
        /// Modifica Los Datos Del Vehiculo
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModificaVehiculo(sp_RetornaVehiculo_ID_Result modeloVista)
        {


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

                    cantidadRegistrosAfectados =
                   this.ModeloBD.sp_ModificaVehiculo(
                       modeloVista.idVehiculo,
                       modeloVista.PlacaVehiculo,
                       modeloVista.idTipoVehiculo,
                       modeloVista.idMarcaVehiculo,
                       modeloVista.NumeroPuertas,
                       modeloVista.NumeroRuedas
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
            this.AgregTipoVehiculoViewBag();
            this.AgregTipoMarcaViewBag();
            //enviar modelo a la vista
            return View(modeloVista);
        }
        /// <summary>
        /// Eliminar Vehiculo
        /// </summary>
        /// <param name="idVehiculo"></param>
        /// <returns></returns>
        public ActionResult EliminaVehiculo(int idVehiculo)
        {
            ///obtener el registro que se desea Eliminar
            /// utilizando el parametro del metodo idVehiculo
            sp_RetornaVehiculo_ID_Result modeloVista = new sp_RetornaVehiculo_ID_Result();
            modeloVista = this.ModeloBD.sp_RetornaVehiculo_ID(idVehiculo).FirstOrDefault();

            this.AgregTipoVehiculoViewBag();
            this.AgregTipoMarcaViewBag();
            //enviar modelo a la vista
            return View(modeloVista);

        }
        [HttpPost]
        public ActionResult EliminaVehiculo(sp_RetornaVehiculo_ID_Result modeloVista)
        {
            ///varable que registra la cantidad de registro afectados
            ///si un SP que se ejecute Insert,UPDATE,DELETE
            ///no afecta registros implica que hubo un error 
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            try
            {
                cantidadRegistrosAfectados =
                       this.ModeloBD.sp_EliminarVehiculo(
                          modeloVista.idVehiculo);
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un Error" + error.Message;

            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "Registro Fue Eliminado";
                }
                else
                {
                    resultado = "No se pudo Eliminar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            this.AgregTipoVehiculoViewBag();
            this.AgregTipoMarcaViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Retorna Tipo De Vehiculos
        /// Su Uso Sera Por Medio Del ViewBag
        /// </summary>
        void AgregTipoVehiculoViewBag()
        {
            this.ViewBag.ListaTipoVehiculos = this.ModeloBD.sp_RetornaTipoVehiculo(null,null).ToList();
        }
        /// <summary>
        /// Metodo Que Retorna Tipo De Vehiculos
        /// Su Uso Sera Por Medio Del ViewBag
        /// </summary>
        void AgregTipoMarcaViewBag()
        {
            this.ViewBag.ListaTipoMarcaV = this.ModeloBD.sp_RetornaMarcaVehiculo(null,null).ToList();
        }

        [HttpPost]
        public ActionResult RetornaVehiculos()
        {
            List<sp_RetornaVehiculo_Result> listaVehiculos =
                this.ModeloBD.sp_RetornaVehiculo("",null ,null).ToList();

            return Json(new
            {
                resultado = listaVehiculos
            });


        }
        public ActionResult GridVehiculos()
        {
            return View();
        }
    }
}