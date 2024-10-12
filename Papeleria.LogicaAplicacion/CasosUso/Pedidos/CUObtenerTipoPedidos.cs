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
    public class CUObtenerTipoPedidos : ICUObtenerTipoPedidos
    {
        IRepositorioTipoPedido Repositorio { get; set; }
        public CUObtenerTipoPedidos(IRepositorioTipoPedido repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna una lista con todos los tipos de pedidos de la base de datos
        public IEnumerable<TipoPedido> ObtenerTipos()
        {
            return Repositorio.GetAll();
        }
    }
}
