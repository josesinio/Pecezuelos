using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PecezuelosServicio.Contrato;
using PecezuelosDTO;
using PecezuelosServicio.Implementacion;

namespace PecezuelosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        public readonly IVentaServicio _VentaServicio;

        public VentaController(IVentaServicio VentaServicio)
        {
            _VentaServicio = VentaServicio;

        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _VentaServicio.Registrar(venta);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
    }
}
