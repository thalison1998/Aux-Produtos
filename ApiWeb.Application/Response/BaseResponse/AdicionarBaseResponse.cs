namespace ApiWeb.Application.Response.BaseResponse;
public class AdicionarBaseResponse : BaseResponse
{
    public AdicionarBaseResponse(string mensagem, Guid id)
    {
        Mensagem = mensagem;
        Id = id;
    }
}
