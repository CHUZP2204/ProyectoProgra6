using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;
using System.Net;
using System.Net.Mail;

namespace MVC_ProyectoP6.Controllers
{
    public class HomeController : Controller
    {
        progra6Entities3 ModeloBD = new progra6Entities3();

        public ActionResult Index()
        {
            AgregaProvinciasViewBag();
            return View();
        }
        /*[HttpPost] 
         * Metodo Del Lado Del Servidor 
         * Ignorar Si Se Usa JQUERY
        public ActionResult Index(sp_RetornaClientes_Result modeloVista)
        {
           string contraseniaObtenida = modeloVista.Contrasenia;
            string usuarioObtenido = modeloVista.Correo;

            List<sp_RetornaClientes_Result> listaClientes = new List<sp_RetornaClientes_Result>();

            listaClientes = this.ModeloBD.sp_RetornaClientes(null, null).ToList();

            bool UsuarioVerificado = false;
            
            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].Correo.Equals(usuarioObtenido) && listaClientes[i].Contrasenia.Equals(contraseniaObtenida))
                {
                    UsuarioVerificado = true;
                }
            }
            if (UsuarioVerificado)
            {
                return RedirectToAction("ListaMarcaVehiculos", "MarcaVehiculo");
            }
            else
            {
               // Response.Write("<script>alert('NO SE PUDO INICIAR SESION <br/> INTENTE DE NUEVO!')</script>");
            }
            return View();
        }*/

        /// <summary>
        /// Metodo Que valida El Usuario Que Desee Inicar Session
        /// Devuelve True o False 
        /// </summary>
        /// <param name="pCorreo"></param>
        /// <param name="pContrasenia"></param>
        /// <returns></returns>
        public ActionResult ValidarUsuario(string pCorreo, string pContrasenia)
        {
            ///LLAMAR AL METODO QUE VERIFICA SI USUARIO EXISTE
            bool eventoResul = this.VerificarUsuario(pCorreo, pContrasenia);

            ///Retornar En Json Para Trabajarlo
            ///Del Lado Del Cliente
            return Json(new
            {
                resultado = eventoResul
            });
        }


