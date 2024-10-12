
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.AccesoDatos.InterfacesRepositorios
{
	public interface IRepositorioClientes : IRepositorio<Cliente>	
	{
		//Devolverá clientes mediante el nombre
		IEnumerable<Cliente> GetClientesByNameOrLastName(string name);
        //Retornara clientes con el monto mayor ingresado
		IEnumerable<Cliente> GetClientesByMonto(double monto);
    }

}

