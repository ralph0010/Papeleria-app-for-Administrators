using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.Entidades
{
	public class Articulo : IValidable
	{
		public DescripcionCodigo Descripcion{ get; set; }

		public DescripcionCodigo Codigo{ get; set; }

		private Precio Precio;

		private Stock Stock;

		private NombreArticulo nombreArticulo;

		private DescripcionCodigo descripcionCodigo;

		private Stock stock;

		private ItemArticulo itemArticulo;

		private Precio precio;


		/// <see>Libreria.LogicaNegocio.Entidades.IValidable#Validar()</see>
		public void Validar()
		{

		}

	}

}

