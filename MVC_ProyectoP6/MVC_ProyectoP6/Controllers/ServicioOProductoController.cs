using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class ServicioOProductoController : Controller
    { 
        progra6Entities3 modeloBD = new progra6Entities3();
    
        // GET: ServicioOProducto
        public ActionResult ListaServicioOProducto()
        {
            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaServicioOProducto_Result> modeloVista =  new List<sp_RetornaServicioOProducto_Result>();

            //asignar a la variable el resultado de llamar al SP
            modeloVista = this.modeloBD.sp_RetornaServicioOProducto("", "").ToList();

            //enciar el modelo a la vista
            return View(modeloVista);
        }

        public ActionResult NuevoServicioOproducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoServicioOproducto(sp_RetornaServicioOProducto_Result modeloVista)
        {
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";
            try
            {
                cantidadRegistrosAfectados =
                    this.modeloBD.sp_InsertaServicioOProducto(
                        modeloVista.CodigoSOP,
                        modeloVista.PrecioSOP.ToString(),
                        modeloVista.TipoSOP,
                        modeloVista.idCliente
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
                    resultado = "Registro Modificado";
                }
                else
                {
                    resultado += "No se pudo Modificar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            return View();
        }

        public ActionResult ModificaServicioOProducto(int idSOP)
        {
            ///obtener el registro que se desea modificar
            /// utilizando el parametro del metodo idPaisFabricante
            sp_RetornaServiciosOProductos_ID_Result modeloVista = new sp_RetornaServiciosOProductos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaServiciosOProductos_ID(idSOP).FirstOrDefault();
            //enviar modelo a la vista
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult ModificaServicioOProducto(sp_RetornaServiciosOProductos_ID_Result modeloVista)
        {
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";
            try
            {
                cantidadRegistrosAfectados =
                    this.modeloBD.sp_ModificaServicioOProducto(
                        modeloVista.idSOP,
                        modeloVista.CodigoSOP,
                        modeloVista.PrecioSOP.ToString(),
                        modeloVista.TipoSOP,
                        modeloVista.idCliente
                     
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
            return View(modeloVista);
        }
        public ActionResult EliminaServicioOProducto( int idSOP)
        {
            ///obtener el registro que se desea modificar
            /// utilizando el parametro del metodo idPaisFabricante
            sp_RetornaServiciosOProductos_ID_Result modeloVista = new sp_RetornaServiciosOProductos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaServiciosOProductos_ID(idSOP).FirstOrDefault();
            //enviar modelo a la vista
            return View(modeloVista);

        }

        [HttpPost]
        public ActionResult EliminaServicioOProducto(sp_RetornaServiciosOProductos_ID_Result modeloVista)
        {
            int cantidadRegistrosAfectados = 0;
            string resultado = " ";
            try
            {
                cantidadRegistrosAfectados =
                    this.modeloBD.sp_EliminaServicioOProducto(
                       modeloVista.idSOP
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
                    resultado = "Registro Eliminado";
                }
                else
                {
                    resultado += "No se pudo Eliminar";
                }
            }
            Response.Write("<script languaje=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }
    }
}
