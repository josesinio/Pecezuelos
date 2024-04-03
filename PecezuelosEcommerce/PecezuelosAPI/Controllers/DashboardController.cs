using Microsoft.AspNetCore.Mvc;
using PecezuelosServicio.Contrato;
using PecezuelosDTO;

namespace PecezuelosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public readonly IDashboardServicio _DashboardServicio;

        public DashboardController(IDashboardServicio DashboardServicio)
        {
            _DashboardServicio = DashboardServicio;

        }

        [HttpGet("Resumen")]
        public  IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado =  _DashboardServicio.Resumen();

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
