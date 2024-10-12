using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.Excepciones.PedidosException;
using System.ComponentModel.DataAnnotations;
using Papeleria.LogicaNegocio.Entidades.CodigoComun;

namespace Papeleria.LogicaNegocio.Entidades.Pedidos
{
    public record ItemArticulo : IValidable
    {
        [Key]
        public int Id { get; set; }
        public Articulo Articulo { get; set; }

        public int Cantidad { get; set; }
        public double Precio { get; init; }
        public double Total { get; set; } = -1;

        public ItemArticulo(Articulo articulo, int cantidad)
        {
            Articulo = articulo;
            Cantidad = cantidad;
            Precio = articulo.Precio;
            Total = CalcularPrecioTotalItem();
            Validar();
        }
        public ItemArticulo() { }
        //Calcula el total del itemArticulo
        public double CalcularPrecioTotalItem()
        {
            if(Total > 0) {  return Total; }
            return Cantidad * Precio;
        }
        //Posee metodos para validar
        public void Validar()
        {
            ValidarCantidadPrecio();
            ValidarNoNull();
            ValidarIntCantidad();
        }
        //Validar que la cantidad recibida sea menor al stock disponible
        private void ValidarCantidadPrecio()
        {
            if (Cantidad > Articulo.Stock)
            {
                throw new ItemArticuloException("Error, la cantidad es mayor al stock disponible");
            }
        }
        //Validar que la cantidad sea int
        private void ValidarIntCantidad()
        {
            if (!MetodosComun.EsInt(Cantidad))
            {
                throw new ItemArticuloException("Error, la cantidad de stock no es válida");
            }
        }
        //Validar que las propreties recibidas no sean null
        private void ValidarNoNull()
        {
            if(Articulo == null)
            {
                throw new ItemArticuloException("Error, el artículo no puede ser nulo");
            } else if(Cantidad == null || Cantidad < 1)
            {
                throw new ItemArticuloException("La cantidad no puede ser menor a 1");
            }else if(Precio == null || Precio < 1)
            {
                throw new ItemArticuloException("Error en el precio del artículo");
            }
            else if (Total <0)
            {
                throw new ItemArticuloException("Error en calcular el precio Total");
            }
        }
        //Ejecuta el método de Articulo para restar stock 
        public void PedirStock()
        {
            Articulo.PedirStock(Cantidad);
        }


    }

}

