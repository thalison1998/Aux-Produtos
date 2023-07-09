namespace ApiWeb.Application.Response.BaseResponse;
public class RemoverBaseResponseFactory : BaseResponseFactory
{
    public override BaseResponse CriarBaseResponse(string mensagem, Guid id)
    {
        return new RemoverBaseResponse(mensagem, id);
    }
}