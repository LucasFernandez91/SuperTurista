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
        [HttpGet("list")]
        public async Task<ActionResult<UsuarioDTO>> List()
        {
            return Ok(await _usuarioService.List());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario([FromRoute] long id)
        {
            return Ok(await _usuarioService.GetById(id));
        }
        [HttpPost("save")]
        public async Task<ActionResult<SaveUsuarioDTO>> PostUsuario([FromBody] SaveUsuarioDTO model)
        {
            return Ok(await _usuarioService.Save(model));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaveUsuarioDTO>> Delete([FromRoute] long id)
        {
            return Ok(await _usuarioService.Delete(id));
        }
    }
}