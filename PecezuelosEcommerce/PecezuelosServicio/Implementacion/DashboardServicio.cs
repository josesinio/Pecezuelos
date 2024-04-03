using PecezuelosServicio.Contrato;
using Microsoft.EntityFrameworkCore;
using PecezuelosModels;
using PecezuelosDTO;
using PecezuelosRepositorio.Contrato;
using AutoMapper;

namespace PecezuelosServicio.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        public readonly IVentaRepositorio _VentaRepositorio;
        private readonly IGenericoRepositorio<Usuario> _UsuarioRepositorio;
        private readonly IGenericoRepositorio<Producto> _ProductoRepositorio;


        public DashboardServicio(IGenericoRepositorio<Usuario> UsuarioRepositorio,
            IGenericoRepositorio<Producto> ProductoRepositorio,
            IVentaRepositorio VentaRepositorio
            )
        {
            _UsuarioRepositorio = UsuarioRepositorio;
            _ProductoRepositorio = ProductoRepositorio;
            _VentaRepositorio = VentaRepositorio;
        }

        private string Ingresos() {
            var consulta = _VentaRepositorio.Consultar();
            decimal? ingresos = consulta.Sum( x => x.Total );

            return Convert.ToString(ingresos);
        }

        private int Ventas () {
            var consulta = _VentaRepositorio.Consultar();
            int total = consulta.Count();

            return total;
        }

        private int Clientes()
        {
            var consulta = _UsuarioRepositorio.Consultar(U => U.Rol.ToLower() == "cliente" );
            int total = consulta.Count();

            return total;
        }
        private int Productos()
        {
            var consulta = _ProductoRepositorio.Consultar();
            int total = consulta.Count();

            return total;
        }

        public DashboardDTO Resumen()
        {
            try {
                DashboardDTO dashboardDTO = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalCliente = Clientes(),
                    TotalProducto = Productos(),
                    TotalVentas = Ventas(),
                };

                return dashboardDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
