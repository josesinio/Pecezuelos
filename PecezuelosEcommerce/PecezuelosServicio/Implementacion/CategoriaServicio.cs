using PecezuelosServicio.Contrato;
using Microsoft.EntityFrameworkCore;
using PecezuelosModels;
using PecezuelosDTO;
using PecezuelosRepositorio.Contrato;
using AutoMapper;

namespace PecezuelosServicio.Implementacion
{
    public class CategoriaServicio: ICategoriaServicio
    {
        private readonly IGenericoRepositorio<Categoria> _CategoriaRepositorio;
        private readonly IMapper _Mapper;

        public CategoriaServicio(IGenericoRepositorio<Categoria> CategoriaRepositorio, IMapper Mapper)
        {
            _CategoriaRepositorio = CategoriaRepositorio;
            _Mapper = Mapper;
        }

        public async Task<CategoriaDTO> Crear(CategoriaDTO categoria)
        {
            try
            {
                var DbModelos = _Mapper.Map<Categoria>(categoria);
                var rspModelo = await _CategoriaRepositorio.Crear(DbModelos);

                if (rspModelo.IdCategoria != 0)
                    return _Mapper.Map<CategoriaDTO>(rspModelo);
                else
                {
                    throw new TaskCanceledException("No se pudo crear categoria");

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(CategoriaDTO categoria)
        {
            try
            {
                var consulta = _CategoriaRepositorio.Consultar(C => C.IdCategoria == categoria.IdCategoria);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = categoria.Nombre;

                    var respuesta = await _CategoriaRepositorio.Editar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se puedo editar");
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
                var consulta = _CategoriaRepositorio.Consultar(C => C.IdCategoria == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var respuesta = await _CategoriaRepositorio.Eliminar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontro la categoria");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoriaDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _CategoriaRepositorio.Consultar(p =>
                string.Concat(p.Nombre.ToLower()).Contains(buscar.ToLower()));

                List<CategoriaDTO> lista = _Mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());

                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaDTO> Obtener(int Id)
        {
            try
            {
                var consulta = _CategoriaRepositorio.Consultar(C => C.IdCategoria == Id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _Mapper.Map<CategoriaDTO>(fromDbModel);
                else
                    throw new TaskCanceledException("No se encontro coincidencias");



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
