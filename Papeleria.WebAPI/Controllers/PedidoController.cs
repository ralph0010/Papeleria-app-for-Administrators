using Microsoft.AspNetCore.Mvc;
using Papeleria.DTOs.DtoPedido;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        ICUObtenerPedidosAnulados CUObtenerPedidosAnulados { get; set; }
        public PedidoController(ICUObtenerPedidosAnulados cuObtenerPedidosAnulados) 
        {

            CUObtenerPedidosAnulados = cuObtenerPedidosAnulados;
        }
        //Get
        /// <summary>
        /// Es un get
        /// </summary>
        /// <returns>Lista de pedidos anulados</returns>
        [HttpGet("ObtenerPedidosAnulados")]
        public IActionResult ObtenerPedidosAnulados()
        {
            try
            {
                IEnumerable<DtoObtenerPedidos> dtoPedidos = CUObtenerPedidosAnulados.ObtenerPedidos();
                if(!dtoPedidos.Any())
                {
                    throw new Exception("Error no hay pedidos anulados");
                }
                    return Ok(dtoPedidos);
            }
            catch(Exception e)
            {
                return new ContentResult
                {
                    StatusCode = 500,
                    Content = e.Message
                };
            }
            
        }
        //Get: api/<PedidoControlle>
        //[HttpGet]
       
        //// GET: api/<PedidoController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<PedidoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PedidoController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PedidoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PedidoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
