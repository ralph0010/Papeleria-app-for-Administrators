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
    public class CUObtenerUsuarios : ICUObtenerUsuarios
    {
        public IRepositorioUsuarios Repositorios { get; set; }
        public CUObtenerUsuarios(IRepositorioUsuarios repositorios)
        {
            Repositorios = repositorios;
        }
        //Retorna la lista de usuarios de la base de datos
        public IEnumerable<Usuario> GetUsuarios()
        {
            return Repositorios.GetAll();
        }
    }
}
