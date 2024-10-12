using Papeleria.LogicaNegocio.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Papeleria.LogicaNegocio.Entidades.MovimientoStock.ClasesPorTipoMovimiento;
using Papeleria.LogicaNegocio.InterfacesEntidades;

namespace Papeleria.LogicaNegocio.Entidades.MovimientoStock
{
    public class MovimientosStock: IEntity<MovimientosStock>
    {
        public int Id { get ; set ; }
        public DateTime FechaMovimiento { get; set; }
        public Usuario Usuario { get; set; }
        public ItemArticuloMovimiento ArticuloSeleccionado { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        public MovimientosStock() { }

    }
}
