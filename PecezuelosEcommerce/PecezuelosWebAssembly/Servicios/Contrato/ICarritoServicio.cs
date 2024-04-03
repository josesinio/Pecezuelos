using PecezuelosDTO;


namespace PecezuelosWebAssembly.Servicios.Contrato
{
    public interface ICarritoServicio
    {
        event Action MostrarItems;
        int CantidadProductos();
        Task AgregarCarrito(CarritoDTO carrito);
        Task EliminarCarrito(int Id);
        Task<List<CarritoDTO>> DevolverCarrito();
        Task LimpiarCarrito();


    }
}
