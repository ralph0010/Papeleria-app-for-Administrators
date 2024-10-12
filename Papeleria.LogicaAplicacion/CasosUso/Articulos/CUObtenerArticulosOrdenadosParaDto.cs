using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.DTOs.DtoArticulo;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Articulos
{
    public class CUObtenerArticulosOrdenadosParaDto: ICUObtenerArticulosOrdenadoParaDto
    {
        IRepositorioArticulos Repositorio {  get; set; }
        public CUObtenerArticulosOrdenadosParaDto(IRepositorioArticulos repositorio)
        {
            Repositorio = repositorio;
        }
        //Obtiene los articulos ordenados de alfabeticamente de manera ascendente, casteados a dtoArticulo
        public IEnumerable<DtoObtenerArticulos> Obtener()
        {
            return MapperDtoArticulo.ObtenerArticulos(Repositorio.GetArticulosOrderByAsc());
        }
    }
}
