using System.ComponentModel;

namespace Papeleria.MVC.Models.PedidosVM.Index
{
    public class MostrarPedidosViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string TipoPedido { get; set; }
        [DisplayName("Cantidad de articulos pedidos")]
        public int CantidadArticulos { get; set; }
        [DisplayName("Fecha de emisión")]
        public string FechaPedidoRealizada { get; set; }
        [DisplayName("Fecha de Entrega")]
        public string FechaEntrega { get; set; }
        public double Total {  get; set; }
        [DisplayName("El pedido está aulado")]
        public string estaAnulado { get; set; }
        public MostrarPedidosViewModel() { }
        public MostrarPedidosViewModel(int id, string cliente, string tipoPedido,
            int cantidadArticulos, DateTime fechaPedidorealizada, DateTime fechaEntrega,
            double total) 
        {
            Id = id;
            Cliente = cliente;
            TipoPedido = tipoPedido;
            CantidadArticulos = cantidadArticulos;
            FechaEntrega = fechaEntrega.ToString("dd/MM/yyyy");
            FechaPedidoRealizada = fechaPedidorealizada.ToString("dd/MM/yyyy");
            Total = Math.Round(total,2);
            
        }
        public MostrarPedidosViewModel(int id,DateTime fechaEntrega, string cliente, double total) 
        {
            FechaEntrega = fechaEntrega.ToString("dd/MM/yyyy");
            Cliente = cliente;
            Total = Math.Round(total, 2);
        }
        public static string RetornarestaAnulado(bool anulado)
        {
            if (anulado)
            {
                return "Si";
            }
            return "No";
        }
    }
}
