using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Articulos
{
    public class CUObtenerArticulos : ICUObtenerArticulos
    {
        public IRepositorioArticulos Repositorio { get; set; }
        public CUObtenerArticulos(IRepositorioArticulos repositorio)
        {
            Repositorio = repositorio;
        }
        //Obtiene todos los articulos de la base de datos
        public IEnumerable<Articulo> GetArticulos()
        {
            return Repositorio.GetAll();
        }
    }
}
