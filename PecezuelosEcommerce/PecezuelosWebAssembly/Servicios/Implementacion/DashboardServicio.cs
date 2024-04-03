using PecezuelosDTO;
using PecezuelosWebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace PecezuelosWebAssembly.Servicios.Implementacion
{
    public class DashboardServicio: IDashboardServicio
    {
        private readonly HttpClient _httpClient;

        public DashboardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resemen");
        }
    }
}
