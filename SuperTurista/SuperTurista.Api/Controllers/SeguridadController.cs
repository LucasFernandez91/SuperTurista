using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTurista.Core.DTOs;
using SuperTuriste.Service.Services;

namespace SuperTurista.Api.Controllers
{
    [Authorize]
    public class SeguridadController : BaseController
    {
        private readonly ISeguridadService seguridadService;

        public SeguridadController
        (
            ISeguridadService seguridadService,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            this.seguridadService = seguridadService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<SaveUsuarioDTO>> Login([FromBody] LoginRequest model)
        {
            var result = await seguridadService.Login(model);
            return Ok(result);
        }
        [HttpPost("Registro")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Registro([FromBody] RegistroRequest model)
        {
            var result = await seguridadService.Register(model);
            return Ok(result);
        }
    }
}