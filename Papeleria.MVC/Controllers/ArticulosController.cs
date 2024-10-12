using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.ArticuloException;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValueArticulo;
using Papeleria.MVC.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.MVC.Controllers
{
    public class ArticulosController : Controller
    {
        public ICUAgregarArticulo CUAgregarArticulos { get; set; }
        public ICUObtenerArticulos CUObtenerArticulos { get; set; }
        public ArticulosController(ICUAgregarArticulo cuAgregarArticulos, ICUObtenerArticulos cUObtenerArticulos)
        {
            CUAgregarArticulos = cuAgregarArticulos;
            CUObtenerArticulos = cUObtenerArticulos;
        }
        //GET: ArticulosController
        //Muestra un listado de todos los articulos
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
                IEnumerable<ArticuloViewModel> articulosVM =
                new List<ArticuloViewModel>();
                articulosVM = CUObtenerArticulos.GetArticulos().
                    Select(e => new ArticuloViewModel()
                    {
                        Cantidad = e.Stock,
                        CantPrecio = e.Precio,
                        Codigo = e.Codigo.Codigo,
                        Descripcion = e.Descripcion,
                        Nombre = e.nombreArticulo.Nombre,
                    }).ToList();
                return View(articulosVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");

            }

        }

        //GET: ArticulosController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ArticulosController/Create
        //Muestra la vista para crear un articulo
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
                return View();
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: ArticulosController/Create
        //Crea un articulo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloViewModel artVM)
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
                    if (ModelState.IsValid)
                    {
                        if (artVM == null)
                        {
                            throw new ArticuloException("Datos incorrectos");
                        }

                        CodigoBarras codigo = new CodigoBarras(artVM.Codigo);
                        NombreArticulo nombre = new NombreArticulo()
                        {
                            Nombre = artVM.Nombre
                        };

                        Articulo articulo = new Articulo()
                        {
                            Descripcion = artVM.Descripcion,
                            Codigo = codigo,
                            Stock = artVM.Cantidad,
                            Precio = artVM.CantPrecio,
                            nombreArticulo = nombre
                        };
                        articulo.Validar();
                        CUAgregarArticulos.Agregar(articulo);
                        return RedirectToAction(nameof(Index));
                    }


                }
                catch (CodigoArticuloException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (NombreArticuloException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (ArticuloException e)
                {
                    ViewBag.Error = e.Message;
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }

                return View(artVM);

            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
        }

        //// GET: ArticulosController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ArticulosController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        string? rol = HttpContext.Session.GetString("Rol");
        //        string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
        //        if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
        //        {
        //            throw new Exception();
        //        }

        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        // GET: ArticulosController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ArticulosController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        string? rol = HttpContext.Session.GetString("Rol");
        //        string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
        //        if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
        //        {
        //            throw new Exception();
        //        }
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
        //        return RedirectToAction("Error", "Home");
        //    }
        //}
    }
}
