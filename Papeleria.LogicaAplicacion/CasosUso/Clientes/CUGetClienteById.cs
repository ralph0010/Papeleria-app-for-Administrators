using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using Papeleria.LogicaAplicacion.ICasosUso.ICliente;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Clientes
{
    public class CUGetClienteById : ICUGetClienteById
    {
        public IRepositorioClientes Repositorio {  get; set; }
        public CUGetClienteById(IRepositorioClientes repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna el cliente mediante el id
        public Cliente GetCliente(int id)
        {
            return Repositorio.GetById(id);
        }
    }
}
