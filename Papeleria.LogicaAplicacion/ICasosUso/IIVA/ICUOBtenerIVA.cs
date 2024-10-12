using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;

namespace Papeleria.LogicaAplicacion.ICasosUso.IVA
{
    public interface ICUOBtenerIVA
    {
        //Retorna el iva de la base de datos
        ClaseIVA obtenerIVA();
    }
}
