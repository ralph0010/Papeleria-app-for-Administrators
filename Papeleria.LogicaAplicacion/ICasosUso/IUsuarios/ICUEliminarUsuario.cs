using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IUsuarios
{
    public interface ICUEliminarUsuario
    {
        //Elimina un usuario de la base de datos
        void Eliminar(Usuario user);
    }
}
