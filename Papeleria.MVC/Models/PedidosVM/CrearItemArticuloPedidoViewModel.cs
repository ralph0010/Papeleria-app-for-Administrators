using System.ComponentModel;

namespace Papeleria.MVC.Models.PedidosVM
{
    public class CrearItemArticuloPedidoViewModel
    {
        [DisplayName("Seleccione un Artículo")]
        public int IdArticulo {  get; set; }
        [DisplayName("Digite una cantidad")]
        public int Cantidad {  get; set; }
        public CrearItemArticuloPedidoViewModel(int idArticulo, int cantidad, double precio) 
        {
            IdArticulo = idArticulo;
            Cantidad = cantidad;
        }
        public CrearItemArticuloPedidoViewModel() { }
    }
}
