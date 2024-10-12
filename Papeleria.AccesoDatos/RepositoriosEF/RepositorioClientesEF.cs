using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.ClienteException;
using System.Linq;

namespace Papeleria.AccesoDatos.RepositoriosEF
{
    public class RepositorioClientesEF : IRepositorioClientes
    {
        public PapeleriaContext Contexto { get; set; }
        public RepositorioClientesEF(PapeleriaContext contexto)
        {
            Contexto = contexto;
        }
        //No implementado
        public void Add(Cliente t)
        {
            throw new NotImplementedException();
        }
        //Obtiene todos los clientes
        public IEnumerable<Cliente> GetAll()
        {
            return Contexto.Clientes;
        }
        //Obtiene el cliente mediante el id
        public Cliente GetById(int id)
        {
            return Contexto.Clientes.Find(id);
        }
        //No implementado
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        //No implementado
        public void Remove(Cliente t)
        {
            throw new NotImplementedException();
        }
        //No implementado
        public void Update(Cliente modificado)
        {
            throw new NotImplementedException();
        }
        //Retorna una lista de Cliente si su RazonSocial contiene el parametro ingresado
        public IEnumerable<Cliente> GetClientesByNameOrLastName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ClienteException("Error, no puede estar vacio el nombre");
            }
            bool existe = Contexto.Clientes.Any(c => c.RazonSocial.ToLower().Contains(name.ToLower()));
           
            if (!existe)
            {
                throw new ClienteException("Error, no hay clientes para mostrar");
            }
            
            return Contexto.Clientes.Where(c => c.RazonSocial.ToLower().Contains(name.ToLower()))
            .ToList(); 


        }
        //Retorna una lista de clientes que tengas pedidos que superen el monto recibido
        public IEnumerable<Cliente> GetClientesByMonto(double monto)
        {
            return Contexto.Pedidos.Where(
                p => p.PrecioTotalConIva > monto).Select(p => p.Cliente).Distinct().ToList();
        }
    }

}

