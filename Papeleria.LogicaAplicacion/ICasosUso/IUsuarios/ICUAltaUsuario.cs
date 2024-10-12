using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IUsuarios
{
    public interface ICUAltaUsuario
    {
        //Agrega un usuario a la base de datos
        void DarAlta(Usuario usuario);
    }
}
