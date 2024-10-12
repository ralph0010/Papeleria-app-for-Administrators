using Libreria.LogicaNegocio.Entidades;
using System.Collections.Generic;
using System;

namespace Libreria.LogicaNegocio.Entidades
{
	public abstract class Pedido : IEntity, IValidable
	{
		public Fecha FechaEntrega{ get; set; }

		public Cliente Cliente{ get; set; }

		private List<ItemArticulo> Articulos{ get; set; }

		private IVA IVA{ get; set; }

		private Fecha fecha;

		private Recargo recargo;

		private Cliente cliente;

		private ItemArticulo itemArticulo;

		private IVA iVA;

		public DateTime CalcularFechaEntrega()
		{
			return null;
		}

		public abstract double CalcularRecargo();

		public double CalcularPrecioTotalConIva()
		{
			return 0;
		}


		/// <see>Libreria.LogicaNegocio.Entidades.IValidable#Validar()</see>
		public void Validar()
		{

		}

	}

}

