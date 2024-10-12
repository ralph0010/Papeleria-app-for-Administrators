using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.CasosUso.Pedidos;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using Papeleria.LogicaAplicacion.ICasosUso.ICliente;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;
using Papeleria.LogicaAplicacion.ICasosUso.IVA;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
using Papeleria.LogicaNegocio.Excepciones.ClienteException;
using Papeleria.LogicaNegocio.Excepciones.PedidosException;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using Papeleria.MVC.Models.PedidosVM;
using Papeleria.MVC.Models.PedidosVM.Details;
using Papeleria.MVC.Models.PedidosVM.GetPedidoByFecha;
using Papeleria.MVC.Models.PedidosVM.Index;

namespace Papeleria.MVC.Controllers
{
    public class PedidosController : Controller
    {
        public ICUObtenerArticulos CUObtenerArticulos { get; set; }
        public ICUObtenerTipoPedidos CUObtenerTipoPedidos { get; set; }
        public ICUObtenerClientes CUObtenerClientes { get; set; }
        public ICUGetArticuloById CUGetArticuloById { get; set; }
        public ICUGetPrecioArticuloById CUGetPrecioArticuloById { get; set; }
        public ICUGetClienteById CUGetClienteById { get; set; }
        public ICUGetTipoPedidoById CUGetTipoPedidoById { get; set; }
        public ICUActualizarArticulo CUActualizarArticulo { get; set; }
        public ICUAddPedidoToDatabase CUAddPedidoToDatabase { get; set; }
        public ICUGetAllPedidos CUGetAllPedidos { get; set; }
        public ICUGetPedidoLast CUGetPedidoLast { get; set; }
        public ICUGetPedidosByFechaEmision CUGetPedidosByFechaEmision { get; set; }
        public ICUAnularPedido CUAnularPedido { get; set; }
        public ICUOBtenerIVA CUOBtenerIVA { get; set; }
        
