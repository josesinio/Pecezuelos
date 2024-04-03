using PecezuelosDTO;

namespace PecezuelosWebAssembly.Servicios.Contrato
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar);
        Task<ResponseDTO< CategoriaDTO>> Obtener(int Id);
        Task<ResponseDTO< CategoriaDTO>> Crear(CategoriaDTO categoria);
        Task<ResponseDTO< bool>> Editar(CategoriaDTO categoria);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
