using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.Entidades
{
	public class Usuario
	{
		protected string Password;

		public Email Email{ get; set; }

		public NombreApellido Nombre{ get; set; }

		private Email email;

		private NombreApellido nombreApellido;

		private IValidable iValidable;

		private IValidable iValidable;

		public void crearUsuario()
		{

		}

		public void modificarUsuario()
		{

		}

	}

}

