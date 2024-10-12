using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.Entidades
{
	public class ItemArticulo : IValidable
	{
		public Articulo Articulo{ get; set; }

		public int Cantidad;

		private Pedido pedido;

		private Articulo articulo;

		public double CalcularPrecioTotalItem()
		{
			return 0;
		}


		/// <see>Libreria.LogicaNegocio.Entidades.IValidable#Validar()</see>
		public void Validar()
		{

		}

	}

}

