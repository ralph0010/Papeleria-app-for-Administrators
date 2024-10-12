namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
	public interface IPedido
	{
		//Realizará los calculos correspondientes para caluclar el total sine el iva
		double CalcularTotalSinIva();
		//Realizara los calculos correspondientes para calcular el total con el iva
		double CalcularTotalConIva();
		
	}

}

