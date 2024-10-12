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
    public class CUGetClienteByRazonSocial:ICUGetClienteByRazonSocial
    {
        IRepositorioClientes Repositorio {  get; set; }
        public CUGetClienteByRazonSocial(IRepositorioClientes repositorio)
        {
            Repositorio = repositorio;
        }
        //Retonra una lista de clientes que contenga el string recibido en la razon social
        public IEnumerable<Cliente> GetCliente(string razonSocial)
        {
            return Repositorio.GetClientesByNameOrLastName(razonSocial);
        }
    }
}
