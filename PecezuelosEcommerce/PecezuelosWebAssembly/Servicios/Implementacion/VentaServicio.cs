using PecezuelosDTO;
using PecezuelosWebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace PecezuelosWebAssembly.Servicios.Implementacion
{
    public class VentaServicio: IVentaServicio
    {
        private readonly HttpClient _httpClient;

        public VentaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO venta)
        {
            var response = await _httpClient.PostAsJsonAsync("Venta/Registrar", venta);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();

            return result;
        }
    }
}
