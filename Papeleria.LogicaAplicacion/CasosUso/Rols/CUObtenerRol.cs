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
    public class CUObtenerRol : ICUObtenerRol
    {
        IRepositorio<Rol> Repositorio { get; set; }
        public CUObtenerRol(IRepositorio<Rol> repositorio)
        {
            Repositorio = repositorio;
        }
        //Obtiene el rol mediante el id
        public Rol ObtenerRol(int id)
        {
            return Repositorio.GetById(id); 
        }
    }
}
