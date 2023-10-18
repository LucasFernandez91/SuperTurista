using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SuperTurista.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SuperTurista.Core.DTOs;

namespace SuperTurista.Core.Helpers
{
    public class JwtHelper
    {
        public readonly string _secret;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtHelper(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _secret = configuration["Jwt:Key"]??"";
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetSecret()
        {
            if (string.IsNullOrWhiteSpace(_secret))
                throw new Exception("No tiene definido el key para generar el token");
            return _secret;
        }

        public JwtTokenDto GenerateToken(Usuario usuario, int expireMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GetSecret());
            var expDate = DateTime.UtcNow.AddMinutes(expireMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Login),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.PrimarySid, usuario.Id.ToString()),
                }),
                Expires = expDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var result = new JwtTokenDto()
            {
                Token = tokenHandler.WriteToken(token),
                ExpirationDate = expDate
            };

            //Lo agrego en el header del Request actual para poder utilizarlo en proximas operaciones que se hagan en este request
            if (_httpContextAccessor?.HttpContext?.Request?.Headers != null)
            {
                if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
                    _httpContextAccessor.HttpContext.Request.Headers["Authorization"] = result.Token;
                else
                    _httpContextAccessor.HttpContext.Request.Headers.Add("Authorization", result.Token);
            }

            return result;
        }

        public UserTokenInfoDto GetTokenInfo()
        {
            try
            {
                _httpContextAccessor?.HttpContext?.Request?.Headers?.TryGetValue("Authorization", out var t);

                if (!string.IsNullOrWhiteSpace(t))
                {
                    t = t.ToString()?.Replace("Bearer ", "")?.Trim();

                    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var tokenS = handler.ReadToken(t) as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

                    long.TryParse(tokenS?.Claims?.FirstOrDefault(x => x.Type == "nameid")?.Value, out var uId);
                    long.TryParse(tokenS?.Claims?.FirstOrDefault(x => x.Type == "groupsid")?.Value, out var tId);
                    long.TryParse(tokenS?.Claims?.FirstOrDefault(x => x.Type == "primarysid")?.Value, out var pId);

                    return new UserTokenInfoDto()
                    {
                        UserName = tokenS?.Claims?.FirstOrDefault(x => x.Type == "unique_name")?.Value,
                        UserId = uId,
                        PersonId = pId
                    };
                }
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException();
            }

            return null;
        }
    }
}
