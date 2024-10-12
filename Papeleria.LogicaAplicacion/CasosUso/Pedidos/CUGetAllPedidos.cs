using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Pedidos
{
    public class CUGetAllPedidos : ICUGetAllPedidos
    {
        public IRepositorioPedidos Repositorio {  get; set; }
        public CUGetAllPedidos(IRepositorioPedidos repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna una lista con todos los pedidos
        public IEnumerable<Pedido> GetAll()
        {
            return Repositorio.GetAll();
        }
    }
}
