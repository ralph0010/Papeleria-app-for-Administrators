using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.IVA;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.IVA
{
    public class CUObtenerIva : ICUOBtenerIVA
    {
        public IRepositorioIVA Repositorio { get; set; }
        public CUObtenerIva(IRepositorioIVA repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna el valor del iva de la base de datos
        public ClaseIVA obtenerIVA()
        {
            return Repositorio.getIVA();
        }
    }
}
