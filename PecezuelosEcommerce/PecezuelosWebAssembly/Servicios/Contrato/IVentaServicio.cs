using PecezuelosDTO;

namespace PecezuelosWebAssembly.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO venta);
    }
}
