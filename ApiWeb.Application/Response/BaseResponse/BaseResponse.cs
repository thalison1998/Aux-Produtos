namespace ApiWeb.Application.Response.BaseResponse;
public abstract class BaseResponse
{
    public string Mensagem { get; set; }
    public Guid Id { get; set; }
}
