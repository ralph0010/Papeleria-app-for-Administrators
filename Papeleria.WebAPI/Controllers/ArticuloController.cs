using Microsoft.AspNetCore.Mvc;
using Papeleria.DTOs.DtoArticulo;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        ICUObtenerArticulosOrdenadoParaDto CUObtenerArticulosOrdenadoParaDto { get; set; }
        public ArticuloController(ICUObtenerArticulosOrdenadoParaDto cUObtenerArticulosOrdenadoParaDto)
        {
            CUObtenerArticulosOrdenadoParaDto = cUObtenerArticulosOrdenadoParaDto;
        }
        //Muestra todos los articulos de la base de datos
        /// <summary>
        /// Es un get y no recibe valores
        /// </summary>
        /// <returns>Lista de articulos ordenados</returns>

        [HttpGet("ObtenerArticulosOrdenados")]
        
        public IActionResult ObtenerArticulosOrdenados()
        {
            
            try
            {
                IEnumerable<DtoObtenerArticulos> dtoArticulos = CUObtenerArticulosOrdenadoParaDto.Obtener();
                if (!dtoArticulos.Any())
                {
                    throw new Exception("Error, no hay articulos");
                }
                return Ok(CUObtenerArticulosOrdenadoParaDto.Obtener());
            }
            catch (Exception e)
            {
                return new ContentResult
                {
                    StatusCode = 500,
                    Content = e.Message,
                };
            }
        }

        //// GET: api/<ArticuloController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ArticuloController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ArticuloController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ArticuloController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ArticuloController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
