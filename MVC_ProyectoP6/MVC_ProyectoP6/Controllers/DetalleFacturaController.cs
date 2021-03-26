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
        public ActionResult ListaDetalleFactura()
        {
            List<sp_RetornaDetalleFac_Result> modeloVista = new List<sp_RetornaDetalleFac_Result>();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFac(null).ToList();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        public ActionResult ListaDetallePorId(int idEncabezadoFact)
        {
            List<sp_RetornaDetalleFacXenca_ID_Result> modeloVista = new List<sp_RetornaDetalleFacXenca_ID_Result>();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFacXenca_ID(idEncabezadoFact).ToList();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

        public ActionResult NuevoDetalleFac()
        {
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult NuevoDetalleFac(sp_RetornaDetalleFac_Result modeloVista)
        {
            //Falta Validar placa
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
        
        public ActionResult AgregarDetalleFactura(int idEncabezadoFac)
        {
            sp_RetornaDetalleFac_Result modeloVista = new sp_RetornaDetalleFac_Result();

            modeloVista.idDetalleFac = 0;
            modeloVista.idEncabezadoFact = idEncabezadoFac;
            modeloVista.CantidadSOP = 0;
            modeloVista.PrecioSOP = 0;
            modeloVista.idSOP = 0;

            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult AgregarDetalleFactura(sp_RetornaDetalleFac_Result modeloVista)
        {
            //Falta Validar placa
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
        /// 

        public ActionResult ModificaDetalleFac(int idDetalleFac)
        {
            sp_RetornaDetalleFac_ID_Result modeloVista = new sp_RetornaDetalleFac_ID_Result();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFac_ID(idDetalleFac).FirstOrDefault();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }

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

        public ActionResult EliminaDetalleFac(int idDetalleFac)
        {
            sp_RetornaDetalleFac_ID_Result modeloVista = new sp_RetornaDetalleFac_ID_Result();

            modeloVista = this.ModeloBD.sp_RetornaDetalleFac_ID(idDetalleFac).FirstOrDefault();
            this.AgregTipoSOPViewBag();
            this.AgregaEncabezadoViewBag();
            return View(modeloVista);
        }
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
        ///
        /// </summary>
        void AgregTipoSOPViewBag()
        {
            this.ViewBag.ListaTipoSOP = this.ModeloBD.sp_RetornaServicioOProducto(null, null).ToList();
        }

        void AgregaEncabezadoViewBag()
        {
            this.ViewBag.ListaEncabezado = this.ModeloBD.sp_RetornaEncFactura(null).ToList();
        }
    }
}