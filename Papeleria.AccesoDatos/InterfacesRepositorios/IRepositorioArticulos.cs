


using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.AccesoDatos.InterfacesRepositorios
{
	public interface IRepositorioArticulos : IRepositorio<Articulo>
	{
		//Validar que el codigo no esté repetido en la base de datos
		void ValidarCodigoNoRepetido(string codigo);
		//Validara que el nombre no esté repetido en la base de datos
		void ValidarNombreNoRepetido(string nombre);
		//Retorna el precio del Articulo mediante el Id ingresado
		double GetPrecioById(int id);
		//Retorna la lista de Articulos ordenados alfabeticamente de manera ascendente
		IEnumerable<Articulo> GetArticulosOrderByAsc();
		//Actualiza el stock
		void ActualizarStock(Articulo art);
		
	}

}

