using PecezuelosDTO;
using PecezuelosModels;
namespace PecezuelosServicio.Contrato
{
    public interface IVentaServicio
    {
        Task<VentaDTO> Registrar(VentaDTO venta);
    }
}
