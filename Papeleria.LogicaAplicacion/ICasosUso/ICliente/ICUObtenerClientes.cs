using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.ICliente
{
    public interface ICUObtenerClientes
    {
        //Retorna la lista de clientes de la base de datos
        IEnumerable<Cliente> ObtenerClientes();
    }
}
