using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IUsuarios
{
    public interface ICUObtenerUsuarioByEmail
    {
        //Retorna el usuario de la base de datos mediante el email recibido
        Usuario ObtenerUsuario(string email);
    }
}
