using System.ComponentModel.DataAnnotations;

namespace PecezuelosDTO
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage = "Ingrese nombre del titular")]
        public string? Titular { set; get; }
        [Required(ErrorMessage = "Ingrese Numero de la tarjeta")]
        public string? Numero { set; get;}
        [Required(ErrorMessage = "Ingrese vigenia de la tarjeta")]
        public string? Vigencia { set; get;}
        [Required(ErrorMessage = "Ingrese CVV de la tarjeta")]
        public string? CVV { set; get; }
    }
}
