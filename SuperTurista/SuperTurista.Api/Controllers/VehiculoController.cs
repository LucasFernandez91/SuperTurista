using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTurista.Core.DTOs;
using SuperTuriste.Service.Services;

namespace SuperTurista.Api.Controllers
{
    [Authorize]
    public class VehiculoController : BaseController
    {
        private readonly IVehiculoService _vehiculoService;
        public VehiculoController
        (
            IVehiculoService VehiculoService,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _vehiculoService = VehiculoService;
        }
        [HttpGet("list")]
        public async Task<ActionResult<VehiculoDTO>> List()
        {
            return Ok(await _vehiculoService.List());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoDTO>> GetVehiculo([FromRoute] long id)
        {
            return Ok(await _vehiculoService.GetById(id));
        }
        [HttpPost("save")]
        public async Task<ActionResult<SaveVehiculoDTO>> PostVehiculo([FromBody] SaveVehiculoDTO model)
        {
            return Ok(await _vehiculoService.Save(model));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaveVehiculoDTO>> Delete([FromRoute] long id)
        {
            return Ok(await _vehiculoService.Delete(id));
        }
    }
}