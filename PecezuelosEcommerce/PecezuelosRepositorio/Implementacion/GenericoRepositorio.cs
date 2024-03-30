using PecezuelosRepositorio.Contrato;
using PecezuelosRepositorio.DBContext;
using System.Linq.Expressions;

namespace PecezuelosRepositorio.Implementacion
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T : class 
    {
        private readonly DbpecezuelosContext _dbpecezuelos;

        public GenericoRepositorio(DbpecezuelosContext dbpecezuelos)
        {
            _dbpecezuelos = dbpecezuelos;
        }

        public IQueryable<T> Consultar(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> Consulta = (filtro == null) ? _dbpecezuelos.Set<T>() : _dbpecezuelos.Set<T>().Where(filtro);
            return Consulta;
        }

        public async Task<T> Crear(T modelo)
        {
            try {
                _dbpecezuelos.Set<T>().Add(modelo);
                await _dbpecezuelos.SaveChangesAsync();
                return modelo;
            }

            catch{
                
             throw;

            }
        }

        public async Task<bool> Editar(T modelo)
        {
            try
            {
                _dbpecezuelos.Set<T>().Update(modelo);
                await _dbpecezuelos.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(T modelo)
        {
            try
            {
                _dbpecezuelos.Set<T>().Remove(modelo);
                await _dbpecezuelos.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
