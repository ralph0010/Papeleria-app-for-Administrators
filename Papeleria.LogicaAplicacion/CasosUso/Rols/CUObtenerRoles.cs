using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.IRol;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Rols
{
    public class CUObtenerRoles : ICUObtenerRoles
    {
        public IRepositorio<Rol> Repositorio { get; set; }
        public CUObtenerRoles(IRepositorio<Rol> repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna todos los roles
        public IEnumerable<Rol> GetRoles()
        {
            return Repositorio.GetAll().ToList();
        }
    }
}
