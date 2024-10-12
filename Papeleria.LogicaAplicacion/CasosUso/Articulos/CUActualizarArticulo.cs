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
    public class CUActualizarArticulo : ICUActualizarArticulo
    {
        IRepositorioArticulos Repositorio {  get; set; }
        public CUActualizarArticulo(IRepositorioArticulos repositorio)
        {
            Repositorio = repositorio;
        }
        //Actualizará el articulo en la base de datos
        public void Actualizar(Articulo articulo)
        {
            Repositorio.ActualizarStock(articulo);
        }
    }
}
