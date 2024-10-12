using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.ICliente
{
    public interface ICUGetClienteByRazonSocial
    {
        //Retorna una lista de clientes que contenga el valor recibido en la razon social de la base de datos
        IEnumerable<Cliente> GetCliente(string razonSocial);
    }
}
