using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTurista.Core.DTOs;
using SuperTuriste.Service.Services;

namespace SuperTurista.Api.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController
        (
            IUsuarioService usuarioService,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario([FromRoute] long id)
        {
            var result = await _usuarioService.GetById(id);
            return Ok(result);
        }

        [HttpPost("save")]
        public async Task<ActionResult<SaveUsuarioDTO>> PostUsuario([FromBody] SaveUsuarioDTO model)
        {
            var result = await _usuarioService.Save(model);
            return Ok(result);
        }
    }
}