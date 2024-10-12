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
    public class CUObtenerClientes : ICUObtenerClientes
    {
        IRepositorioClientes Repositorio {  get; set; }
        public CUObtenerClientes(IRepositorioClientes repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna una lista con todos los clientes de la base de datos
        public IEnumerable<Cliente> ObtenerClientes()
        {
            return Repositorio.GetAll();
        }
    }
}
