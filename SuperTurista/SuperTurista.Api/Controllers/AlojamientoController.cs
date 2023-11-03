using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTurista.Core.DTOs;
using SuperTuriste.Service.Services;

namespace SuperTurista.Api.Controllers
{
    [Authorize]
    public class AlojamientoController : BaseController
    {
        private readonly IAlojamientoService _alojamientoService;
        public AlojamientoController
        (
            IAlojamientoService AlojamientoService,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _alojamientoService = AlojamientoService;
        }
        [HttpGet("list")]
        public async Task<ActionResult<AlojamientoDTO>> List()
        {
            return Ok(await _alojamientoService.List());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AlojamientoDTO>> GetAlojamiento([FromRoute] long id)
        {
            return Ok(await _alojamientoService.GetById(id));
        }
        [HttpPost("save")]
        public async Task<ActionResult<SaveAlojamientoDTO>> PostAlojamiento([FromBody] SaveAlojamientoDTO model)
        {
            return Ok(await _alojamientoService.Save(model));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaveAlojamientoDTO>> Delete([FromRoute] long id)
        {
            return Ok(await _alojamientoService.Delete(id));
        }
    }
}