using PecezuelosDTO;
using PecezuelosWebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace PecezuelosWebAssembly.Servicios.Implementacion
{
    public class CategoriaServicio: ICategoriaServicio
    {
        private readonly HttpClient _httpClient;

        public CategoriaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO categoria)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Crear", categoria);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();

            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO categoria)
        {
            var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", categoria);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/Lista/{buscar}");
        }

        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Obtener/{Id}");
        }
    }
}
