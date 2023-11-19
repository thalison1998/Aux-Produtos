namespace ApiWeb.Application.Response.AutenticacaoResponse;

public class UsuarioCadastroResponse
{
    public UsuarioCadastroResponse(bool mensagem)
    {
        Mensagem = mensagem;
    }

    public bool Mensagem { get; set; }
}
