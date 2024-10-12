using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Articulos
{
    public class CUGetArticuloById : ICUGetArticuloById
    {
        IRepositorioArticulos Repositorio {  get; set; }
        public CUGetArticuloById(IRepositorioArticulos repositorio)
        {
            Repositorio = repositorio;
        }
        //Obtiene un articulo por id de la base de datos
        public Articulo GetArticulo(int id)
        {
            return Repositorio.GetById(id);
        }
    }
}
