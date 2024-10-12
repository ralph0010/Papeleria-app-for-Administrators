using Microsoft.EntityFrameworkCore;
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.RepositoriosEF
{
    public class RepositorioRolesEF : IRepositorio<Rol>
    {
        public PapeleriaContext Contexto { get; set; }
        public RepositorioRolesEF(PapeleriaContext contexto)
        {
            Contexto = contexto;
        }
        //Agrega un rol
        public void Add(Rol t)
        {
            Contexto.rols.Add(t);
        }
        //Retorna todos los rols
        public IEnumerable<Rol> GetAll()
        {
            return Contexto.rols;
        }
        //Obtiene un rol mediante el id
        public Rol GetById(int id)
        {
            return Contexto.rols.Find(id);
        }
        //--------------------------No implementado------------------------------------------------------
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Rol t)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol modificado)
        {
            throw new NotImplementedException();
        }
        //---------------------------------------------------------------------------
    }
}
