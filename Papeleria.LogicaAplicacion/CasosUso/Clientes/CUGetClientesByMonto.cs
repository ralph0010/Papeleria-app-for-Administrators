using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.ICliente;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Clientes
{
    public class CUGetClientesByMonto : ICUGetClientesByMonto
    {
        public IRepositorioClientes Repositorio {  get; set; }
        public CUGetClientesByMonto(IRepositorioClientes repositorio)
        {
            Repositorio = repositorio;
        }
        //Retornar una lista de clientes que tengan pedidos que superan el monto recibido
        public IEnumerable<Cliente> getClientes(double monto)
        {
            return Repositorio.GetClientesByMonto(monto);
        }
    }
}
