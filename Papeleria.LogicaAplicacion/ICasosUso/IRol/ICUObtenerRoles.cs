using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IRol
{
    public interface ICUObtenerRoles
    {
        //Retorna la lista de rol de la base de datos
        IEnumerable<Rol> GetRoles();
    }
}
