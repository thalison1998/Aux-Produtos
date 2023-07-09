namespace ApiWeb.Application.Response.BaseResponse;
public class AdicionarBaseResponseFactory : BaseResponseFactory
{
    public override BaseResponse CriarBaseResponse(string mensagem, Guid id)
    {
        return new AdicionarBaseResponse(mensagem, id);
    }
}
