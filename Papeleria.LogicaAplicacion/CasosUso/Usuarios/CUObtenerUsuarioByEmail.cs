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
    public class CUObtenerUsuarioByEmail : ICUObtenerUsuarioByEmail
    {
        public IRepositorioUsuarios Repositorio {  get; set; }
        public CUObtenerUsuarioByEmail(IRepositorioUsuarios repositorioUsuarios)
        {
            Repositorio = repositorioUsuarios;
        }
        //Retorna un usuario por email de la base de datos
        public Usuario ObtenerUsuario(string email)
        {
            return Repositorio.GetUsuarioByEmail(email);
        }
    }
}
