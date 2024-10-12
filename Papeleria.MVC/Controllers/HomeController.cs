using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.ICasosUso.IUsuarios;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using Papeleria.MVC.Models;
using Papeleria.MVC.Models.UsuariosVM;
using System.Diagnostics;

namespace Papeleria.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICUIniciarSesion CUIniciarSesion { get; set; }


        public HomeController(ILogger<HomeController> logger, ICUIniciarSesion cuIniciarSesion)
        {
            _logger = logger;
            CUIniciarSesion = cuIniciarSesion;
        }
        //Muestra el inicio de la aplicacion, si hay un usuario iniciado mostrará un mensaje personalizado
        public IActionResult Index(string nombreUsuario)
        {
            ViewBag.Usuario = nombreUsuario;
            return View();
        }
        //get
        //Muestra la vista para iniciar sesion
        public IActionResult IniciarSesion()
        {
            try
            {
                string? email = HttpContext.Session.GetString("EmailUsuario");

                if (!string.IsNullOrEmpty(email))
                {
                    throw new Exception();
                }
                return View();
            }
            catch (Exception ex) 
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction(nameof(Error));
            }
            
        }
        //Realizara el inicio de sesion si es valido sino muestra un mensaje

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IniciarSesion(IniciarSesionUsuarioVM usuario)
        {
            try
            {
                string? email = HttpContext.Session.GetString("EmailUsuario");

                if (!string.IsNullOrEmpty(email))
                {
                    throw new Exception();
                }
                try
                {
                    Usuario userIngresado = CUIniciarSesion.IniciarSesion(usuario.Email, usuario.Password);
                    HttpContext.Session.SetString("EmailUsuario", userIngresado.Emaill.Email);
                    HttpContext.Session.SetString("Rol", userIngresado.Rol.TipoRol);
                    return RedirectToAction(nameof(Index),
                        new { nombreUsuario = userIngresado.NombreApellido.Nombre + " " + userIngresado.NombreApellido.Apellido });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
                return View();
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction(nameof(Error));
            }
            
        }
        //Realiza el logout
        public IActionResult Logout()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                if (rol == null)
                {
                    throw new Exception("Error no tiene acceso a la página");
                }
                string? emailLogueado = HttpContext.Session.GetString
                    ("EmailUsuario");
                if(emailLogueado != null)
                {
                    HttpContext.Session.Clear();
                }

            }
            catch (Exception ex) 
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction(nameof(Error));
            }
            return RedirectToAction(nameof(IniciarSesion));
        }
        //Pagina de Acceso denegado con un mensaje de Error
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
