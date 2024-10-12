using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Articulos
{
    public class CUGetPrecioArticuloById : ICUGetPrecioArticuloById
    {
        IRepositorioArticulos Repositorio {  get; set; }
        public CUGetPrecioArticuloById(IRepositorioArticulos repositorio)
        {
            Repositorio = repositorio;
        }
        //Obtiene el precio del articulo mediante el id
        public double GetPrecioById(int id)
        {
            return Repositorio.GetPrecioById(id);
        }
    }
}
