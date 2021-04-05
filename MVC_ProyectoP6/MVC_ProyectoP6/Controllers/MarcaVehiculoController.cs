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
        // Modelo BD Conexion
        progra6Entities3 modeloBD = new progra6Entities3();

        /// <summary>
        /// Metodo Que Retorna La Vista Con Los
        /// Datos Lista De Marcas De Vehiculos
        /// </summary>
        /// <returns></returns>
        public ActionResult ListaMarcaVehiculos()
        {
            ///Variable De Sesion De Usuario Actual
            string idUsuarioLogueado = Convert.ToString(this.Session["idClienteLoguedo"]);

            ///crear la variable que contiene el registro obtenidos
            ///mediante invocar al procedimiento almacenados 
            List<sp_RetornaMarcaVehiculo_Result> modeloVista =
                new List<sp_RetornaMarcaVehiculo_Result>();

            //asignar a la variable el resultado de llamar al SP
            modeloVista = this.modeloBD.sp_RetornaMarcaVehiculo("", "").ToList();
            this.AgregarPaisesViewBag();
            //enciar el modelo a la vista
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Retorna La Vista Para
        /// Agregar Una Nueva Marca
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevaMarcaVehiculo()
        {
            this.AgregarPaisesViewBag();
            return View();
        }

        /// <summary>
        /// Metodo Que Almacena Los Datos
        /// Ingresados En La Vista En La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NuevaMarcaVehiculo(sp_RetornaMarcaVehiculo_Result modeloVista)
        {
            List<sp_RetornaMarcaVehiculo_Result> modeloVista1 = new List<sp_RetornaMarcaVehiculo_Result>();

            ///Asignar a la variable el resultado de llamar o invocar al Procedimiento almacenado
            modeloVista1 = this.modeloBD.sp_RetornaMarcaVehiculo(modeloVista.CodigoMarcaVehiculo, "").ToList();

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
                    if (modeloVista1[i].CodigoMarcaVehiculo.Equals(modeloVista.CodigoMarcaVehiculo))
                    {

                        NombreEncontrado = 1;

                    }
                }

                ///Si la variable permanece en 0 significa que no hay ningun dato con 
                ///ese nombre en la BD, Y Se Podra Asignar Los Nuevos Datos
                if (NombreEncontrado == 0)
                {
                    cantidadRegistrosAfectados =
                     this.modeloBD.sp_InsertaMarcaVehiculo(
                         modeloVista.CodigoMarcaVehiculo,
                         modeloVista.TipoMarcaVehiculo,
                         modeloVista.idPaisFabricante
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
            this.AgregarPaisesViewBag();
            return View();
        }

        /// <summary>
        /// Metodo Que Retorna La Vista Para 
        /// Modificar Los Datos De Una Marca
        /// Por Medio De Un ID
        /// </summary>
        /// <param name="idMarcaVehiculo"></param>
        /// <returns></returns>
        public ActionResult ModificaMarcaVehiculo(int idMarcaVehiculo)
        {
            sp_RetornaMarcasVehiculo_ID_Result modeloVista = new sp_RetornaMarcasVehiculo_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaMarcasVehiculo_ID(idMarcaVehiculo).FirstOrDefault();
            this.AgregarPaisesViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Almacena Los Datos 
        /// Ingresados En La Vista En La BD
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
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
                    resultado = "Registro Modificado";
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

        /// <summary>
        /// Metodo Que Retorna La Vista 
        /// Para Eliminar Datos De Una
        /// Marca Vehiculo
        /// </summary>
        /// <param name="idMarcaVehiculo"></param>
        /// <returns></returns>
        public ActionResult EliminaMarcaVehiculo(int idMarcaVehiculo)
        {
            sp_RetornaMarcasVehiculo_ID_Result modeloVista = new sp_RetornaMarcasVehiculo_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaMarcasVehiculo_ID(idMarcaVehiculo).FirstOrDefault();
            this.AgregarPaisesViewBag();
            return View(modeloVista);
        }

        /// <summary>
        /// Metodo Que Borra De La BD 
        /// Los Datos De La Vista Por El
        /// Id Obtenido De La Misma
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
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

        /// <summary>
        /// ViewBag Con Los Datos De
        /// Lista De Paises Disponibles
        /// </summary>
        void AgregarPaisesViewBag()
        {
            this.ViewBag.ListaPaises =
                 this.modeloBD.sp_RetornaPaisFabricante(null, null).ToList();
        }

        [HttpPost]
        public ActionResult RetornaMarcaVehiculo()
        {
            List<sp_RetornaMarcaVehiculo_Result> listaMarcaVehiculos =
                this.modeloBD.sp_RetornaMarcaVehiculo("", "").ToList();

            return Json(new
            {
                resultado = listaMarcaVehiculos
            });


        }
        public ActionResult GridMarcaVehiculo()
        {
            this.AgregarPaisesViewBag();
            return View();
        }
    }
}
