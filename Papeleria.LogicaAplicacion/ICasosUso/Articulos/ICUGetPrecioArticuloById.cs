using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.Articulos
{
    public interface ICUGetPrecioArticuloById
    {
        //Obtiene el precio del articulo
        double GetPrecioById(int id);
    }
}
