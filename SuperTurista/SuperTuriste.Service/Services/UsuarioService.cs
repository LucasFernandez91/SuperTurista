using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SuperTurista.Core.DTOs;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperTuriste.Service.Services
{
    public interface IUsuarioService : IBaseService
    {
        Task<Usuario> GetById(long id);
        Task<SaveUsuarioDTO> Save(SaveUsuarioDTO model);
    }
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly string _publicWebUrl;
        private readonly string _mailPublicWebUrl;

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtService _jwtHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly bool _useAws;

        public UsuarioService
        (
            IUsuarioRepository usuarioRepository,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
            _jwtHelper = jwtHelper;

            if (configuration != null)
            {
                _publicWebUrl = configuration["PublicWebUrl"];

                if (!bool.TryParse(configuration["UseAws"], out _useAws))
                    _useAws = false;
            }
        }

        #region Getters

        public async Task<Usuario> GetById(long id)
        {
            return (await _usuarioRepository.ExecuteQueryAsync(x => x.Id == id)).FirstOrDefault() ?? new Usuario();
        }

        #endregion

        #region DB Access

        public async Task<SaveUsuarioDTO> Save(SaveUsuarioDTO model)
        {
            if (!(await Validate(model)))
                throw new Exception("Ocurrió un error al intentar guardar el usuario");

            Usuario u = null;

            if (model.Id == 0)
                u = await Insert(model);
            else
                u = await Update(model);
            await _usuarioRepository.SaveChanges();
            model.Id = (u?.Id ?? 0);

            return model;
        }

        private Task<Usuario?> Update(SaveUsuarioDTO model)
        {
            throw new NotImplementedException();
        }

        private Task<Usuario?> Insert(SaveUsuarioDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(long itemId)
        {
            var u = await GetById(itemId);
            return await _usuarioRepository.SoftDelete(u);
        }
        private Task<bool> Validate(SaveUsuarioDTO model)
        {
            return Task.Run(() => true);
        }
        #endregion
    }
}