        public PedidosController(ICUObtenerArticulos cuObtenerArticulos, ICUObtenerTipoPedidos 
            cuObtenerTipoPedidos, ICUObtenerClientes cuObtenerClientes, ICUGetArticuloById
             cuGetArticuloById, ICUGetPrecioArticuloById cuGetPrecioArticuloById,
            ICUGetClienteById cuGetClienteById, ICUGetTipoPedidoById cuGetTipoPedidoByID, ICUActualizarArticulo
             cuActualizarArticulo, ICUAddPedidoToDatabase cUAddPedidoToDatabase, 
            ICUGetAllPedidos cuGetAllPedidos, ICUGetPedidoLast cuGetPedidoLast,
            ICUGetPedidosByFechaEmision cuGetPedidosByFechaEmision, ICUAnularPedido cuAnularPedio, ICUOBtenerIVA cuOBtenerIVA)
        {
            CUObtenerArticulos = cuObtenerArticulos;
            CUObtenerTipoPedidos = cuObtenerTipoPedidos;
            CUObtenerClientes = cuObtenerClientes;
            CUGetArticuloById = cuGetArticuloById;
            CUGetPrecioArticuloById = cuGetPrecioArticuloById;
            CUGetClienteById = cuGetClienteById;
            CUGetTipoPedidoById = cuGetTipoPedidoByID;
            CUActualizarArticulo = cuActualizarArticulo;
            CUAddPedidoToDatabase = cUAddPedidoToDatabase;
            CUGetAllPedidos = cuGetAllPedidos;
            CUGetPedidoLast = cuGetPedidoLast;
            CUGetPedidosByFechaEmision = cuGetPedidosByFechaEmision;
            CUAnularPedido = cuAnularPedio;
            CUOBtenerIVA = cuOBtenerIVA;
        }
        //Adjunta los articulos con las cantidades especificadas para el pedido, ayuda para
        //actualizar los articulos cuando se realiza un pedido y agregar un pedido
        private static List<ItemArticulo> itemArticulos = new List<ItemArticulo>();
        //Es una funcion que retorna el total de los articulos static para mostrarlo en pantalla
        private double TotalItemArticulos()
        {
            double retorno = 0;
            foreach (ItemArticulo item in itemArticulos)
            {
                retorno += item.CalcularPrecioTotalItem();
            }
            return retorno;
        }
        //Funcion para actualizar el stock cuando se agrega un pedido
        private void ActualizarStockArticulos()
        {
            foreach(ItemArticulo item in itemArticulos)
            {
                CUActualizarArticulo.Actualizar(item.Articulo);
            }
        }
        //Obtiene todo los clientes
        private IEnumerable<ClienteViewModel> ObtenerCLientes()
        {
            IEnumerable<ClienteViewModel> clientes = new List<ClienteViewModel>();
            clientes = CUObtenerClientes.ObtenerClientes().Select(
                c => new ClienteViewModel()
                {
                    Id = c.Id,
                    RazonSocial = c.RazonSocial,
                }).ToList();
            return clientes;
        }
        //Metodo para obtener todos los tipos de pedidos
        private IEnumerable<TipoPedidoViewModel> ObtenertiposPedido()
        {
            IEnumerable<TipoPedidoViewModel> ObtenerTipos = new List<TipoPedidoViewModel>();
            ObtenerTipos = CUObtenerTipoPedidos.ObtenerTipos().Select(
                t=> new TipoPedidoViewModel()
                {
                    Id = t.Id,
                    TipoPedido = t.Tipo
                }).ToList();
            return ObtenerTipos;
        }
        //Metodos para obtener todos los articulos de la base de datos
        private IEnumerable<MostrarArticuloPedidoViewModel> ObtenerArticulos()
        {
            IEnumerable<MostrarArticuloPedidoViewModel> obtenerArticulos = new List<MostrarArticuloPedidoViewModel>();
            obtenerArticulos = CUObtenerArticulos.GetArticulos().Select(
                a => new MostrarArticuloPedidoViewModel()
                {
                    Id = a.Id,
                    NombreArticulo = a.nombreArticulo.Nombre,
                    precio = a.Precio
                }).ToList();
            return obtenerArticulos;
        }
        //Metodo para llamar a los metodos para agregar
        private void AddElementsToPedidoVM(PedidoViewModelCreate pedidoVM)
        {
            pedidoVM.Articulos = ObtenerArticulos();
            pedidoVM.TipoPedido = ObtenertiposPedido();
            pedidoVM.Clientes = ObtenerCLientes();
        }
        //Metodo para agregar un pedido a la list<ItemArticulo>
        private void AddItemArticuloToList(ItemArticulo itemRecibido)
        {
            bool ExisteEnLista = false;
            foreach(ItemArticulo item in itemArticulos)
            {
                if (itemRecibido.Articulo.Equals(item.Articulo))
                {
                    ExisteEnLista = true;
                    item.Cantidad += itemRecibido.Cantidad;
                    item.Validar();
                    item.Articulo.Stock -= itemRecibido.Cantidad;
                    item.Total = 0;
                    break;
                }
            }
            if (!ExisteEnLista)
            {
                itemArticulos.Add(itemRecibido);
                itemRecibido.Validar();
                itemRecibido.Articulo.Stock -= itemRecibido.Cantidad;
            }
            
        }
        //El método será utilizado para traer todos los pedidos de la base de datos
        private IEnumerable<MostrarPedidosViewModel> MostrarPedidos()
        {
            IEnumerable <MostrarPedidosViewModel> pedidosVM = new List<MostrarPedidosViewModel>();
            pedidosVM = CUGetAllPedidos.GetAll().Select
                (p => new MostrarPedidosViewModel()
                {
                    Id = p.Id,
                    Cliente = p.Cliente.RazonSocial,
                    TipoPedido = p.Tipo.Tipo,
                    CantidadArticulos = p.Articulos.Count(),
                    FechaPedidoRealizada = p.Fecha.FechaEmision.ToString("dd/MM/yyyy"),
                    FechaEntrega = p.Fecha.FechaEntrega.ToString("dd/MM/yyyy"),
                    Total = Math.Round(p.CalcularTotalConIva(),2),
                    estaAnulado = MostrarPedidosViewModel.RetornarestaAnulado(p.EstaAnulado)
                }).ToList();

            return pedidosVM;
        }
        //Vista para agregarArticuloPedido

        public ActionResult AgregarArticulo(PedidoViewModelCreate pedidoVM)
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
                    Articulo articulo = CUGetArticuloById.GetArticulo(pedidoVM.ItemArticulo.IdArticulo);
                    if (articulo == null)
                    {
                        throw new Exception("Error, el artículo seleccionado no existe");
                    }

