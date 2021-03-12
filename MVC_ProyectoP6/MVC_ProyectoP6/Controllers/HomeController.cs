using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProyectoP6.Models;

namespace MVC_ProyectoP6.Controllers
{
    public class HomeController : Controller
    {
        progra6Entities3 ModeloBD = new progra6Entities3();
        public ActionResult Index()
        {
            return View();
        }
        /*[HttpPost]
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

        public ActionResult ValidarUsuario(string pCorreo, string pContrasenia)
        {
            List<sp_RetornaClientes_Result> listaClientes = new List<sp_RetornaClientes_Result>();

            listaClientes = this.ModeloBD.sp_RetornaClientes(null, null).ToList();

            bool UsuarioVerificado = false;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].Correo.Equals(pCorreo) && listaClientes[i].Contrasenia.Equals(pContrasenia))
                {
                    UsuarioVerificado = true;
                    ///Variable De Sesion Para Guardar Id Del Usuario Actual
                    this.Session.Add("idClienteLoguedo", listaClientes[i].idCliente);
                    this.Session.Add("tipoCliente", listaClientes[i].TipoUsuario);
                    ;
                }
            }
            
            return Json(new
            {
                resultado = UsuarioVerificado
            });
        }

        public ActionResult MostrarInfoUsuario()
        {
            int idUsuarioLogueado = Convert.ToInt32(this.Session["idClienteLoguedo"]);
            List<sp_RetornaClientes_ID_Result> modeloCliente = this.ModeloBD.sp_RetornaClientes_ID(idUsuarioLogueado).ToList();

            string msj = "";

            for (int i = 0; i < modeloCliente.Count; i++)
            {
                msj = modeloCliente[i].NombreCompleto;
            }

            return Json(new
            {
                resultado = msj
            });
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
    }
}