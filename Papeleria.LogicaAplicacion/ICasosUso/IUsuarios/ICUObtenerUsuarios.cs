using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IUsuarios
{
    public interface ICUObtenerUsuarios
    {
        //retorna la lista de usuarios de la base de datos
        IEnumerable<Usuario> GetUsuarios();
    }
}
