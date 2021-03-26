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

        /// <summary>
        /// Metodo Que Retorna Vista Con Los Datos
        /// De Detalle Factura 
        /// </summary>
        /// <returns></returns>
        public ActionResult ListaDetalleFactura()
        {
            List<sp_RetornaDetalleFac_Result> modeloVista = new List<sp_RetornaDetalleFac_Result>();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFac(null).ToList();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Retorna Vista Con Los Datos
        /// De Detalle Factura Por id Encabezado Factura
        /// (Resumido)
        /// #Factura En Especifico
        /// </summary>
        /// <param name="idEncabezadoFact"></param>
        /// <returns></returns>
        public ActionResult ListaDetallePorId(int idEncabezadoFact)
        {
            List<sp_RetornaDetalleFacXenca_ID_Result> modeloVista = new List<sp_RetornaDetalleFacXenca_ID_Result>();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFacXenca_ID(idEncabezadoFact).ToList();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }
        /// <summary>
        /// Agregar Un Detalle Factura Sin Restriccion 
        /// A Cualquier #Factura
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevoDetalleFac()
        {
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View();
        }

        /// <summary>
        /// Registra El Nuevo Detalle Factura En La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NuevoDetalleFac(sp_RetornaDetalleFac_Result modeloVista)
        {
            
            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            int precioIngresado = Convert.ToInt32(modeloVista.PrecioSOP);

            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {

                cantidadRegistrosAfectados =
               this.ModeloBD.sp_InsertaDetalleFactura(
                   modeloVista.idSOP,
                   modeloVista.CantidadSOP,
                   precioIngresado,
                   modeloVista.idEncabezadoFact
                   ) ;



            }
            catch (Exception error)
            {
                resultado = "Ocurrio un Error" + error.Message;

            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "El Registro Insertado";
                }
                else
                {
                    resultado = "No se pudo insertar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");

            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }
        /// <summary>
        /// Metodo Que Retorna La Vista Agregar Detalle Factura
        /// Accedida Pasandole Un Parametro idEncabezado
        /// Esto Para Enlazar El Encabezado Con Los Detalles
        /// De Factura Que Se Le Asignen
        /// </summary>
        /// <param name="idEncabezadoFac"></param>
        /// <returns></returns>
        public ActionResult AgregarDetalleFactura(int idEncabezadoFac)
        {
            sp_RetornaDetalleFac_Result modeloVista = new sp_RetornaDetalleFac_Result();

            ///Se Inician Las Variables del Modelo
            ///En vacio, excepto idEncabezado
            ///Que Sera Usada Mas Adelante Al
            ///Registrar El Detalle
            modeloVista.idDetalleFac = 0;
            modeloVista.idEncabezadoFact = idEncabezadoFac;
            modeloVista.CantidadSOP = 0;
            modeloVista.PrecioSOP = 0;
            modeloVista.idSOP = 0;

            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Registra El Detalle Ala BD
        /// Enlazado A Un Encabezado
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AgregarDetalleFactura(sp_RetornaDetalleFac_Result modeloVista)
        {
            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            int precioIngresado = Convert.ToInt32(modeloVista.PrecioSOP);

            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {

                cantidadRegistrosAfectados =
               this.ModeloBD.sp_InsertaDetalleFactura(
                   modeloVista.idSOP,
                   modeloVista.CantidadSOP,
                   precioIngresado,
                   modeloVista.idEncabezadoFact
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
                    resultado = "El Registro Insertado";
                }
                else
                {
                    resultado = "No se pudo insertar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");

            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }
        
        /// <summary>
        /// Vista Que Nos Ayudara A
        /// ModificaR Los Datos De Un Detalle Factura
        /// </summary>
        /// <param name="idDetalleFac"></param>
        /// <returns></returns>
        public ActionResult ModificaDetalleFac(int idDetalleFac)
        {
            sp_RetornaDetalleFac_ID_Result modeloVista = new sp_RetornaDetalleFac_ID_Result();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFac_ID(idDetalleFac).FirstOrDefault();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Almacena Los Datos Ingresados Desde La Vista En La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModificaDetalleFac(sp_RetornaDetalleFac_Result modeloVista)
        {
            
            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            int precioIngresado = Convert.ToInt32(modeloVista.PrecioSOP);

            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {

                cantidadRegistrosAfectados =
               this.ModeloBD.sp_ModificaDetalleFactura(
                   modeloVista.idDetalleFac,
                   modeloVista.idEncabezadoFact,
                   modeloVista.idSOP,
                   modeloVista.CantidadSOP,
                   precioIngresado

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
                    resultado = "No se pudo Modificar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");

            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Vista Que Ayudara A
        /// Eliminar Un Detalle De Factura  
        /// </summary>
        /// <param name="idDetalleFac"></param>
        /// <returns></returns>
        public ActionResult EliminaDetalleFac(int idDetalleFac)
        {
            sp_RetornaDetalleFac_ID_Result modeloVista = new sp_RetornaDetalleFac_ID_Result();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFac_ID(idDetalleFac).FirstOrDefault();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que ELiminara Los Datos Detalle Factura Por Id
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EliminaDetalleFac(sp_RetornaDetalleFac_Result modeloVista)
        {

            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantidadRegistrosAfectados = 0;
            string resultado = " ";

            int precioIngresado = Convert.ToInt32(modeloVista.PrecioSOP);

            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {

                cantidadRegistrosAfectados =
               this.ModeloBD.sp_EliminaDetalleFactura(
                   modeloVista.idDetalleFac
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

            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Lista De Servicios Y Productos
        /// Se Accede Por VieBag
        /// </summary>
        void AgregTipoSOPViewBag()
        {
            this.ViewBag.ListaTipoSOP = this.ModeloBD.sp_RetornaServicioOProducto(null, null).ToList();
        }
        /// <summary>
        /// Lista De Encabezado Factura
        /// Se Accede Por VieBag
        /// </summary>
        void AgregaEncabezadoViewBag()
        {
            this.ViewBag.ListaEncabezado = this.ModeloBD.sp_RetornaEncFactura(null).ToList();
        }
    }
}