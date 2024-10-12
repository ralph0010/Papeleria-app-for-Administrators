using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects.IVO.IVOUsuario
{
    public interface INombreApellidoVO
    {
        void ValidarCharInicioYFinal();
        void ValidarSiCumpleReglas();

    }
}
