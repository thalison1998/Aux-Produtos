using System.Text.Json.Serialization;

namespace ApiWeb.Application.Response.AutenticacaoResponse;

public class UsuarioLoginResponse
{
    public UsuarioLoginResponse() { }
    public UsuarioLoginResponse(string token, DateTime? dataExpiracao, bool sucesso)
    {
        Token = token;
        DataExpiracao = dataExpiracao;
        Sucesso = sucesso;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Token { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? DataExpiracao { get; set; }

    public bool Sucesso { get; set; }
}
