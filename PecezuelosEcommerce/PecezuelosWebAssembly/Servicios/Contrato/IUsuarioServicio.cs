using PecezuelosDTO;

namespace PecezuelosWebAssembly.Servicios.Contrato
{
    public interface IUsuarioServicio
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista( string rol, string  buscar );
        Task<ResponseDTO<UsuarioDTO>> Obtner( int Id );
        Task<ResponseDTO<SesionDTO>> Autorizacion( LoginDTO login);
        Task<ResponseDTO<UsuarioDTO>> Crear( UsuarioDTO usuario);
        Task<ResponseDTO<bool>> Editar( UsuarioDTO usuario);
        Task<ResponseDTO<bool>> Eliminar( int Id);
    }
}
