using ApiWeb.Domain.Interfaces;
using AutoMapper;
using ApiWeb.Application.Request;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Application.AppService.Interface;
using ApiWeb.Domain.Entidades;
using ApiWeb.Application.Response.Produto;
using ApiWeb.Application.Response.BaseResponse;

namespace ApiWeb.Application.AppService;
public class ProdutoAppService : IProdutoAppService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProdutoAppService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Criar(CriarProdutoRequest request)
    {
        var produto = _mapper.Map<Produto>(request);

        _produtoRepository.Adicionar(produto);

        await _unitOfWork.CommitAsync();

        BaseResponseFactory adicionarFactory = new AdicionarBaseResponseFactory();

        return adicionarFactory.CriarBaseResponse("Produto adicionado com sucesso.", produto.Id);
    }
}