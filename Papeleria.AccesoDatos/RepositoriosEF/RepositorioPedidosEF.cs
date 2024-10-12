using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.PedidosException;

namespace Papeleria.AccesoDatos.RepositoriosEF
{
    public class RepositorioPedidosEF : IRepositorioPedidos
    {
        public PapeleriaContext Contexto {  get; set; }
        public RepositorioPedidosEF(PapeleriaContext contexto)
        {
            Contexto = contexto;
        }
        //Agrega un pedido a la base de datos
        public void Add(Pedido t)
        {
            Contexto.ChangeTracker.Clear();
            Contexto.Entry(t.Tipo).State = EntityState.Unchanged;
            Contexto.Entry(t.Cliente).State = EntityState.Unchanged;
            foreach(ItemArticulo itemArticulo in t.Articulos)
            {
                Contexto.Entry(itemArticulo.Articulo).State = EntityState.Unchanged;
            }
            Contexto.Add(t);
            Contexto.SaveChanges();
            
        }
        //Retorna todos los pedidos
        public IEnumerable<Pedido> GetAll()
        {
            return Contexto.Pedidos.Include(p=> p.Articulos)
                .Include(p=>p.Cliente)
                .Include(p=>p.Tipo);
        }
        //Retornna un pedido mediante el id
        public Pedido GetById(int id)
        {
            return Contexto.Pedidos.Find(id);
        }
        //-------------------------------------No implementado--------------------------------------------
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Pedido t)
        {
            throw new NotImplementedException();
        }

        public void Update(Pedido modificado)
        {            
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------------
        //Retorna el ultimo pedido de la base de datos
        public Pedido GetLastPedido()
        {
            return Contexto.Pedidos.Include(p=> p.Tipo)
                .Include(p=>p.Articulos)
                .Include(p=>p.Cliente).OrderByDescending(p=> p.Id).FirstOrDefault();
        }
        //Retorna pedidos con tienen la misma fecha de emision recibida, que no han sido anulados y aún está disponible para anular
        public IEnumerable<Pedido> GetPedidosByFechaEmision(DateTime fecha)
        {
            DateTime dateTime = DateTime.Now;
          return Contexto.Pedidos.Include(p=> p.Cliente).Include(p=>p.Tipo).Include(p=>p.Articulos)
                .Where(p=> p.Fecha.FechaEmision.Date==fecha.Date 
          && !p.EstaAnulado && p.Fecha.FechaEntrega.Date > dateTime.Date).ToList();
        }
        
        //Cambia el estado de un pedido y lo actualiza
        public void AnularPedido(int id)
        {
            Pedido pedido = GetById(id);
            if ( pedido == null)
            {
                throw new PedidoException("Error, no se encontró el pedido");
            }
            if (pedido.EstaAnulado)
            {
                throw new PedidoException("Error, el pedido ya ha sido anulado previamente");
            }
            pedido.EstaAnulado = true;
            Contexto.Update(pedido);
            Contexto.SaveChanges();
        }
        //Retorna una lista con los pedidos anulados
        public IEnumerable<Pedido> ObtenerPedidosAnulados()
        {
            return Contexto.Pedidos.Include(p => p.Articulos).
                Include(p=> p.Cliente)
                .Include(p=>p.Fecha).Where(p=> p.EstaAnulado)
                .OrderByDescending(p=> p.Fecha.FechaEmision).
                ThenByDescending(p=> p.Fecha.FechaEntrega).ToList();
        }
    }

}

