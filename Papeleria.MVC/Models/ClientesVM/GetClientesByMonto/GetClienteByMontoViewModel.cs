using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.MVC.Models.ClientesVM.GetClientesByMonto
{
    public class GetClienteByMontoViewModel
    {
        [DisplayName("Ingresar monto")]
        [Range(0,int.MaxValue, ErrorMessage ="Debe ingresar un número mayor a 0")]
        public double Monto {  get; set; }
        public IEnumerable<MostrarClientesByRazonSocialViewModel>? clientesVM { get; set; } 
            = new List<MostrarClientesByRazonSocialViewModel>();
        public MostrarClientesByRazonSocialViewModel? cliente { get; set; } = new MostrarClientesByRazonSocialViewModel();
    }
}
