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
    public class CUAltaUsuario:ICUAltaUsuario
    {
        public IRepositorioUsuarios Repositorio { get; set; }
        public CUAltaUsuario(IRepositorioUsuarios repositorio)
        {
            Repositorio = repositorio;
        }
        //Agregra un usuario a la base de datos
        public void DarAlta(Usuario usuario)
        {
            Repositorio.Add(usuario);
        }
    }
}
