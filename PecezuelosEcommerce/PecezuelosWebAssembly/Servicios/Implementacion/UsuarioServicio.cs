using Microsoft.AspNetCore.Components.Web;
using PecezuelosDTO;
using PecezuelosWebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace PecezuelosWebAssembly.Servicios.Implementacion
{
    public class UsuarioServicio: IUsuarioServicio
    {
        private readonly HttpClient _httpClient;

        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO login)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion", login);

            var result = await  response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO usuario)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", usuario);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(UsuarioDTO usuario)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", usuario);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<ResponseDTO<UsuarioDTO>> Obtner(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obtener/{Id}");
        }
    }
}
