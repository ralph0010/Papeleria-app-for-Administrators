using System.ComponentModel;

namespace Papeleria.MVC.Models.PedidosVM.GetPedidoByFecha
{
    public class FechaEmisionViewModel
    {
        [DisplayName("Ingrese la fecha de Emisión del Pedido")]
        public DateTime FechaEmision { get; set; }

        public IEnumerable<MostrarPedidosByFechaViewModel>? pedidos { get; set; } =
            new List<MostrarPedidosByFechaViewModel>();
        public MostrarPedidosByFechaViewModel mostrar { get; set; } = new MostrarPedidosByFechaViewModel();
    }
}
