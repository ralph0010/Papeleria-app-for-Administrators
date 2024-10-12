using Papeleria.LogicaNegocio.Entidades.CodigoComun;
using Papeleria.LogicaNegocio.Excepciones.ArticuloException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValueArticulo;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Articulo : IValidable, IEntity<Articulo>, IArticulo, IEquatable<Articulo>
	{
        [Key]
        public int Id { get; set; }
        public string Descripcion{ get; set; }

		public CodigoBarras Codigo{ get; set; }
        
        public double Precio {  get; set; }

		public int Stock { get; set; }

		public NombreArticulo nombreArticulo { get; set; }

        public Articulo() { }
       

        public void Validar()
		{
            ValidarDescripcion();
            ValidarStock();
            ValidarPrecio();
		}
        //Metodo para validar que la descripcion no sea menor a 5 caracteres
        public void ValidarDescripcion()
        {
            if(Descripcion.Length < 5)
            {
                throw new ArticuloException("Error, la descripción debe contener mínimo " +
                    "5 caracteres");
            }
        }
        //Metodo de Validar Stock con otros metodos de validadciones
        public void ValidarStock()
        {
            ValidarSiEsInt();
            StockValido();
        }
        //Llamamos al metodo para validar si es un int
        private void ValidarSiEsInt()
        {
            if (!MetodosComun.EsInt(Stock)) 
            {
                throw new ArticuloException("Error solo puede digitar " +
                    "números enteros");
            }
        }
        //Validar Stock que no sea menor a 0 ni null
        private void StockValido()
        {
            if(Stock < 0 || Stock == null)
            {
                throw new ArticuloException("Error el stock no puede " +
                    "ser menor a 0");
            }
        }
        //Posee metodos para validar Precio
        public void ValidarPrecio()
        {
            PrecioNull();
            VerificarEsprecio();
        }
        //Validar Precio no sea null
        private void PrecioNull()
        {
            if(Precio == null || Precio <= 0)
            {
                throw new ArticuloException("Error, el precio tiene que ser mayor a 0");
            }
        }
        //Verifica si el precio es double
        private void VerificarEsprecio()
        {
            double validarPrecio;
            if (!double.TryParse(Precio.ToString(), out validarPrecio)) 
            {
                throw new ArticuloException("Error, solo puede digitar precio");
            }
        }
        //Pide stock
        public void PedirStock(int cantidad)
        {
            ValidarStockPedido(cantidad);
            Stock -= cantidad;
        }
        //Verificar si el stock que se pide no sea mayor al stock disponible
        private void ValidarStockPedido(int stock)
        {
            if (stock > Stock)
                throw new ArticuloException("Error, el stock pedido es mayor al que existe");
        }
        //Compara Objetos
        public bool Equals(Articulo? other)
        {
            return Id.Equals(other.Id);
        }
    }

}

