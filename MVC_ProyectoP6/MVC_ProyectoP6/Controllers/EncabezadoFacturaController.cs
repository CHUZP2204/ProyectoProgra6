using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class EncabezadoFacturaController : Controller
    {
        progra6Entities3 modeloBD = new progra6Entities3();
        // GET: EncabezadoFactura
        public ActionResult ListaEncabezadoFactura()
        {
            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaEncFactura_Result> modeloVista =
                new List<sp_RetornaEncFactura_Result>();

            //asignar a la variable el resultado de llamar al SP
            modeloVista = this.modeloBD.sp_RetornaEncFactura("").ToList();

            this.AgregarClientesViewBag();
            this.AgregarVehiculosViewBag();
            //enciar el modelo a la vista
            return View(modeloVista);
        }

        void AgregarVehiculosViewBag()
        {
            this.ViewBag.ListaVehiculos =
                 this.modeloBD.sp_RetornaVehiculo("", null, null).ToList();
        }

        void AgregarClientesViewBag()
        {
            this.ViewBag.ListaClientes =
                 this.modeloBD.sp_RetornaClientes("", "").ToList();
        }

        void AgregarEstadoFacturaViewBag()
        {
            this.ViewBag.ListaEstadoFactura =
                 this.modeloBD.sp_RetornaEncFactura("").ToList();
        }

        void AgregarDetalleViewBag()
        {
            this.ViewBag.ListaDetalles =
                 this.modeloBD.sp_RetornaDetalleFac(null).ToList();
        }
        /// <summary>
        ///
        /// </summary>
        void AgregTipoSOPViewBag()
        {
            this.ViewBag.ListaTipoSOP = this.modeloBD.sp_RetornaServicioOProducto(null, null).ToList();
        }
        public ActionResult NuevoEncabezadoFactura()
        {
            this.AgregarClientesViewBag();
            this.AgregarVehiculosViewBag();
            this.AgregarEstadoFacturaViewBag();
            this.AgregarDetalleViewBag();
            this.AgregTipoSOPViewBag();
            return View();
           

        }

        [HttpPost]
        public ActionResult NuevoEncabezadoFactura(sp_RetornaEncFactura_Result modeloVista)
        {
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";
            try
            {
                cantidadRegistrosAfectados =
                    this.modeloBD.sp_InsertaEncFactura(
                        modeloVista.idCliente,
                        modeloVista.idVehiculo,
                        modeloVista.Fecha,
                        modeloVista.MontoTotalServicios,
                        modeloVista.EstadoFactura,
                        modeloVista.idDetalleFac
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
            this.AgregarClientesViewBag();
            this.AgregarVehiculosViewBag();
            this.AgregarEstadoFacturaViewBag();
            this.AgregarDetalleViewBag();
            this.AgregTipoSOPViewBag();
            return View(modeloVista);
        }

    }
}