                    ItemArticulo item = new ItemArticulo(articulo, pedidoVM.ItemArticulo.Cantidad);
                    AddItemArticuloToList(item);
                    ViewBag.SucessMessage = "Se ha agregado con éxito el artículo, " +
                        "puede seguir agregando más artículos al pedido";
                    pedidoVM.TotalPedidoAtMoment = TotalItemArticulos();
                }
                catch (ItemArticuloException e)
                {
                    ViewBag.ErrorArticulo = e.Message;
                }
                catch (Exception e)
                {
                    ViewBag.ErrorArticulo = e.Message;
                }
                AddElementsToPedidoVM(pedidoVM);
                pedidoVM.TotalPedidoAtMoment = TotalItemArticulos();
                return View(nameof(Create), pedidoVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }
        //Muestra todos los pedidos de la base de datos
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
                IEnumerable<MostrarPedidosViewModel> pedidosVM = MostrarPedidos();
                return View(pedidosVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // GET: PedidosController1/Details/5
        //Muestra detalle del ultimo pedido creado
        public ActionResult Details()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                Pedido pedidoCreado = CUGetPedidoLast.GetPedido();
                MostrarPedidoCreadoViewModel pedidoVM = new MostrarPedidoCreadoViewModel(pedidoCreado.Id,
                    pedidoCreado.Cliente.RazonSocial, pedidoCreado.Tipo.Tipo, pedidoCreado.Articulos.Count(),
                    pedidoCreado.Fecha.FechaEmision, pedidoCreado.Fecha.FechaEntrega, pedidoCreado.PrecioTotalConIva,
                    pedidoCreado.PrecioTotalSinIva, pedidoCreado.Recargo, pedidoCreado.IVA, pedidoCreado.EstaAnulado);
                return View(pedidoVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // GET: PedidosController1/Create
        //Muestra vista del pedido create
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
                PedidoViewModelCreate pedidoVM = new PedidoViewModelCreate();
                AddElementsToPedidoVM(pedidoVM);
                return View(pedidoVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

        // POST: PedidosController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Para crear el pedido
        public ActionResult Create(PedidoViewModelCreate pedidoVM)
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
                    Cliente cliente = CUGetClienteById.GetCliente(pedidoVM.IdCliente);
                    FechaPedido fechaPedido = new FechaPedido(pedidoVM.FechaEntrega);
                    TipoPedido tipoPedido = CUGetTipoPedidoById.GetTipoPedido(pedidoVM.IdTipoPedido);
                    ClaseIVA iva = CUOBtenerIVA.obtenerIVA();
                    //Revisar el create el tema del iva
                    Pedido pedido = new Pedido(cliente, itemArticulos, tipoPedido, fechaPedido,iva.Valor);
                    CUAddPedidoToDatabase.AddPedido(pedido);
                    ActualizarStockArticulos();
                    itemArticulos.Clear();

                    return RedirectToAction(nameof(Details));
                }
                catch (ClienteException e)
                {
                    ViewBag.ErrorPedido = e.Message;
                }
                catch (TipoPedidoException e)
                {
                    ViewBag.ErrorPedido = e.Message;
                }
                catch (FechaPedidoException e)
                {
                    ViewBag.ErrorPedido = e.Message;
                }
                catch (PedidoException e)
                {
                    ViewBag.ErrorPedido = e.Message;
                }
                catch (Exception e)
                {
                    ViewBag.ErrorPedido = e.Message;
                }
                AddElementsToPedidoVM(pedidoVM);
                pedidoVM.TotalPedidoAtMoment = TotalItemArticulos();
                return View(pedidoVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }

       

        //Nos llevara a la vista para consseguir un pedido mendiante a la fecha de Emision
        public ActionResult GetPedidoByFechaEmision()
        {
            try
            {
                string? rol = HttpContext.Session.GetString("Rol");
                string? emailUsuario = HttpContext.Session.GetString("EmailUsuario");
                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(emailUsuario))
                {
                    throw new Exception();
                }
                FechaEmisionViewModel fechaVM = new FechaEmisionViewModel();
                return View(fechaVM);
            }
            catch (Exception)
            {
                TempData["MensajeDenegado"] = "Error no tiene acceso a la página";
                return RedirectToAction("Error", "Home");
            }
            
        }
        //Mostrara los pedidos sin anular mediante la fecha de emision ingresada
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetPedidoByFechaEmision(FechaEmisionViewModel fechaVM)
        {
            try
            {
                fechaVM.pedidos = GetPedidosByFecha(fechaVM.FechaEmision) ;
                if (!fechaVM.pedidos.Any()) 
                {
                    throw new Exception("No se ha encontrado ningún pedido con la fecha especificada");
                }
            }
            catch(Exception ex) 
            { 
                ViewBag.Error = ex.Message;
            }
            return View(fechaVM);
        }
        //metodo que contiene los pedidos sin anular mediante la fecha
        private IEnumerable<MostrarPedidosByFechaViewModel> GetPedidosByFecha(DateTime fecha)
        {
            IEnumerable<MostrarPedidosByFechaViewModel> pedidos = new List<MostrarPedidosByFechaViewModel>();
            pedidos = CUGetPedidosByFechaEmision.GetPedidos(fecha).Select
            (p => new MostrarPedidosByFechaViewModel()
            {
                Id = p.Id,
                FechaEntrega = p.Fecha.FechaEntrega.ToString("dd/MM/yyyy"),
                Cliente = p.Cliente.RazonSocial,
                Total = p.CalcularTotalConIva()
            }).ToList();
            return pedidos;
        }
        //Nos llevara a la vista para mostrar el mensaje de que se ha anulado con exito.
        public ActionResult AnularPedido(int id) 
        {
            try
            {
                CUAnularPedido.AnularPedido(id);
                ViewBag.SuccessAnulacion = "Se ha anulado correctamente el pedido";
            }
            catch (PedidoException e)
            {
                ViewBag.ErrorAnularPedido = e.Message;
            }
            catch (Exception ex) 
            {
                ViewBag.ErrorAnularPedido = ex.Message;
            }
            return View();
        }
    }
}
