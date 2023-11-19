using ApiWeb.Application.Request;
using ApiWeb.Application.Response.AutenticacaoResponse;

namespace ApiWeb.Application.AppService.Interface;

public interface IIdentityAppService
{
    Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usarioCadastro);
    Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usarioLogin);
}