using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.MovimientoStock
{
    [Owned]
    
    public record ItemArticuloMovimiento
    {
        Articulo ArticuloSeleccionado {  get; set; }
        int Cantidad {  get; set; }
        public ItemArticuloMovimiento() { }
    }
}
