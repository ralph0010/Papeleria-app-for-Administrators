using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones.ArticuloException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.ValueArticulo
{

    [Owned]
    [Index(nameof(Nombre), IsUnique = true)]
    public record NombreArticulo : IValidable
    {
        public string Nombre { get; set; }
        public NombreArticulo(string nombre)
        {
            Nombre = nombre;
            Validar();
        }
        public NombreArticulo() { }
        //Ejecutará métodos de validaciones
        public void Validar()
        {
            ValidarNoNull();
            ValidarMinYMax();
        }
        //Validará el nombre recibido no sea null, en caso contrario lanzara un mensaje de exception
        private void ValidarNoNull()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new NombreArticuloException("Error, no puede ser " +
                    "vacío el nombre del articulo");
            }
        }
        //Si el nombre no contiene entre 10 y 200, lanzara un mensaje de exception
        private void ValidarMinYMax()
        {
            if (Nombre.Length < 10 || Nombre.Length > 200)
            {
                throw new NombreArticuloException("Error el nombre del articulo" +
                    "solo puede contener entre 10 y 200 caracteres");
            }
        }

    }

}

