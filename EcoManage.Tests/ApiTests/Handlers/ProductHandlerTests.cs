using EcoManage.Api.Handlers;
using EcoManage.Domain;
using EcoManage.Domain.Requests.Product;
using EcoManage.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoManage.Tests.ApiTests.Handlers;

[Trait("ProductHandler","UnitTest")]
public class ProductHandlerTests
{
    private readonly AppDbContext _fakeContext;
    private readonly ProductHandler _handler;
    private readonly Faker _faker = new ("pt_BR");
    
    public ProductHandlerTests()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>();
        dbOptions.UseInMemoryDatabase("FakeContext");
        
        _fakeContext = new AppDbContext(dbOptions.Options);
        _handler = new ProductHandler(_fakeContext);
    }

    [Fact]
    public async Task Create_Product_Async_Deve_Adicionar_Produto_Ao_Passar_RequestValido()
    {
        
        var productTitle = _faker.Commerce.ProductName();
        var productDescription = _faker.Commerce.ProductDescription();
        
        var validRequest = new CreateProductRequest
        {
            Title = productTitle,
            Description = productDescription
        };

        
        var result = await _handler.CreateAsync(validRequest);

        
        Assert.NotNull(result.Data);
        
        var productId = result.Data.Id;

        var insertedProduct = await _fakeContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

        Assert.NotNull(insertedProduct);
        Assert.Equal(validRequest.Title,insertedProduct.Title);
        Assert.Equal(validRequest.Description,insertedProduct.Description);
        Assert.NotEmpty(insertedProduct.Slug);
    }
    
    [Fact]
    public async Task Get_By_Id_Async_Deve_retornar_response_com_produto_ao_passar_id()
    {
        var productTitle = _faker.Commerce.ProductName();
        var productDescription = _faker.Commerce.ProductDescription();
        
        var createProductRequest = new CreateProductRequest
        {
            Title = productTitle,
            Description = productDescription
        };
        var productCreated  = await _handler.CreateAsync(createProductRequest);

        var getProductRequest = new GetProductByIdRequest
        {
            Id = productCreated.Data!.Id
        };

        var response = await _handler.GetByIdAsync(getProductRequest);

        Assert.NotNull(response.Data);
        Assert.Equal(response.Data.Id,productCreated.Data.Id);
    }
    
    [Fact]
    public async Task Get_By_Id_Async_Deve_retornar_response_com_data_null_ao_passar_id_inexistente()
    {
        var getProductInvalidRequest = new GetProductByIdRequest() { Id = 0};

        var response = await  _handler.GetByIdAsync(getProductInvalidRequest);
        
        Assert.Null(response.Data);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task Get_By_Slug_Deve_Retornar_Response_Com_Produto_Ao_Passar_Slug_Cadastrado()
    {
        var productTitle = _faker.Commerce.ProductName();
        var productDescription = _faker.Commerce.ProductDescription();
        
        var createProductRequest = new CreateProductRequest
        {
            Title = productTitle,
            Description = productDescription
        };
        var productCreated  = await _handler.CreateAsync(createProductRequest);

        var expectedSlug = productCreated.Data!.Slug;
        
        var getProductRequest = new GetProductBySlugRequest
        {
            Slug = productCreated.Data.Slug
        };

        var response = await _handler.GetBySlugAsync(getProductRequest);
        
        
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Data);
        Assert.Equal(expectedSlug,response.Data!.Slug);
    }

    [Fact]
    public async Task Get_All_Deve_Retornar_Lista_Vazia_Caso_Nenhum_Produto_Ativo_Tenha_Sido_Cadastrado()
    {
        
        var getAllProductsRequest = new GetAllProductsRequest
        {
            PageNumber = Configuration.DefaultPageNumber,
            PageSize = Configuration.DefaultPageSize
        };

        var response = await _handler.GetAllAsync(getAllProductsRequest);
        
        Assert.True(response.IsSuccess);
        Assert.Empty(response.Data!);
    }

    [Fact]
    public async Task Get_All_Deve_Retornar_Todos_Produtos_Ativos_Apenas()
    {
        var productTitle = _faker.Commerce.ProductName();
        var productDescription = _faker.Commerce.ProductDescription();
        
        var createProductRequest = new CreateProductRequest
        {
            Title = productTitle,
            Description = productDescription
        };
        
       await _handler.CreateAsync(createProductRequest);
        
        var getAllProductsRequest = new GetAllProductsRequest
        {
            PageNumber = Configuration.DefaultPageNumber,
            PageSize = Configuration.DefaultPageSize
        };

        var response = await _handler.GetAllAsync(getAllProductsRequest);
        
        Assert.NotEmpty(response.Data!);
    }
}