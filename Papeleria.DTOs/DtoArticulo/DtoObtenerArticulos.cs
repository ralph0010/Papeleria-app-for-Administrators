using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.DTOs.DtoArticulo
{
    public class DtoObtenerArticulos
    {
        public int Id {  get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get;set; }
        public string CodigoArticulo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        

    }
}
