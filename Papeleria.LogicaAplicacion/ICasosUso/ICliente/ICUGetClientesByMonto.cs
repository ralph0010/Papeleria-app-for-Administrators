using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.ICliente
{
    public interface ICUGetClientesByMonto
    {
        //Retorna una lista de los clientes que tienen pedidos que superan el monto asignado
        IEnumerable<Cliente> getClientes(double monto);

    }
}
