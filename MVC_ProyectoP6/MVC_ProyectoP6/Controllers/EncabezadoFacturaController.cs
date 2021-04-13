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
        // Modelo BD Conexion
        progra6Entities3 modeloBD = new progra6Entities3();

        // GET: Lista Encabezado Factura
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
            this.AgregarDetalleViewBag();
            //enciar el modelo a la vista
            return View(modeloVista);
        }

        public ActionResult ListaFacturasClienteActual()
        {
            return View();
        }

        public ActionResult RetornaFacturasCliente(int idCliente)
        {
            List<sp_RetornaViewReportes_Result> facturasCliente = new List<sp_RetornaViewReportes_Result>();
            facturasCliente = this.modeloBD.sp_RetornaViewReportes(idCliente, null, null, null).ToList();
            return Json(new
            {
                resultado = facturasCliente
            });
        }
        /// <summary>
        /// Metodo Que Retorna Un Json Con Los Datos De Los
        /// Vehiculos Por Usuario, Accedida Mediante Jquery
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public ActionResult RetornaUsersvehiculos(int idCliente)
        {
            List<sp_RetornaDesgloseClientesVeh_ID_Result> vehiculoPorUsuario = new List<sp_RetornaDesgloseClientesVeh_ID_Result>();
            vehiculoPorUsuario = this.modeloBD.sp_RetornaDesgloseClientesVeh_ID(idCliente).ToList();
            return Json(vehiculoPorUsuario);
        }

        /// <summary>
        /// Metodod Que Retorna Una Vista Para Crear Un
        /// Nuevo Encabezado De Factura
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevoEncabezadoFactura()
        {
            this.AgregarClientesViewBag();
            this.AgregarVehiculosViewBag();
            this.AgregarEstadoFacturaViewBag();
            this.AgregarDetalleViewBag();
            this.AgregTipoSOPViewBag();
            return View();


        }

        /// <summary>
        /// Metodo Que Almacena Los Datos Ingresados En La Vista 
        /// En La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
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
                        modeloVista.EstadoFactura
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

            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Retorna La Vista Para Modificar
        /// Los Datos De Un Encabezado De Factura
        /// Accedido Por ID Encabezado
        /// </summary>
        /// <param name="idEncabezadoFac"></param>
        /// <returns></returns>
        public ActionResult ModificaEncabezadoFactura(int idEncabezadoFac)
        {
            sp_RetornaEncFactura_ID_Result modeloVista = new sp_RetornaEncFactura_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaEncFactura_ID(idEncabezadoFac).FirstOrDefault();
            AgregarClientesViewBag();
            AgregarVehiculosViewBag();
            AgregarEstadoFacturaViewBag();
            AgregarDetalleViewBag();

            return View(modeloVista);

        }

        ///Lista Modificar Estado Factura
        public ActionResult ListaEstadoFactura()
        {

            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaEncFactura_Result> modeloVista =
                new List<sp_RetornaEncFactura_Result>();

            //asignar a la variable el resultado de llamar al SP
            modeloVista = this.modeloBD.sp_RetornaEncFactura("").ToList();

            this.AgregarClientesViewBag();
            this.AgregarVehiculosViewBag();
            this.AgregarDetalleViewBag();
            //enciar el modelo a la vista
            return View(modeloVista);
        }

        public ActionResult ModificaEstadoFactura(int idEncabezadoFac)
        {
            sp_RetornaEncFactura_ID_Result modeloVista = new sp_RetornaEncFactura_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaEncFactura_ID(idEncabezadoFac).FirstOrDefault();
            AgregarClientesViewBag();
            AgregarVehiculosViewBag();
            AgregarEstadoFacturaViewBag();
            AgregarDetalleViewBag();

            return View(modeloVista);

        }
        ///Modificar Estado factura 
        [HttpPost]
        public ActionResult ModificaEstadoFactura(sp_RetornaEncFactura_ID_Result modeloVista)
        {
            int registroModificado = 0;
            string mensaje = "";

                try
                {
                    registroModificado = this.modeloBD.sp_ModificaEstadoFactura(modeloVista.idEncabezadoFac, modeloVista.EstadoFactura);
                }
                catch (Exception error)
                {

                    mensaje = "Ocurrio un Error" + error.Message;
                }
                finally
                {
                    if (registroModificado > 0)
                    {
                        mensaje = "Se Actualizo El Estado De La Factura";
                    }
                    else
                    {
                        mensaje += " No Se Actualizo El Estado Factura";
                    }
                }

                Response.Write("<script languaje=javascript>alert('" + mensaje + "');</script>");
                AgregarClientesViewBag();
                AgregarVehiculosViewBag();
                AgregarEstadoFacturaViewBag();
                AgregarDetalleViewBag();
                return View(modeloVista);
            }
            /// <summary>
            /// Metodo Que Almacena Los Datos Ingresados En La Vista
            /// En La BD
            /// </summary>
            /// <param name="modeloVista"></param>
            /// <returns></returns>
            [HttpPost]
            public ActionResult ModificaEncabezadoFactura(sp_RetornaEncFactura_ID_Result modeloVista)
            {
                int cantidadRegistrosAfectados = 0;
                string resultado = " ";

                try
                {
                    cantidadRegistrosAfectados =
                           this.modeloBD.sp_ModificaEncabezadoFac(
                               modeloVista.idEncabezadoFac,
                               modeloVista.idCliente,
                               modeloVista.idVehiculo,
                               modeloVista.Fecha,
                               modeloVista.MontoTotalServicios,
                               modeloVista.EstadoFactura
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
                        resultado = "El Registro fue Modificado";
                    }
                    else
                    {
                        resultado = "No se pudo Modifcar";
                    }
                }
                Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
                AgregarClientesViewBag();
                AgregarVehiculosViewBag();
                AgregarEstadoFacturaViewBag();
                AgregarDetalleViewBag();
                return View(modeloVista);

            }

            /// <summary>
            /// Metodo Que Muestra La Vista Para 
            /// Eliminar Un Encabezado Por Id
            /// </summary>
            /// <param name="idEncabezadoFac"></param>
            /// <returns></returns>
            public ActionResult EliminaEncabezadoFactura(int idEncabezadoFac)
            {
                ///obtener el registro que se desea modificar
                /// utilizando el parametro del metodo idPaisFabricante
                sp_RetornaEncFactura_ID_Result modeloVista = new sp_RetornaEncFactura_ID_Result();

                modeloVista = this.modeloBD.sp_RetornaEncFactura_ID(idEncabezadoFac).FirstOrDefault();

                //enviar modelo a la vista
                this.AgregarClientesViewBag();
                this.AgregarVehiculosViewBag();
                this.AgregarEstadoFacturaViewBag();
                this.AgregarDetalleViewBag();
                this.AgregTipoSOPViewBag();
                return View(modeloVista);
            }

            /// <summary>
            /// Metodo Que Elimina Un Encabezado Por ID
            /// Obtenido Desde La Vista
            /// OJO ---> Primero Eliminar Detalles Enlazados 
            /// A La Factura
            /// </summary>
            /// <param name="modeloVista"></param>
            /// <returns></returns>
            [HttpPost]
            public ActionResult EliminaEncabezadoFactura(sp_RetornaEncFactura_ID_Result modeloVista)
            {
                ///varable que registra la cantidad de registro afectados
                ///si un SP que se ejecute Insert,UPDATE,DELETE
                ///no afecta registros implica que hubo un error 
                int cantidadRegistrosAfectados = 0;
                string resultado = " ";

                try
                {
                    cantidadRegistrosAfectados =
                           this.modeloBD.sp_EliminarEncFactura(
                              modeloVista.idEncabezadoFac);
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
                this.AgregarClientesViewBag();
                this.AgregarVehiculosViewBag();
                this.AgregarEstadoFacturaViewBag();
                this.AgregarDetalleViewBag();
                this.AgregTipoSOPViewBag();
                return View(modeloVista);
            }

            /// <summary>
            /// ViewBag Lista De Vehiculos
            /// Muestra Los Datos Del Vehiculo
            /// </summary>
            void AgregarVehiculosViewBag()
            {
                this.ViewBag.ListaVehiculos =
                     this.modeloBD.sp_RetornaVehiculo("", null, null).ToList();
            }

            /// <summary>
            /// ViewBag Lista De Clientes
            /// Muestra Los Datos Del Usuario
            /// </summary>
            void AgregarClientesViewBag()
            {
                this.ViewBag.ListaClientes =
                     this.modeloBD.sp_RetornaClientes("", "").ToList();
            }

            /// <summary>
            /// ViewBag Lista De Encabezado Factura
            /// Muestra Los Datos Del Encabezado Factura
            /// </summary>
            void AgregarEstadoFacturaViewBag()
            {
                this.ViewBag.ListaEstadoFactura =
                     this.modeloBD.sp_RetornaEncFactura("").ToList();
            }

            /// <summary>
            /// ViewBag Lista Detalle Factura
            /// Muestra Los Datos Del Detalle Factura
            /// </summary>
            void AgregarDetalleViewBag()
            {
                this.ViewBag.ListaDetalles =
                     this.modeloBD.sp_RetornaDetalleFac(null).ToList();
            }

            /// <summary>
            /// ViewBag Lista De Servicios y productos
            /// Muestra Los Datos Del Servicio Producto
            /// </summary>
            void AgregTipoSOPViewBag()
            {
                this.ViewBag.ListaTipoSOP = this.modeloBD.sp_RetornaServicioOProducto(null, null).ToList();
            }

            [HttpPost]
            public ActionResult RetornaEncabezadoFactura()
            {
                List<sp_RetornaEncFactura_Result> listaEncabezadosFactura =
                    this.modeloBD.sp_RetornaEncFactura("").ToList();

                return Json(new
                {
                    resultado = listaEncabezadosFactura
                });


            }
            public ActionResult GridEncabezadoFactura()
            {
                return View();
            }
        }
    }