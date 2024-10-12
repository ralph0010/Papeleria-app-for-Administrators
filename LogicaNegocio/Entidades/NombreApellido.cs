using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.Entidades
{
	public class NombreApellido : IValidable
	{
		private string Nombre;

		private string Apellido;

		private Usuario usuario;

		private IValidable iValidable;


		/// <see>Libreria.LogicaNegocio.Entidades.IValidable#Validar()</see>
		public void Validar()
		{

		}

	}

}

