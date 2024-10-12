using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.DTOs.DtoArticulo
{
    public class MapperDtoArticulo
    {
        //Transorma una lista de Articulos a DtoArticulos
        public static IEnumerable<DtoObtenerArticulos> ObtenerArticulos (IEnumerable<Articulo> 
            articulos){
            IEnumerable<DtoObtenerArticulos> dtoArticulos= new List<DtoObtenerArticulos>();
            dtoArticulos = articulos.Select(a => new DtoObtenerArticulos()
            {
                CodigoArticulo = a.Codigo.Codigo,
                Descripcion = a.Descripcion,
                Id = a.Id,
                NombreArticulo = a.nombreArticulo.Nombre,
                Precio = a.Precio,
                Stock = a.Stock,
                
            }).ToList();
            return dtoArticulos;
        }
    }
}
