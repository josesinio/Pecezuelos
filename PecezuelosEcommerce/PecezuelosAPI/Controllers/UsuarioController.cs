using Microsoft.AspNetCore.Mvc;
using PecezuelosServicio.Contrato;
using PecezuelosDTO;

namespace PecezuelosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioServicio _UsuarioServicio;

        public UsuarioController(IUsuarioServicio UsuarioServicio)
        {
            _UsuarioServicio = UsuarioServicio;
        }

        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try { 
                if(buscar == "NA")
                    buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Lista(rol, buscar);
                
            }
            catch (Exception ex)
            {
                response.EsCorrecto=false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                

                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Obtener(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] UsuarioDTO usuario)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Crear(usuario);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO login)
        {
            var response = new ResponseDTO<SesionDTO>();
  
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Autorizacion(login);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO usuario)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UsuarioServicio.Editar(usuario);

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
                response.Resultado = await _UsuarioServicio.Eliminar(Id);

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
