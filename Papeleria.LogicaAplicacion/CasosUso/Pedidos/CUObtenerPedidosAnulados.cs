using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.DTOs.DtoPedido;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Pedidos
{
    public class CUObtenerPedidosAnulados : ICUObtenerPedidosAnulados
    {
        IRepositorioPedidos Repositorio {  get; set; }
        public CUObtenerPedidosAnulados(IRepositorioPedidos repositorio)
        {
            Repositorio = repositorio;
        }
        //Retonar una lista de pedidos anulados, ordenados por fecha de manera descendente y los caste a una lista de dtoPedidoss
        public IEnumerable<DtoObtenerPedidos> ObtenerPedidos()
        {
            IEnumerable<DtoObtenerPedidos> pedidosDto = new List<DtoObtenerPedidos>();
            pedidosDto = MapperDtoPedido.GetPedidosToDto(Repositorio.ObtenerPedidosAnulados());
                
            return pedidosDto;
        }
    }
}
