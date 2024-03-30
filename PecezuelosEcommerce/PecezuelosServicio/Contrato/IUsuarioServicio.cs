using PecezuelosDTO;

namespace PecezuelosServicio.Contrato
{
    public interface IUsuarioServicio
    {
        Task<List<UsuarioDTO>> Lista(string rol, string buscar);

        Task<UsuarioDTO> Obtener(int Id);
        Task<SesionDTO> Autorizacion(LoginDTO login);
        Task<UsuarioDTO> Crear(UsuarioDTO usuario);
        Task<bool> Editar(UsuarioDTO usuario);
        Task<bool> Eliminar(int id);
    }
}
