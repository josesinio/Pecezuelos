using Microsoft.AspNetCore.Mvc;
using PecezuelosServicio.Contrato;
using PecezuelosDTO;
using PecezuelosModels;

namespace PecezuelosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly IProductoService _ProductoServicio;

        public ProductoController(IProductoService ProductoServicio)
        {
            _ProductoServicio = ProductoServicio;

        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA")
                    buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _ProductoServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
        [HttpGet("Catalogo/{buscar:alpha}/{categoria:alpha?}")]
        public async Task<IActionResult> Lista(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "Todos") categoria = "";
                if (buscar == "NA")
                    buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _ProductoServicio.Catalogo(buscar, categoria);

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
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _ProductoServicio.Obtener(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO producto)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _ProductoServicio.Crear(producto);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO producto)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _ProductoServicio.Editar(producto);

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
                response.Resultado = await _ProductoServicio.Eliminar(Id);

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
