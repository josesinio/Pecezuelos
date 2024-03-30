using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PecezuelosModels;
using PecezuelosRepositorio.Contrato;
using PecezuelosRepositorio.DBContext;
using System.Transactions;

namespace PecezuelosRepositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly DbpecezuelosContext _dbpecezuelos;

        public VentaRepositorio(DbpecezuelosContext dbpecezuelos): base(dbpecezuelos) 
        {

            _dbpecezuelos = dbpecezuelos;
        }

        public  async Task<Venta> Registrar(Venta venta)
        {
            Venta ventaGenerada = new Venta();
            using (var Transasion = _dbpecezuelos.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalleVenta Dv in venta.DetalleVenta)
                    {
                        Producto producto_Encontrado = _dbpecezuelos.Productos.Where(p => p.IdProducto == Dv.IdProducto).First();
                        producto_Encontrado.Cantidad = producto_Encontrado.Cantidad - Dv.Cantidad;
                         _dbpecezuelos.Update(producto_Encontrado);
                    }
                    await _dbpecezuelos.SaveChangesAsync();

                    await _dbpecezuelos.Venta.AddAsync(venta);
                    await _dbpecezuelos.SaveChangesAsync();
                    ventaGenerada = venta;
                    Transasion.Commit();
                   }
                catch
                {
                    Transasion.Rollback();
                    throw;
                }
                return ventaGenerada;
            }
        }
    }
}
