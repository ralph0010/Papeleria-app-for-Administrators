using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.ICasosUso.ICliente;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.ClienteException;
using Papeleria.MVC.Models.ClientesVM;
using Papeleria.MVC.Models.ClientesVM.GetClientesByMonto;

namespace Papeleria.MVC.Controllers
{
    public class ClienteController : Controller
    {
        public ICUGetClienteByRazonSocial CUGetClienteByRazonSocial { get; set; }
        public ICUGetClientesByMonto CUGetClientesByMonto { get; set; }
        public ClienteController(ICUGetClienteByRazonSocial cuGetClienteByRazonSocial,
            ICUGetClientesByMonto cuGetClientesByMonto)
        {
            CUGetClienteByRazonSocial = cuGetClienteByRazonSocial;
            CUGetClientesByMonto = cuGetClientesByMonto;
        }
        //Muestra todos los clientes en una tabla
        public IActionResult Index()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                IEnumerable<MostrarClientesByRazonSocialViewModel> clientes =
                    new List<MostrarClientesByRazonSocialViewModel>();
                return View(clientes);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
        }
        //get
        //Mostrará la vista con un buscador par clientes
        public IActionResult MostrarClientesPorRazonSocial()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                BuscarCliente cliente = new BuscarCliente();
                return View(cliente);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
        }
        //Muestra los clientes mediante la razon social
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MostrarClientesPorRazonSocial(BuscarCliente clienteBuscar)
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                try
                {
                    IEnumerable<Cliente> clientes = CUGetClienteByRazonSocial.
                          GetCliente(clienteBuscar.RazonSocial).ToList();
                    
                    IEnumerable<MostrarClientesByRazonSocialViewModel> clientesVM =
                       MapperClientes.ClienteToClienteVMFind(clientes);
                    
                    clienteBuscar.clientes = clientesVM;
                    return View(clienteBuscar);
                }
                catch(ClienteException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(clienteBuscar);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }

        }
        //Vista para mostrar los clientes e ingresar un monto
        public IActionResult GetClientesByMonto()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                GetClienteByMontoViewModel clienteVM = new GetClienteByMontoViewModel();
                return View(clienteVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
        }
        //Muestra los clientes que supera el monto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetClientesByMonto(GetClienteByMontoViewModel clienteVM)
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                try
                {
                    IEnumerable<Cliente> clientes = CUGetClientesByMonto.
                        getClientes(clienteVM.Monto).ToList();
                    IEnumerable<MostrarClientesByRazonSocialViewModel> clientesVM
                        = MapperClientes.ClienteToClienteVMFind(clientes);
                    if (!clientesVM.Any())
                    {
                        throw new Exception("No se encontró ningún cliente que sobrepase el monto");
                    }
                    clienteVM.clientesVM = clientesVM;
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }

                return View(clienteVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
