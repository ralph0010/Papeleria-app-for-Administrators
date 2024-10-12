using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.RepositoriosEF
{
    public class RepositorioTipoPedido : IRepositorioTipoPedido
    {
        PapeleriaContext Contexto { get; set; }
        public RepositorioTipoPedido(PapeleriaContext contexto)
        {
            Contexto = contexto;
        }
        //No implementado
        public void Add(TipoPedido t)
        {
            throw new NotImplementedException();
        }
        //Retorna una lista de tipos de pedidos
        public IEnumerable<TipoPedido> GetAll()
        {
            return Contexto.TipoPedidos;
        }
        //Retorna un TipoPedido mediante el id
        public TipoPedido GetById(int id)
        {
            return Contexto.TipoPedidos.Find(id);
        }
        //----------------------No implementado---------------------------------------
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TipoPedido t)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoPedido modificado)
        {
            throw new NotImplementedException();
        }
        //-----------------------------------------------------------------------------
    }
}
