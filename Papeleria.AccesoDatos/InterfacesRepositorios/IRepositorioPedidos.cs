
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
namespace Papeleria.AccesoDatos.InterfacesRepositorios
{
	public interface IRepositorioPedidos : IRepositorio<Pedido>
	{
		//Retorna el ultimo pedido de la base de datos
		Pedido GetLastPedido();
		//Retorna pedidos con la misma fecha de Emision y no anulados
		IEnumerable<Pedido> GetPedidosByFechaEmision(DateTime fecha);
		//Cambia de estado del pedido a Anulado
        void AnularPedido(int id);
		//Retorna una lista de pedidos con el estado anulado
		IEnumerable<Pedido> ObtenerPedidosAnulados();
		
    }
    
}

