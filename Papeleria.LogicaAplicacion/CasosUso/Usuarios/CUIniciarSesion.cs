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
    public class CUIniciarSesion : ICUIniciarSesion
    {
        IRepositorioUsuarios Repositorio {  get; set; }
        public CUIniciarSesion(IRepositorioUsuarios repositorio)
        {
            Repositorio = repositorio;
        }
        //Valida los datos del inicio de sesion y retorna el usuario si es valido de la base de datos
        public Usuario IniciarSesion(string email, string password)
        {
            return Repositorio.ValidarInicioSesion(email,password);
        }
    }
}
