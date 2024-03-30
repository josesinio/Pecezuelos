using System.ComponentModel.DataAnnotations;

namespace PecezuelosDTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="Ingrese nombre completo")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Ingrese correo")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "Ingrese confirmar contraseña")]
        public string? ConfirmarClave { get; set; }

        public string? Rol { get; set; }



    }
}
