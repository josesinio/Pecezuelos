using System.ComponentModel.DataAnnotations;

namespace PecezuelosDTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingrese correo")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Clave { get; set; }

    }
}
