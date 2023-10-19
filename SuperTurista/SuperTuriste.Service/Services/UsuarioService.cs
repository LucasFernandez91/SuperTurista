using SuperTurista.Core.DTOs;
using SuperTurista.Core.Mappers;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;
using System.Text.RegularExpressions;

namespace SuperTuriste.Service.Services
{
    public interface IUsuarioService : IBaseService
    {
        Task<List<Usuario>> List();
        Task<Usuario> GetById(long id);
        Task<Usuario> GetByLogin(string login);
        Task<SaveUsuarioDTO> Save(SaveUsuarioDTO model);
        Task<bool> Delete(long id);
    }
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService
        (
            IUsuarioRepository usuarioRepository,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _usuarioRepository = usuarioRepository;
        }

        #region Getters

        public async Task<List<Usuario>> List()
        {
            return (await _usuarioRepository.ExecuteQueryAsync()).ToList();
        }

        public async Task<Usuario> GetById(long id)
        {
            return (await _usuarioRepository.ExecuteQueryAsync(x => x.Id == id)).FirstOrDefault() ?? new Usuario();
        }

        public async Task<Usuario> GetByLogin(string login)
        {
            return (await _usuarioRepository.ExecuteQueryAsync(x => x.Login == login)).FirstOrDefault() ?? new Usuario();
        }
        #endregion

        #region DB Access

        public async Task<SaveUsuarioDTO> Save(SaveUsuarioDTO model)
        {
            if (!Validate(model))
                throw new Exception("Ocurrió un error al intentar guardar el usuario");

            Usuario u;

            if (model.Id == 0)
                u = await Insert(model);
            else
                u = await Update(model);
            await _usuarioRepository.SaveChanges();
            model.Id = (u?.Id ?? 0);

            return model;
        }

        private async Task<Usuario> Update(SaveUsuarioDTO model)
        {
            return await _usuarioRepository.Update(new UsuarioMapper().MapToUsuario(model));
        }
        private async Task<Usuario> Insert(SaveUsuarioDTO model)
        {
            return await _usuarioRepository.Add(new UsuarioMapper().MapToUsuario(model));
        }
        public async Task<bool> Delete(long id)
        {
            var u = await GetById(id);
            return await _usuarioRepository.SoftDelete(u);
        }
        private bool Validate(SaveUsuarioDTO model)
        {
            string patron = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            if (string.IsNullOrEmpty(model.Email) ||
                !Regex.IsMatch(model.Email, patron) ||
                string.IsNullOrEmpty(model.Nombre) ||
                string.IsNullOrEmpty(model.Apellido) ||
                string.IsNullOrEmpty(model.Telefono) ||
                string.IsNullOrEmpty(model.Login) ||
                string.IsNullOrEmpty(model.Password))
                return false;
            return true;
        }
        #endregion
    }
}
