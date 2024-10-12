using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using System.ComponentModel;

namespace Papeleria.MVC.Models.PedidosVM
{
    public class PedidoViewModelCreate
    {
        public PedidoViewModelCreate() { }
        [DisplayName("Seleccione un Cliente")]
        public int IdCliente { get; set; }
        public IEnumerable<MostrarArticuloPedidoViewModel>? Articulos { get; set; } = new List<MostrarArticuloPedidoViewModel>();
        [DisplayName("Seleccione el tipo de Pedido")]
        public int IdTipoPedido { get; set; }
        public IEnumerable<TipoPedidoViewModel>? TipoPedido { get; set; } = new List<TipoPedidoViewModel>();
        [DisplayName("Seleccionar Fecha Entrega")]
        public DateTime FechaEntrega { get; set; }
        public IEnumerable<ClienteViewModel>? Clientes { get; set; } = new List<ClienteViewModel>();
        [DisplayName()]
        public CrearItemArticuloPedidoViewModel? ItemArticulo { get; set; } =
            new CrearItemArticuloPedidoViewModel();
        public double? TotalPedidoAtMoment { get; set; }
    }
}
