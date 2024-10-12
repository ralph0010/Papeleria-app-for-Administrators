using Papeleria.MVC.Models.PedidosVM.Index;

namespace Papeleria.MVC.Models.PedidosVM.GetPedidoByFecha
{
    public class MostrarPedidosByFechaViewModel:MostrarPedidosViewModel
    {
        public MostrarPedidosByFechaViewModel(int id,DateTime fechaEntrega, string cliente,
             double total):base(id,fechaEntrega,cliente,total) { }
        public MostrarPedidosByFechaViewModel() { }
    }
}
