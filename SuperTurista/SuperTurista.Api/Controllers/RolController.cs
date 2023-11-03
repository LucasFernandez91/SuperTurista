using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTurista.Core.DTOs;
using SuperTuriste.Service.Services;

namespace SuperTurista.Api.Controllers
{
    [Authorize]
    public class RolController : BaseController
    {
        private readonly IRolService _rolService;
        public RolController
        (
            IRolService RolService,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _rolService = RolService;
        }
        [HttpGet("list")]
        public async Task<ActionResult<RolDTO>> List()
        {
            return Ok(await _rolService.List());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RolDTO>> GetRol([FromRoute] long id)
        {
            return Ok(await _rolService.GetById(id));
        }
        [HttpPost("save")]
        public async Task<ActionResult<SaveRolDTO>> PostRol([FromBody] SaveRolDTO model)
        {
            return Ok(await _rolService.Save(model));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaveRolDTO>> Delete([FromRoute] long id)
        {
            return Ok(await _rolService.Delete(id));
        }
    }
}