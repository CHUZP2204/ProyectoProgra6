using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class VehiculoXclienteController : Controller
    {
        //BD MODEL
        progra6Entities3 ModeloBD = new progra6Entities3();
        // GET: VehiculoXcliente
        public ActionResult VehiculoXcliente()
        {
            return View();
        }
        public ActionResult ListaVehxClie()
        {
            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaVehXPers_Result> modeloVista =
                  new List<sp_RetornaVehXPers_Result>();

            //asignar a la variable el resultado de llamar al sp
            modeloVista = this.ModeloBD.sp_RetornaVehXPers(null, null).ToList();

            this.AgregVehiculoViewBag();
            this.AgregTipoVehiculoViewBag();
            this.AgregClienteViewBag();
            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// <summary>
        /// Metodo Que Retorna La Vista 
        /// Para Agregar Nuevos Datos
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevoVehXclie()
        {
            this.AgregVehiculoViewBag();
            this.AgregTipoVehiculoViewBag();
            this.AgregClienteViewBag();
            return View();
        }
        /// <summary>
        /// Metodo Post Que Retorna Los Datos Ingresados 
        /// Por El Usuario Para Guardarlos En La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NuevoVehXclie(sp_RetornaVehXPers_Result modeloVista)
        {
            //Falta Validar placa
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
               this.ModeloBD.sp_Inserta_VehXPers(
                   modeloVista.idVehiculo,
                   modeloVista.idCliente
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
                    resultado = "El Registro Ingresado";
                }
                else
                {
                    resultado = "No se pudo Ingresar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");

            this.AgregVehiculoViewBag();
            this.AgregTipoVehiculoViewBag();
            this.AgregClienteViewBag();
            return View(modeloVista);
        }
        /// <summary>
        /// Metodo Que Retorna La Vista Para Modificar
        /// Los Datos Ya Existentes Por Medio De Un ID
        /// </summary>
        /// <param name="idVehiculoXCliente"></param>
        /// <returns></returns>
        public ActionResult ModificaVehCliente(int idVehiculoXCliente)
        {
            ///obtener el registro que se desea modificar
            /// utilizando el parametro del metodo idVehiculo
            sp_RetornaVehXPer_ID_Result modeloVista = new sp_RetornaVehXPer_ID_Result();
            modeloVista = this.ModeloBD.sp_RetornaVehXPer_ID(idVehiculoXCliente).FirstOrDefault();

            this.AgregVehiculoViewBag();
            this.AgregTipoVehiculoViewBag();
            this.AgregClienteViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Post Que Modifica Los Datos Ya Existentes
        /// Y Guardarlos En La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModificaVehCliente(sp_RetornaVehXPers_Result modeloVista)
        {
            //Falta Validar placa
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
               this.ModeloBD.sp_Modifica_VehXPers(
                   modeloVista.idVehiculoXCliente,
                   modeloVista.idVehiculo,
                   modeloVista.idCliente
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

            this.AgregVehiculoViewBag();
            this.AgregTipoVehiculoViewBag();
            this.AgregClienteViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Retorna La Vista Para Eliminar Un
        /// Dato ya Existente
        /// </summary>
        /// <param name="idVehiculoXCliente"></param>
        /// <returns></returns>
        public ActionResult EliminaVehCliente(int idVehiculoXCliente)
        {
            ///obtener el registro que se desea modificar
            /// utilizando el parametro del metodo idVehiculo
            sp_RetornaVehXPer_ID_Result modeloVista = new sp_RetornaVehXPer_ID_Result();
            modeloVista = this.ModeloBD.sp_RetornaVehXPer_ID(idVehiculoXCliente).FirstOrDefault();

            this.AgregVehiculoViewBag();
            this.AgregTipoVehiculoViewBag();
            this.AgregClienteViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Post Que Elimina El Dato Existente De La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EliminaVehCliente(sp_RetornaVehXPers_Result modeloVista)
        {
            //Falta Validar placa
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
               this.ModeloBD.sp_Elimina_VehXPers(
                   modeloVista.idVehiculoXCliente
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
                    resultado = "El Registro Eliminado";
                }
                else
                {
                    resultado = "No se pudo Eliminar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");

            this.AgregVehiculoViewBag();
            this.AgregTipoVehiculoViewBag();
            this.AgregClienteViewBag();
            return View(modeloVista);
        }
        /// <summary>
        /// Metodo Que Retorna Lista De Vehiculos
        /// Su Uso Sera Por Medio Del ViewBag
        /// </summary>
        void AgregVehiculoViewBag()
        {
            this.ViewBag.ListaVehiculos = this.ModeloBD.sp_RetornaVehiculo(null, null, null).ToList();
        }

        /// <summary>
        /// Metodo Que Retorna Lista De Clientes
        /// Su Uso Sera Por Medio Del ViewBag
        /// </summary>
        void AgregClienteViewBag()
        {
            this.ViewBag.ListaCliente = this.ModeloBD.sp_RetornaClientes(null, null).ToList();
        }
        /// <summary>
        /// Metodo Que Retorna Tipo De Vehiculos
        /// Su Uso Sera Por Medio Del ViewBag
        /// </summary>
        void AgregTipoVehiculoViewBag()
        {
            this.ViewBag.ListaTipoVehiculos = this.ModeloBD.sp_RetornaTipoVehiculo(null, null).ToList();
        }
        /// <summary>
        /// Metodo Que Retorna Tipo De Vehiculos
        /// Su Uso Sera Por Medio Del ViewBag
        /// </summary>
        void AgregTipoMarcaViewBag()
        {
            this.ViewBag.ListaTipoMarcaV = this.ModeloBD.sp_RetornaMarcaVehiculo(null, null).ToList();
        }
    }
}