using Libreria.LogicaNegocio.Entidades;
using System;

namespace Libreria.LogicaNegocio.Entidades
{
	public class Fecha : IValidable
	{
		private DateTime FechaEntrega;

		private DateTime FechaActual;

		private Pedido pedido;


		/// <see>Libreria.LogicaNegocio.Entidades.IValidable#Validar()</see>
		public void Validar()
		{

		}

	}

}