        /// <summary>
        /// METODO QUE VERIFICA SI EL USUARIO
        /// EXISTE EN LA BD 
        /// ESTO PARA PODER INGRESAR AL SISTEMA
        /// </summary>
        /// <param name="pCorreo"></param>
        /// <param name="pContrasenia"></param>
        /// <returns></returns>
        private bool VerificarUsuario(string pCorreo, string pContrasenia)
        {
            List<sp_RetornaClientes_Result> listaClientes = new List<sp_RetornaClientes_Result>();
            listaClientes = this.ModeloBD.sp_RetornaClientes(null, null).ToList();

            bool UsuarioVerificado = false;

            ///Recorrer Lista De Usuarios Registrados
            ///True Si se Cumple La Contrasenia y Correo A La Vez
            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].Correo.Equals(pCorreo) && listaClientes[i].Contrasenia.Equals(pContrasenia))
                {

                    ///Variable De Sesion Para Guardar Id Del Usuario Actual
                    this.Session.Add("idClienteLoguedo", listaClientes[i].idCliente);
                    this.Session.Add("tipoCliente", listaClientes[i].TipoUsuario);
                    UsuarioVerificado = true;
                }
            }
            return UsuarioVerificado;
        }
        /// <summary>
        /// Metodo Que Obtiene Informacion Del Cliente Actual Que Inicio Session
        /// Se Devuelve En Json Para Su Posterior Uso Del Lado Del Cliente
        /// </summary>
        /// <returns></returns>
        public ActionResult MostrarInfoUsuario()
        {
            int idUsuarioLogueado = Convert.ToInt32(this.Session["idClienteLoguedo"]);
            List<sp_RetornaClientes_ID_Result> modeloCliente = this.ModeloBD.sp_RetornaClientes_ID(idUsuarioLogueado).ToList();

            string msj = "";
            int idUsuario = 0;
            string tipoUsuarioConectado;
            ///Validar Si La Variable De Session Esta Vacia
            if (this.Session["tipoCliente"] == null)
            {
                tipoUsuarioConectado = "vacio";
            }
            else
            {
                tipoUsuarioConectado = this.Session["tipoCliente"].ToString();
            }

            ///Del Usuario Que Inicio Sesion, Por Medio
            ///De La variable De Sesion Obtener Los Datos.
            /// Recorrer Lista De Usuario Obtenido Por ID
            /// Obtener ID y El Nombre De Usuario
            for (int i = 0; i < modeloCliente.Count; i++)
            {
                msj = modeloCliente[i].NombreCompleto;
                idUsuario = modeloCliente[i].idCliente;
            }

            return Json(new
            {
                resultado = msj,
                usuarioActual = idUsuario,
                tipoUsuario = tipoUsuarioConectado
            });
        }

        /// <summary>
        /// Metodo Que Borra La Variable De Sesion 
        /// Con Datos Del Usuario Actual Conectado 
        /// </summary>
        /// <returns></returns>
        public ActionResult CerrarSesionCliente()
        {
            int idUsuarioLogueado = Convert.ToInt32(this.Session["idClienteLoguedo"]);

            string msj = "";
            if (idUsuarioLogueado > 0)
            {
                msj = "L";
                this.Session.Add("idClienteLoguedo", 0);
            }


            return Json(new
            {
                resultado = msj
            });
        }

        /// <summary>
        /// Metodo Que Muestra La Pagina Principal 
        /// Del Proyecto Con Los Debidos Accesos
        /// </summary>
        /// <returns></returns>
        public ActionResult PaginaPrincipal()
        {

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Metodo Que Recibe Los Parametros Para
        /// Registrar Cliente Con Jquery
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult RegistrarUsuario(string pCedula,
            DateTime pFecha,
            string pGenero,
            string pNombreC,
            string pCorreo,
            int pIdProvincia,
            int pIdCanton,
            int pIdDistrito,
            string pTipoUsuario,
            string pContrasenia)
        {
            ///Variable Que Registra La Cantidad De Registros Afectados
            ///Si Un Procedimiento Que Ejecuta Insert, Update o Delete
            ///No Afecta Registros Implica Que Hubo Un Error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            /// Verificar Si Usuario Existe En BD 

            sp_RetornaClientes_Result ModeloVerificar = new sp_RetornaClientes_Result();

            ModeloVerificar = this.ModeloBD.sp_RetornaClientes(null, pCedula).FirstOrDefault();

            List<sp_RetornaClientes_Result> ModeloVerificar1 = new List<sp_RetornaClientes_Result>();

            ModeloVerificar1 = this.ModeloBD.sp_RetornaClientes(null, null).ToList();

            bool correoEncontrado = false;
            for (int i = 0; i < ModeloVerificar1.Count; i++)
            {
                if (ModeloVerificar1[i].Correo.Equals(pCorreo))
                {
                    correoEncontrado = true;
                }

            }



            /// try Instrucciones que se intenta Realizar
            /// Catch Administra las exepciones o errores
            /// Finally Siempre se ejecuta exista o no error
            try
            {
                ///Si El Modelo
                if (ModeloVerificar == null)
                {
                    if (correoEncontrado == true)
                    {
                        resultado = " Ya Existe Un Cliente En Sistema Con El Correo Ingresado";
                    }
                    else
                    {
                        cantRegistrosAfectados =
                       this.ModeloBD.sp_InsertaCliente(
                        pCedula,
                        pFecha,
                        pGenero,
                        pNombreC,
                        pCorreo,
                        pIdProvincia,
                        pIdCanton,
                        pIdDistrito,
                        pTipoUsuario,
                        pContrasenia
                        );


                        ///Enviar Un Correo  Al Nuevo Usuario Registrado
                        MailMessage email = new MailMessage();
                        MailAddress de = new MailAddress("segurossigloxxi44@gmail.com");

                        email.To.Add(pCorreo);


                        email.From = de;
                        email.Priority = MailPriority.Normal;
                        email.IsBodyHtml = false;
                        email.Subject = "ASUNTO: " + "Su Cuenta En ServiRapidos WyJ SA";
                        email.Body = $"Estimado Cliente: { pNombreC} Cedula: { pCedula}" +
                                     $" Gracias Por Confiar En ServiRapidos WyJ SA" +
                                     $" Para Nosotros Es Un  Placer Servirle";

                        ///segurossigloxxi44@gmail.com
                        ///a2b3c4d05
                        SmtpClient enviar = new SmtpClient();

                        enviar.Host = "smtp.gmail.com";
                        enviar.Credentials = new NetworkCredential("segurossigloxxi44@gmail.com", "a2b3c4d05");
                        enviar.EnableSsl = true;
                        enviar.Send(email);
                        email.Dispose();
                        ///Fin Enviar Correo
                    }

                }
                else if (ModeloVerificar.Cedula.Equals(pCedula))
                {
                    resultado = " Ya Existe Un Cliente En Sistema Con La Cedula ingresada";
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
                    resultado = "El Usuario Se Regitro Exitosamente";
                }
                else
                {
                    resultado += " No Se Pudo Registrar";
                }
            }

            return Json(resultado);
        }
        /// <summary>
        /// Cargar Lista De Provincias Al DDl
        /// </summary>
        void AgregaProvinciasViewBag()
        {
            this.ViewBag.ListaProvincias = this.ModeloBD.sp_RetornaProvincias("", null).ToList();
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
            modeloVista = ModeloBD.sp_RetornaCantones("", id_Provincia).ToList();

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
            modeloVista = ModeloBD.sp_RetornaDistritos("", id_Canton).ToList();

            /// Los Parametros Dentro De 
            /// SelectList(dataValueField,dataTextField)
            /// Se Convierte a un objeto de tipo JSON
            return Json(new SelectList(modeloVista, "id_Distrito", "Distrito"));

        }
    }
}