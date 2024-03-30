using Microsoft.EntityFrameworkCore;
using PecezuelosModels;
using PecezuelosDTO;
using PecezuelosRepositorio.Contrato;
using PecezuelosServicio.Contrato;
using AutoMapper;

namespace PecezuelosServicio.Implementacion
{
    public class VentaServicio: IVentaServicio
    {
        private readonly IVentaRepositorio _VentaRepositorio;
        private readonly IMapper _Mapper;

        public VentaServicio(IVentaRepositorio VentaRepositorio, IMapper Mapper)
        {
            _VentaRepositorio = VentaRepositorio;
            _Mapper = Mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO venta)
        {
            try
            {
                var DbModelos = _Mapper.Map<Venta>(venta);
                var ventaGeneradad = await _VentaRepositorio.Registrar(DbModelos);

                if (ventaGeneradad.IdVenta == 0)
                    throw new TaskCanceledException("No se pudo registrar");

                return _Mapper.Map<VentaDTO>(ventaGeneradad);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
