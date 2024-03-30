using System.Linq.Expressions;

namespace PecezuelosRepositorio.Contrato
{
    public interface IGenericoRepositorio<T> where T : class
    {
        IQueryable<T> Consultar(Expression<Func<T, bool >>? filtro = null );
        Task<T> Crear(T modelo);
        Task<bool> Editar(T modelo);
        Task<bool> Eliminar(T modelo);


    }
}
