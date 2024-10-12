namespace Papeleria.AccesoDatos.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
	{
		//Agregar Objeto
		void Add(T t);
		//Eliminar por id
		void Remove(int id);
		//Eliminar Objeto
		void Remove(T t);
		//Actualizar Objeto
		void Update(T modificado);
		//Obtener una lista de todos los objetos
		IEnumerable<T> GetAll();
		//Obtener Objeto mediante Id
		T GetById(int id);

	}

}

