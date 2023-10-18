using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTurista.Core.DTOs;
using SuperTurista.Core.Models;
using SuperTuriste.Service.Services;

namespace SuperTurista.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BaseController : ControllerBase
    {
        private readonly JwtService _jwtHelper;
        public BaseController(JwtService jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }
        public override OkObjectResult Ok(object value)
        {
            var token = GetUpdatedToken()?.Result;

            return base.Ok(new GenericOkResponseDto()
            {
                Success = true,
                Result = value,
                UpdatedToken = token?.Token
            });
        }
        [HttpGet]
        public async Task<JwtTokenDto> GetUpdatedToken()
        {
            JwtTokenDto token = null;

            //No regenerar token cuando viene de ejecutar el login
            if (!HttpContext.Request.Path.Value.Contains("/login"))
            {
                var u = _jwtHelper.GetTokenInfo();

                if (u != null && u.UserId > 0)
                    token = await _jwtHelper.GenerateToken(new Usuario()
                    {
                        Id = u.UserId,
                        Login = u.UserName,
                    });
            }

            return token;
        }
        public override OkResult Ok()
        {
            return base.Ok();
        }
    }
}