using Microsoft.EntityFrameworkCore;
using PecezuelosModels;
using PecezuelosDTO;
using PecezuelosRepositorio.Contrato;
using PecezuelosServicio.Contrato;
using AutoMapper;

namespace PecezuelosServicio.Implementacion
{
    public class UsuarioServicio: IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _UsuarioRepositorio;
        private readonly IMapper _Mapper;

        public UsuarioServicio(IGenericoRepositorio<Usuario> UsuarioRepositorio, IMapper Mapper)
        {
            _UsuarioRepositorio = UsuarioRepositorio;
            _Mapper = Mapper;
        }

        public async Task<SesionDTO> Autorizacion(LoginDTO login)
        {
            try {
                var consulta = _UsuarioRepositorio.Consultar(U => U.Correo == login.Correo && U.Clave == login.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo == null)
                {
                    return _Mapper.Map<SesionDTO>(fromDbModelo);
                }
                else {
                    throw new TaskCanceledException("No se encontro coincidencias");
                }
                

            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO usuario)
        {
            try
            {
                var DbModelos = _Mapper.Map<Usuario>(usuario);
                var rspModelo = await _UsuarioRepositorio.Crear(DbModelos);

                if (rspModelo.IdUsuario != 0)
                    return _Mapper.Map<UsuarioDTO>(rspModelo);
                else {
                    throw new TaskCanceledException("No se puede crear");

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UsuarioDTO usuario)
        {
            try
            {
                var consulta = _UsuarioRepositorio.Consultar(U => U.IdUsuario == usuario.IdUsuario);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NombreCompleto = usuario.NombreCompleto;
                    fromDbModel.Correo = usuario.Correo;
                    fromDbModel.Clave = usuario.Clave;

                    var respuesta = await _UsuarioRepositorio.Editar(fromDbModel);

                    if (!respuesta)
                         throw new TaskCanceledException("No se puedo editar");
                    return respuesta;
                }
                else {
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
                var consulta = _UsuarioRepositorio.Consultar(U => U.IdUsuario == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var respuesta = await _UsuarioRepositorio.Eliminar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontro el usuario");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            try
            {
                var consulta = _UsuarioRepositorio.Consultar(p =>
                p.Rol == rol &&
                string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));

                List<UsuarioDTO> lista = _Mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());

                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Obtener(int Id)
        {
            try
            {
                var consulta = _UsuarioRepositorio.Consultar(U => U.IdUsuario == Id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _Mapper.Map<UsuarioDTO>(fromDbModel);
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
