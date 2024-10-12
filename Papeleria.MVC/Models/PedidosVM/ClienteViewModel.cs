using System.ComponentModel;

namespace Papeleria.MVC.Models.PedidosVM
{
    public class ClienteViewModel
    {
        [DisplayName("Seleccione un Cliente")]
        public int Id { get; set; }
        public string RazonSocial { get; set; }

    }
}
