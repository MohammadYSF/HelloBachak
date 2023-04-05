using Business.Auth;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : Controller
{
    ITokenService tokenService;
    IUserRepository userRepository;
    IHttpContextAccessor _httpContextAccessor;
    public TokenController(ITokenService tokenService, IUserRepository userRepository , IHttpContextAccessor httpContextAccessor)
    {
        this.tokenService = tokenService;
        this.userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;

    }

    [HttpPost("Refresh")]
    public IActionResult Refresh(string token, string refreshToken)
    {
        var principal = this.tokenService.GetPrincipalFromExpiredToken(token);
        var username = principal.Identity.Name;
        var user = this.userRepository.FindUserByUsername(username);

        if (user == null || user.RefreshToken != refreshToken)
            return BadRequest();

        var newToken = tokenService.GenerateAccessToken(principal.Claims);
        var newRefreshToken = tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;

        this.userRepository.Update(user);

        return new ObjectResult(new
        {
            token = newToken,
            refreshToken = newRefreshToken
        });

    }

    [Authorize]
    [HttpPost("Revoke")]
    public IActionResult Revoke()
    {

        var username = User.Identity.Name;
        var user = this.userRepository.FindUserByUsername(username);

        if (user == null)
            return BadRequest();

        user.RefreshToken = null;

        this.userRepository.Update(user);
        this.userRepository.Save();

        
        return NoContent();

    }

}

