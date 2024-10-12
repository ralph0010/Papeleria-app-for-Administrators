
using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.MVC.Models.ClientesVM
{
    public class MapperClientes
    {
        public static IEnumerable<MostrarClientesByRazonSocialViewModel> 
            ClienteToClienteVMFind(IEnumerable<Cliente> clientes)
        {
           IEnumerable <MostrarClientesByRazonSocialViewModel> clienteReturn = 
                new List<MostrarClientesByRazonSocialViewModel>();
             clienteReturn =
                clientes.Select(c=>new MostrarClientesByRazonSocialViewModel()
                {
                    Id = c.Id,
                    RazonSocial = c.RazonSocial,
                    Rut = c.Rut.Digitos,
                    Calle = c.Direccion.Calle,
                    Numero = c.Direccion.Numero,
                    Ciudad = c.Direccion.Ciudad,
                    DistanciaPapeleria = c.Direccion.DistanciaPapeleria
                }).ToList();
                return clienteReturn;
        }
    }
}
