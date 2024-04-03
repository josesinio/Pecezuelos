using PecezuelosServicio.Contrato;
using Microsoft.EntityFrameworkCore;
using PecezuelosModels;
using PecezuelosDTO;
using PecezuelosRepositorio.Contrato;
using AutoMapper;

namespace PecezuelosServicio.Implementacion
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IGenericoRepositorio<Producto> _ProductoRepositorio;
        private readonly IMapper _Mapper;

        public ProductoServicio(IGenericoRepositorio<Producto> ProductoRepositorio, IMapper Mapper)
        {
            _ProductoRepositorio = ProductoRepositorio;
            _Mapper = Mapper;
        }

        public async Task<ProductoDTO> Crear(ProductoDTO producto)
        {
            try
            {
                var DbModelos = _Mapper.Map<Producto>(producto);
                var rspModelo = await _ProductoRepositorio.Crear(DbModelos);

                if (rspModelo.IdCategoria != 0)
                    return _Mapper.Map<ProductoDTO>(rspModelo);
                else
                {
                    throw new TaskCanceledException("No se pudo crear producto");

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(ProductoDTO producto)
        {
            try
            {
                var consulta = _ProductoRepositorio.Consultar(P => P.IdProducto == producto.IdProducto);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = producto.Nombre;
                    fromDbModel.Descripcion = producto.Descripcion;
                    fromDbModel.IdCategoria = producto.IdCategoria;
                    fromDbModel.Precio = producto.Precio;
                    fromDbModel.PrecioOferta = producto.PrecioOferta;
                    fromDbModel.Cantidad = producto.Cantidad;
                    fromDbModel.Imagen = producto.Imagen;

                    var respuesta = await _ProductoRepositorio.Editar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se puedo editar Producto");
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _ProductoRepositorio.Consultar(P => P.IdProducto == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var respuesta = await _ProductoRepositorio.Eliminar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar el producto");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontro el Producto");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> Catalogo(string categoria ,string buscar)
        {
            try
            {
                var consulta = _ProductoRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())&&
                p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria));

                List<ProductoDTO> lista = _Mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());

                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Obtener(int Id)
        {
            try
            {
                var consulta = _ProductoRepositorio.Consultar(P => P.IdProducto == Id);
                consulta = consulta.Include(c => c.IdCategoriaNavigation);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _Mapper.Map<ProductoDTO>(fromDbModel);
                else
                    throw new TaskCanceledException("No se encontro coincidencias");



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> Lista(string buscar)
        {
            try {
                var consulta = _ProductoRepositorio.Consultar(P => P.Nombre.ToLower().Contains(buscar.ToLower()));

                consulta = consulta.Include(C => C.IdCategoriaNavigation);

                List<ProductoDTO> lista = _Mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
