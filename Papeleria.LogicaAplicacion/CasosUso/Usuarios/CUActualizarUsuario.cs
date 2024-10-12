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
    public class CUActualizarUsuario : ICUActualizarUsuario
    {
        public IRepositorioUsuarios Repositorio {get;set; }
        public CUActualizarUsuario(IRepositorioUsuarios repositorio)
        {
            Repositorio = repositorio;
        }
        //Actualoza el usuario
        public void Actualizar(Usuario usuario)
        {
            Repositorio.Update(usuario);
        }
    }
}
