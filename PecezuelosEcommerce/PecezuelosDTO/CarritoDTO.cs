﻿namespace PecezuelosDTO
{
    public class CarritoDTO
    {
        public ProductoDTO? Producto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? PrecioTotal { get; set; }
    }
}
