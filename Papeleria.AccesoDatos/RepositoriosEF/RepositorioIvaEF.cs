using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.RepositoriosEF
{
    public class RepositorioIvaEF:IRepositorioIVA
    {
        public PapeleriaContext Contexto { get; set; }
        public RepositorioIvaEF(PapeleriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(ClaseIVA t)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ClaseIVA t)
        {
            throw new NotImplementedException();
        }

        public void Update(ClaseIVA modificado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClaseIVA> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClaseIVA GetById(int id)
        {
            throw new NotImplementedException();
        }
        //Retorna el Iva
        public ClaseIVA getIVA()
        {
            return Contexto.iva.First();
        }
    }
}
