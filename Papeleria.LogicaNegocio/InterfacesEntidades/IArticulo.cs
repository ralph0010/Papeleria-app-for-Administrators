namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
	public interface IArticulo
	{
		//Será encargado de validar la descripcion
		void ValidarDescripcion();
		//Validará el stock recibido
		void ValidarStock();
		//Validará el prico recibido
		void ValidarPrecio();

	}

}

