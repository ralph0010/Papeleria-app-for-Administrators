using Libreria.AccesoDatos.InterfacesRepositorios;
using Libreria.LogicaNegocio.Entidades;
using System.Collections.Generic;

namespace Libreria.AccesoDatos.InterfacesRepositorios
{
	public interface IRepositorio_T_
	{
		void Add(T t);

		void Remove(int id);

		void Remove(T t);

		void Update(int id, Autor modificado);

		IEnumerable<T> GetAll();

		T GetById(int id);

	}

}

