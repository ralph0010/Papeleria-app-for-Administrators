using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.Articulos
{
    public interface ICUAgregarArticulo
    {
        //Agrega un articulo a la base de datos
        void Agregar(Articulo art);
    }
}
