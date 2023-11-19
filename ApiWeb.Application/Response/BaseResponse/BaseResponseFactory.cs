namespace ApiWeb.Application.Response.BaseResponse;
public abstract class BaseResponseFactory
{
    public abstract BaseResponse CriarBaseResponse(string mensagem, Guid? id);
}

