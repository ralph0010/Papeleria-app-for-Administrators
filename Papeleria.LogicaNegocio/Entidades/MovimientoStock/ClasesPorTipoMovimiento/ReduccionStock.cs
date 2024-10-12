using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.MovimientoStock.ClasesPorTipoMovimiento
{
    public class ReduccionStock : DefinirTipo
    {
        private static int _id = 2;
        public override int Id { get => _id; set => _id = value; }
        private static string TipoMovimiento = "ReduccionStock";
        public ReduccionStock() :base (TipoMovimiento){ }
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
