using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.Articulos
{
    public interface ICUObtenerArticulos
    {
        //Retorna todos los articulos
        IEnumerable<Articulo> GetArticulos();
    }
}
