using Papeleria.DTOs.DtoArticulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.Articulos
{
    public interface ICUObtenerArticulosOrdenadoParaDto
    {
        //Obtiene articulos ordenados alfabeticamente y lo castea a una lista de dtoArticulos
        public IEnumerable<DtoObtenerArticulos> Obtener();
    }
}
