using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.IUsuarios;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Usuarios
{
    public class CUEliminarUsuario : ICUEliminarUsuario
    {
        IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public CUEliminarUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            RepositorioUsuarios = repositorioUsuarios;
        }
        //Elimina un usuario de la base de datos
        public void Eliminar(Usuario user)
        {
            RepositorioUsuarios.Remove(user);
        }
    }
}
