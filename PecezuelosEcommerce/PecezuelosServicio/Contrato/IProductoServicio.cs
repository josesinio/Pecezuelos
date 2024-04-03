using PecezuelosDTO;
namespace PecezuelosServicio.Contrato
{
    public interface IProductoServicio
    {
        Task<List<ProductoDTO>> Catalogo(string categoria , string buscar);
        Task<List<ProductoDTO>> Lista( string buscar);
        Task<ProductoDTO> Obtener(int Id);
        Task<ProductoDTO> Crear(ProductoDTO producto);
        Task<bool> Editar(ProductoDTO producto);
        Task<bool> Eliminar(int id);
    }
}
