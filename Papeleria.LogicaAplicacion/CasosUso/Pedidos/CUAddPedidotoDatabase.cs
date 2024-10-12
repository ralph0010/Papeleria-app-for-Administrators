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
    public class CUAddPedidotoDatabase : ICUAddPedidoToDatabase
    {
        public IRepositorioPedidos Repositorio {  get; set; }
        public CUAddPedidotoDatabase(IRepositorioPedidos repositorio)
        {
            Repositorio = repositorio;
        }
        //Agrega un pedido a la base de datos
        public void AddPedido(Pedido pedido)
        {
            Repositorio.Add(pedido);
        }
    }
}
