using Papeleria.MVC.Models.PedidosVM.Index;
using System.ComponentModel;

namespace Papeleria.MVC.Models.PedidosVM.Details
{
    public class MostrarPedidoCreadoViewModel:MostrarPedidosViewModel
    {
        [DisplayName("Total de la compra sin Iva")]
        public double TotalSinIva {  get; set; }
        [DisplayName("Recargo por el envío")]
        public double Recargo {  get; set; }
        [DisplayName("IVA")]
        public double Iva {  get; set; }
        [DisplayName("Se encuentra anulado")]
        public string Anulado { get; set; }
        public MostrarPedidoCreadoViewModel(int id, string cliente, string tipoPedido,
            int cantidadArticulos, DateTime fechaPedidorealizada, DateTime fechaEntrega,
            double total, double totalSinIva, double recargo, double iva, bool anulado) : base(id,cliente, tipoPedido,
                cantidadArticulos, fechaPedidorealizada, fechaEntrega, total) 
        {
            
            TotalSinIva =Math.Round( totalSinIva,2);
            Recargo = recargo;
            Iva = iva;
            if (anulado)
            {
                Anulado = "Si";
            }
            else
            {
                Anulado = "No";
            }
        }
    }
}
