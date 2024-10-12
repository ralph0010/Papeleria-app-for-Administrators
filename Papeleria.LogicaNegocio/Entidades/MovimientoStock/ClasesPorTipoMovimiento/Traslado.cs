using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.MovimientoStock.ClasesPorTipoMovimiento
{
    public class Traslado : DefinirTipo
    {
        private static int _id = 3;
        public override int Id { get => _id; set => _id = value; }
        private static string TipoMovimiento = "Traslado";
        public Traslado() : base(TipoMovimiento) { }
        public static int RetornarId()
        {
            return _id;
        }
        public static string RetotornarTipoMovimiento()
        {
            return TipoMovimiento;
        }
    }
}
