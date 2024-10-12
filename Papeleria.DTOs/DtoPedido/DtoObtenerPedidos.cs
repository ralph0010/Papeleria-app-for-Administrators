using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.DTOs.DtoPedido
{
    public class DtoObtenerPedidos
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public bool EstaAnulado {  get; set; }
        public double PrecioTotalSinIva {  get; set; }
        public double PrecioTotalConIva { get; set; }
        public String FechaPedido { get; set; }
        public String FechaEntrega { get; set; }
    }
}
