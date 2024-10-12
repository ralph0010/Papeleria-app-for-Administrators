using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.MovimientoStock.ClasesPorTipoMovimiento
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoMovimiento : IEntity<TipoMovimiento>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DefinirTipo TipoElegido { get; set; }
        public TipoMovimiento() { }

    }
}
