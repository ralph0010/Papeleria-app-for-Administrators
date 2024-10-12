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
    public class CUAgregarArticulo : ICUAgregarArticulo
    {
        public IRepositorioArticulos Repositorio { get; set; }
        public CUAgregarArticulo(IRepositorioArticulos repositorio)
        {
            Repositorio = repositorio;
        }
        //Agrega un articulo a la base de datoss
        public void Agregar(Articulo art)
        {
            
            Repositorio.Add(art);
            
        } 
    }
}
