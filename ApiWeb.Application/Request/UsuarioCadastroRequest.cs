namespace ApiWeb.Application.Request;

public class UsuarioCadastroRequest
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public string SenhaConfirmacao { get; set; }
}
