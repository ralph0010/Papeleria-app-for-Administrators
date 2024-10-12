using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Papeleria.LogicaAplicacion.ICasosUso.IRol;
using Papeleria.LogicaAplicacion.ICasosUso.IUsuarios;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using Papeleria.LogicaNegocio.Excepciones.UsuarioException;
using Papeleria.LogicaNegocio.ValueObjects.VO.VOUsuario;
using Papeleria.MVC.Models.UsuariosVM;


namespace Papeleria.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ICUAltaUsuario CUAltaUsuario { get; set; }
        public ICUObtenerRoles CUObtenerRoles { get; set; }
        public ICUObtenerRol CUObtenerRol { get; set; }
        public ICUObtenerUsuarios CUObtenerUsuarios { get; set; }
        public ICUObtenerUsuarioByEmail CUObtenerUsuarioByEmail { get; set; }
        public ICUActualizarUsuario CUActualizarUsuario { get; set; }
        public ICUEliminarUsuario CUEliminarUsuario { get; set; }
        private static string GuardarCorreo = "";
        private static string CorreoEliminar = "";
    public UsuarioController(ICUAltaUsuario cuAltaUsuario, 
            ICUObtenerRoles cUObtenerRoles,ICUObtenerRol cUObtenerRol,
            ICUObtenerUsuarios cUObtenerUsuarios, 
            ICUObtenerUsuarioByEmail cUObtenerUsuarioByEmail, 
            ICUActualizarUsuario cUActualizarUsuario,
            ICUEliminarUsuario cUEliminarUsuario) 
        {
            CUAltaUsuario = cuAltaUsuario;
            CUObtenerRoles = cUObtenerRoles;
            CUObtenerRol = cUObtenerRol;
            CUObtenerUsuarios = cUObtenerUsuarios;
            CUObtenerUsuarioByEmail = cUObtenerUsuarioByEmail;
            CUActualizarUsuario = cUActualizarUsuario;
            CUEliminarUsuario = cUEliminarUsuario;
        }
        //Verifica que el usuario no haya modificado el email
        private void ValidarEmail(string email)
        {
            if(GuardarCorreo != email)
            {
                throw new Exception("Error, no puede modificar el email");
            }
        }
        //Obtiene los roles de Usuario
        private IEnumerable<RolViewModel> ObtenerRoles()
        {
            IEnumerable<RolViewModel> rolViewModels = new List<RolViewModel>();
            rolViewModels = CUObtenerRoles.GetRoles().Select
                (r => new RolViewModel()
                {
                    Id = r.Id,
                    TipoRol = r.TipoRol,
                }).ToList();
            return rolViewModels;
        }
        //Obtiene todos los usuarios de la base de datos
        private IEnumerable<MostrarListadoUsuariosViewModel> ObtenerUsuarios()
        {
            IEnumerable<MostrarListadoUsuariosViewModel> usersVM = new
                List<MostrarListadoUsuariosViewModel>();
            usersVM = CUObtenerUsuarios.GetUsuarios().Select
                (u => new MostrarListadoUsuariosViewModel()
                {
                    Email = u.Emaill.Email,
                    Nombre = u.NombreApellido.Nombre,
                    Apellido = u.NombreApellido.Apellido
                }
                ).ToList();
            return usersVM;
        }
        // GET: UsuarioController
        //Muestra todos los usuarios y las opciones: Modificar y Eliminar
        public ActionResult Index()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                IEnumerable<MostrarListadoUsuariosViewModel> usVM = ObtenerUsuarios();
                return View(usVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // GET: UsuarioController/Details/5
        //public ActionResult Details(int id)
        //{
            
        //    return View();
        //}

        // GET: UsuarioController/Create
        //Vista para crear Usuario
        public ActionResult Create()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                UsuarioViewModel userVM = new UsuarioViewModel();
                userVM.Roles = ObtenerRoles();
                return View(userVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioVM)
        {
            try
            {
                string? rolSesion = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rolSesion) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (usuarioVM == null)
                        {
                            throw new Exception("Usuario invalido");
                        }
                    }
                    else
                    {
                        throw new Exception("Datos Invalidos");
                    }

                    Rol rol = CUObtenerRol.ObtenerRol(usuarioVM.RolId);


                    Usuario usuario = new Usuario()
                    {
                        Emaill = new Correo(usuarioVM.Email),
                        Passwordd = new PasswordUsuarioVO(usuarioVM.Password),
                        NombreApellido = new NombreApellidoVO(usuarioVM.Nombre, usuarioVM.Apellido),
                    };
                    if (rol != null)
                    {
                        usuario.Rol = rol;
                    }
                    else
                    {
                        throw new Exception("Error de datos con rol");
                    }
                    CUAltaUsuario.DarAlta(usuario);
                    ViewBag.Exito = "Usuario dado de alta correctamente";
                    return Redirect(nameof(Index));

                }
                catch (EmailInvalidoException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (PasswordInvalidaException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (NombreApellidoException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (UsuarioInvalidoException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;

                }
                usuarioVM.Roles = ObtenerRoles();
                return View(usuarioVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // GET: UsuarioController/Edit/5
        //Mostrar vista para editar usuario
        public ActionResult Edit(string email)
        {
            try
            {
                string? rolSesion = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rolSesion) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                try
                {
                    if (string.IsNullOrEmpty(email))
                    {
                        throw new Exception("Error, usuario inválido");
                    }
                    Usuario us = CUObtenerUsuarioByEmail.ObtenerUsuario(email);
                    if (us == null)
                    {
                        throw new Exception("Error, no se encontró usuario");
                    }
                    EditarUsuarioVM userVM = new EditarUsuarioVM
                        (us.Id, us.Emaill.Email, us.Passwordd.Password,
                        us.NombreApellido.Nombre, us.NombreApellido.Apellido);
                    GuardarCorreo = userVM.Email;
                    return View(userVM);

                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
                return View();
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditarUsuarioVM usVM)
        {
            try
            {
                string? rolSesion = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rolSesion) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                try
                {


                    if (usVM == null)
                    {
                        throw new Exception("Error, no existe usuario para actualizar");
                    }
                    ValidarEmail(usVM.Email);

                    Correo correo = new Correo(usVM.Email);
                    NombreApellidoVO nombreApellidoVO = new NombreApellidoVO
                        (usVM.Nombre, usVM.Apellido);
                    PasswordUsuarioVO password = new PasswordUsuarioVO(usVM.Password);
                    Usuario usuario = new Usuario()
                    {
                        Emaill = new Correo(usVM.Email),
                        NombreApellido = nombreApellidoVO,
                        Passwordd = password,
                    };
                    CUActualizarUsuario.Actualizar(usuario);
                    GuardarCorreo = "";
                    return RedirectToAction(nameof(Index));
                }
                catch (EmailInvalidoException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (PasswordInvalidaException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (NombreApellidoException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.Message;
                }
                usVM.Email = GuardarCorreo;
                return View(usVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // GET: UsuarioController/Delete/5
        //Para mostrar la vista de eliminar Usuario

        public ActionResult Delete(string email)
        {
            try
            {
                string? rolSesion = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rolSesion) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                Usuario us = CUObtenerUsuarioByEmail.ObtenerUsuario(email);
                MostrarListadoUsuariosViewModel usVM = new
                    MostrarListadoUsuariosViewModel()
                {
                    Email = us.Emaill.Email,
                    Nombre = us.NombreApellido.Nombre,
                    Apellido = us.NombreApellido.Apellido,

                };
                return View(usVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // POST: UsuarioController/Delete/5
        //Para eliminar     Usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MostrarListadoUsuariosViewModel usVM)
        {
            try
            {
                string? rolSesion = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rolSesion) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                try
                {
                    if (usVM == null)
                    {
                        throw new Exception("Error, no se pudo eliminar el " +
                            "usuario");
                    }
                    Usuario us = CUObtenerUsuarioByEmail.ObtenerUsuario
                        (usVM.Email);
                    CUEliminarUsuario.Eliminar(us);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View(usVM);
                }
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }
    }
}
