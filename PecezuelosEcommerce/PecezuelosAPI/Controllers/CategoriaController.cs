using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PecezuelosServicio.Contrato;
using PecezuelosDTO;
using PecezuelosServicio.Implementacion;

namespace PecezuelosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public readonly ICategoriaServicio _CategoriaServicio;

        public CategoriaController(ICategoriaServicio CategoriaServicio)
        {
            _CategoriaServicio = CategoriaServicio;

        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "NA")
                    buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _CategoriaServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _CategoriaServicio.Obtener(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO categoria)
        {
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _CategoriaServicio.Crear(categoria);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO categoria)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _CategoriaServicio.Editar(categoria);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _CategoriaServicio.Eliminar(Id);

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

