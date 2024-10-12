using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioIVA: IRepositorio<ClaseIVA>
    {
        //Retorna el iva de la base de datos
        public ClaseIVA getIVA();
    }
}
