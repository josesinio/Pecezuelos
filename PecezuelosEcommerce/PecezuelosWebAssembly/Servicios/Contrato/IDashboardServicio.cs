using PecezuelosDTO;

namespace PecezuelosWebAssembly.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}
