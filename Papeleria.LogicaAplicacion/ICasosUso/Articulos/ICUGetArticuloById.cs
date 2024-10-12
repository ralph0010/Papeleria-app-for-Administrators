using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.Articulos
{
    public interface ICUGetArticuloById
    {
        //Retorna un articulo de la base de datos
        Articulo GetArticulo(int id);
    }
}
