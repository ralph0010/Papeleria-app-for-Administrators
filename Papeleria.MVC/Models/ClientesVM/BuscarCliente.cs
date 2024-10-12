using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.MVC.Models.ClientesVM
{
    public class BuscarCliente
    {
        
        [DisplayName("Razon Social")]
        public string RazonSocial { get; set; }
        public IEnumerable<MostrarClientesByRazonSocialViewModel>? clientes { get; set; } =
            new List<MostrarClientesByRazonSocialViewModel>();
        public MostrarClientesByRazonSocialViewModel? clienteReferencia { get; set; } =
            new MostrarClientesByRazonSocialViewModel();
    }
}
