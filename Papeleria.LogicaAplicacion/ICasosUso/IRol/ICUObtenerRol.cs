using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IRol
{
    public interface ICUObtenerRol
    {
        //Retorna el tipo de rol segun el id
        Rol ObtenerRol(int id);
    }
}
