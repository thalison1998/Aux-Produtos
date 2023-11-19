using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Application.Response.AutenticacaoResponse;
using FluentValidation;
using FluentValidation.Results;
using Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Service;

public class IdentityService : IIdentityAppService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usarioCadastro)
    {
        var userIdentity = new IdentityUser
        {
            UserName = usarioCadastro.Email,
            Email = usarioCadastro.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(userIdentity, usarioCadastro.Senha);

        if (result.Succeeded)
            await _userManager.SetLockoutEnabledAsync(userIdentity, false);

        if (!result.Succeeded && result.Errors.Count() > 0)
        {
            throw new ValidationException("Erro ao criar usuário", result.Errors.Select(x => new ValidationFailure() { ErrorMessage = x.Description, ErrorCode = x.Code }));
        }

        var usuarioCadastro = new UsuarioCadastroResponse(true);

        return usuarioCadastro;
    }

    private async Task<UsuarioLoginResponse> GerarToken(string email)
    {
        var usuario = await _userManager.FindByEmailAsync(email);
        var tokenClaims = await ObterClaims(usuario);

        var dataExpiracao = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);

        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: tokenClaims,
            notBefore: DateTime.Now,
            expires: dataExpiracao,
            signingCredentials: _jwtOptions.SigningCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new UsuarioLoginResponse(sucesso: true, token: token, dataExpiracao: dataExpiracao);
    }

    private async Task<IList<Claim>> ObterClaims(IdentityUser user)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, DateTime.Now.ToString()));

        foreach (var role in roles)
        {
            claims.Add(new Claim("role", role));
        }

        return claims;
    }

    public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usarioLogin)
    {
        var result = await _signInManager.PasswordSignInAsync(usarioLogin.Email, usarioLogin.Senha, false, true);

        var usuarioLoginResponse = new UsuarioLoginResponse();

        if (result.Succeeded)
            usuarioLoginResponse = await GerarToken(usarioLogin.Email);

        return usuarioLoginResponse;
    }
}
