namespace ApiWeb.Application.Response.BaseResponse;

public class RemoverBaseResponse : BaseResponse
{
    public RemoverBaseResponse(string mensagem, Guid? id)
    {
        Mensagem = mensagem;
        Id = id;
    }
}
