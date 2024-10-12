using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.MovimientoStock.ClasesPorTipoMovimiento
{
    public class AumentoStock : DefinirTipo
    {
        private static int _id = 1;
        public override int Id { get => _id; set => _id=value; }
        private static string TipoMovimiento = "AumentoStock";
        public AumentoStock():base(TipoMovimiento){}
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
