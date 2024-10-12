using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.MovimientoStock.ClasesPorTipoMovimiento
{
    public abstract class DefinirTipo : IEntity<DefinirTipo>
    {
        public abstract int Id { get; set; }
        private string _tipoMovimiento { get; set; }
        public string TipoMovimiento { get => _tipoMovimiento; set => _tipoMovimiento = value; }
        public DefinirTipo() { }
        public DefinirTipo(string tipoMovimiento)
        {
            _tipoMovimiento = tipoMovimiento;
        }
        
    }
}
