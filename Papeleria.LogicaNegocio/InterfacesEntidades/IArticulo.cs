namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
	public interface IArticulo
	{
		//Ser� encargado de validar la descripcion
		void ValidarDescripcion();
		//Validar� el stock recibido
		void ValidarStock();
		//Validar� el prico recibido
		void ValidarPrecio();

	}

}

