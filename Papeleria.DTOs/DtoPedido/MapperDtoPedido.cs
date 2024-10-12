using Papeleria.LogicaNegocio.Entidades.Pedidos;
using Papeleria.LogicaNegocio.Excepciones.PedidosException;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.DTOs.DtoPedido
{
    public class MapperDtoPedido
    {
        public static IEnumerable<DtoObtenerPedidos> GetPedidosToDto(IEnumerable<Pedido> pedidos)
        {
            IEnumerable<DtoObtenerPedidos> pedidosDto = new List<DtoObtenerPedidos>();
            try
            {

            if(pedidos == null || !pedidos.Any())
            {
                throw new PedidoException("Error, no hay pedidos para mostrar");
            }
            pedidosDto = pedidos.Select(p => new DtoObtenerPedidos()
            {
                Id = p.Id,
                Cliente = p.Cliente.RazonSocial,
                EstaAnulado = p.EstaAnulado,
                PrecioTotalConIva = p.PrecioTotalConIva,
                PrecioTotalSinIva = p.PrecioTotalSinIva,
                FechaEntrega = p.Fecha.FechaEntrega.ToString("dd/MM/yyyy"),
                FechaPedido = p.Fecha.FechaEmision.ToString("dd/MM/yyyy")
            }).ToList();
            
            }
            catch (PedidoException ex)
            {

            }
            return pedidosDto;
        }
    }
}
