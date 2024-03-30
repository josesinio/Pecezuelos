using PecezuelosModels;

namespace PecezuelosRepositorio.Contrato
{
    public interface IVentaRepositorio: IGenericoRepositorio<Venta>
    {
        Task<Venta> Registrar(Venta venta);
    }
}
