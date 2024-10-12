using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IUsuarios
{
    public interface ICUIniciarSesion
    {
        //Si los valores son correctos retorna el Usuario sino una exception
        Usuario IniciarSesion(string email, string password);
    }
}
