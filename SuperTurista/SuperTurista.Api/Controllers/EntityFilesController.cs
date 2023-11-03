using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTurista.Core.DTOs;
using SuperTuriste.Service.Services;

namespace SuperTurista.Api.Controllers
{
    [Authorize]
    public class EntityFilesController : BaseController
    {
        private readonly IEntityFilesService _entityFilesService;
        public EntityFilesController
        (
            IEntityFilesService EntityFilesService,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _entityFilesService = EntityFilesService;
        }
        [HttpGet("list")]
        public async Task<ActionResult<EntityFilesDTO>> List()
        {
            return Ok(await _entityFilesService.List());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityFilesDTO>> GetEntityFiles([FromRoute] long id)
        {
            return Ok(await _entityFilesService.GetById(id));
        }
        [HttpPost("save")]
        public async Task<ActionResult<SaveEntityFilesDTO>> PostEntityFiles([FromBody] SaveEntityFilesDTO model)
        {
            return Ok(await _entityFilesService.Save(model));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaveEntityFilesDTO>> Delete([FromRoute] long id)
        {
            return Ok(await _entityFilesService.Delete(id));
        }
    }
}