using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class UsuariosController : Controller
    {
        //Conexion Con Modelo BD
        progra6Entities3 modeloBD = new progra6Entities3();

        // GET: Usuarios
        public ActionResult ListaUsuario()
        {
            List<sp_RetornaClientes_Result> modeloVista = new List<sp_RetornaClientes_Result>();

            modeloVista = this.modeloBD.sp_RetornaClientes("", "").ToList();

            return View(modeloVista);
        }

        public ActionResult NuevoUsuario()
        {
            this.AgregaProvinciasViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario(sp_RetornaClientes_Result modeloVista)
        {
            List<sp_RetornaClientes_Result> ModeloVista1 = new List<sp_RetornaClientes_Result>();
            ModeloVista1 = this.modeloBD.sp_RetornaClientes(null,null).ToList();
            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error
            int cantRegistrosAfectados = 0;
            string resultado = "";

            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {
                ///Variable Que Guardara 1 si se encuentra un Dato, de lo contrario sera 0
                ///Recorrer El Modelo Obtenido Con Los Datos Ingresados Por usuario "modeloVista"
                ///Y Compararlo con el modelovista del view
                for (int i = 0; i < ModeloVista1.Count; i++)
                {
                    ///Aqui Se Verifica Si Existe O No El Mismo Codigo
                    if (ModeloVista1[i].Cedula.Equals(modeloVista.Cedula))
                    {
                        cantRegistrosAfectados = 1;
                    }
                    else if (ModeloVista1[i].Correo.Equals(modeloVista.Correo))
                    {
                        cantRegistrosAfectados = 1;
                    }
                    else
                    {
                        cantRegistrosAfectados = 0;
                    }

                     if (cantRegistrosAfectados == 0)
                    {
                          cantRegistrosAfectados =
                                      this.modeloBD.sp_InsertaCliente(
                                          modeloVista.Cedula,
                                          modeloVista.FechaNacimiento,
                                          modeloVista.Genero,
                                          modeloVista.NombreCompleto,
                                          modeloVista.Correo,
                                          modeloVista.idProvincia,
                                          modeloVista.idCanton,
                                          modeloVista.idDistrito,
                                          modeloVista.TipoUsuario,
                                          modeloVista.Contrasenia
                                          );   
                    }
                     else
                    {
                          cantRegistrosAfectados = 0;

                    }
                   
                }
   
            }
            catch (Exception error)
            {
                resultado = "Ocurrio Un Error" + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro Insertado";
                }
                else
                {
                    resultado += "No se Insertar cedula o correo ya existen";
                }
            }

            Response.Write("<script language=javascript>" +
                "alert('" + resultado + "');" +
                "</script>");

            this.AgregaProvinciasViewBag();
            return View();
        }
        /// <summary>
        /// Vista Modificar
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public ActionResult ModificaUsuario(int idCliente)
        {
            ///Obtener El Registro Que Se Desea Modifcar
            ///Utilizando El Parametro del Metodo id_Persona
            sp_RetornaClientes_ID_Result modeloVista = new sp_RetornaClientes_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaClientes_ID(idCliente).FirstOrDefault();

            AgregaCantonesViewBag();
            AgregaDistritosViewBag();
            this.AgregaProvinciasViewBag();
            ///Enviar el modelo a la vista
            return View(modeloVista);

        }
        /// <summary>
        /// Metodo Para Modificar datos Del Cliente
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModificaUsuario(sp_RetornaClientes_ID_Result modeloVista)
        {
            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_ModificaCliente(
                        modeloVista.idCliente,
                        modeloVista.Cedula,
                        modeloVista.FechaNacimiento,
                        modeloVista.Genero,
                        modeloVista.NombreCompleto,
                        modeloVista.Correo,
                        modeloVista.idProvincia,
                        modeloVista.idCanton,
                        modeloVista.idDistrito,
                        modeloVista.TipoUsuario,
                        modeloVista.Contrasenia
                        );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio Un Error" + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "El Registro Fue Modificado";
                }
                else
                {
                    resultado += "El Registro No Se Pudo Modificar";
                }
            }

            Response.Write("<script language=javascript>" +
                "alert('" + resultado + "');" +
                "</script>");

            this.AgregaProvinciasViewBag();
            AgregaCantonesViewBag();
            AgregaDistritosViewBag();
            return View(modeloVista);
        }

        public ActionResult EliminaUsuario(int idCliente)
        {
            ///Obtener El Registro Que Se Desea Modifcar
            ///Utilizando El Parametro del Metodo id_Persona
            sp_RetornaClientes_ID_Result modeloVista = new sp_RetornaClientes_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaClientes_ID(idCliente).FirstOrDefault();

            this.AgregaProvinciasViewBag();
            AgregaCantonesViewBag();
            AgregaDistritosViewBag();
            ///Enviar el modelo a la vista
            return View(modeloVista);

        }

        [HttpPost]
        public ActionResult EliminaUsuario(sp_RetornaClientes_ID_Result modeloVista)
        {
            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error

            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_EliminaCliente(modeloVista.idCliente);
            }
            catch (Exception error)
            {
                    resultado += "Ocurrio un error: "+error.InnerException;                
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro Eliminado";
                }
                else
                {
                    resultado = "No Se Pudo Eliminar";
                }
            }

            this.AgregaProvinciasViewBag();
            AgregaCantonesViewBag();
            AgregaDistritosViewBag();
            Response.Write("<script language=javascript>" + "alert('" + resultado + "');" + "</script>");
            return View(modeloVista);
        }

        /// <summary>
        /// Cargar Lista De Provincias Al DDl
        /// </summary>
        void AgregaProvinciasViewBag()
        {
            this.ViewBag.ListaProvincias = this.modeloBD.sp_RetornaProvincias("", null).ToList();
        }
        void AgregaCantonesViewBag()
        {
            this.ViewBag.ListaCantones = this.modeloBD.sp_RetornaCantones("", null).ToList();
        }
        void AgregaDistritosViewBag()
        {
            this.ViewBag.ListaDistritos = this.modeloBD.sp_RetornaDistritos("", null).ToList();
        }

        /// <summary>
        /// Metodo Que Retorna Los Cantones Por Id de Provincia 
        /// y Se Accede Por Medio de Jquery Ajax
        /// </summary>
        /// <param name="id_Provincia"></param>
        /// <returns></returns>
        public ActionResult AgregaCantones(int id_Provincia)
        {
            List<sp_RetornaCantones_Result> modeloVista = new List<sp_RetornaCantones_Result>();
            modeloVista = modeloBD.sp_RetornaCantones("", id_Provincia).ToList();

            /// Los Parametros Dentro De 
            /// SelectList(dataValueField,dataTextField)
            /// 
            return Json(new SelectList(modeloVista, "id_Canton", "Canton"));

        }

        /// <summary>
        /// Metodo Que Retorna Los Distritos Por Id de Canton 
        /// y Se Accede Por Medio de Jquery Ajax
        /// </summary>
        /// <param name="id_Canton"></param>
        /// <returns></returns>
        public ActionResult AgregaDistritos(int id_Canton)
        {
            List<sp_RetornaDistritos_Result> modeloVista = new List<sp_RetornaDistritos_Result>();
            modeloVista = modeloBD.sp_RetornaDistritos("", id_Canton).ToList();

            /// Los Parametros Dentro De 
            /// SelectList(dataValueField,dataTextField)
            /// Se Convierte a un objeto de tipo JSON
            return Json(new SelectList(modeloVista, "id_Distrito", "Distrito"));

        }

        public ActionResult ListaVehiculoCliente()
        {
            return View();
        }

        public ActionResult VehiculoCliente()
        {
            int idUsuarioLogueado = Convert.ToInt32(this.Session["idClienteLoguedo"]);
            List<sp_RetornaVehiculosXCliente_Result> vehiculosCliente = this.modeloBD.sp_RetornaVehiculosXCliente(idUsuarioLogueado).ToList();

            return Json(new { resultado = vehiculosCliente });
        }

        [HttpPost]
        public ActionResult RetornaClientes()
        {
            List<sp_RetornaClientes_Result> listaClientes =
                this.modeloBD.sp_RetornaClientes("", "").ToList();

            return Json(new
            {
                resultado = listaClientes
            });


        }
        public ActionResult GridClientes()
        {
            return View();
        }
    

    }

}