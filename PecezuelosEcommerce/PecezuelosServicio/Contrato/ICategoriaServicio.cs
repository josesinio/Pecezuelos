using PecezuelosDTO;
namespace PecezuelosServicio.Contrato
{
    public interface ICategoriaServicio
    {
        Task<List<CategoriaDTO>> Lista(string buscar);
        Task<CategoriaDTO> Obtener(int Id);
        Task<CategoriaDTO> Crear(CategoriaDTO categoria);
        Task<bool> Editar(CategoriaDTO categoria);
        Task<bool> Eliminar(int id);
    }
}
