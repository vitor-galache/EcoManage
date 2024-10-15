using EcoManage.Api.Data;
using EcoManage.Api.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;
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
        var expectedTitle = _faker.Commerce.ProductName();
        var expectedDescription = _faker.Commerce.ProductDescription();
        
        var validRequest = new CreateProductRequest
        {
            Title = expectedTitle,
            Description = expectedDescription
        };
        
        var result = await _handler.CreateAsync(validRequest);
        
        Assert.NotNull(result.Data);
        Assert.Equal(expectedTitle,result.Data!.Title);
        Assert.Equal(expectedDescription,result.Data!.Description);
        Assert.True(result.IsSuccess);
        
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
        var expectedTitle = _faker.Commerce.ProductName();
        var expectedDescription = _faker.Commerce.ProductDescription();
        
        var createProductRequest = new CreateProductRequest
        {
            Title = expectedTitle,
            Description = expectedDescription
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
        var getProductRequest = new GetProductByIdRequest() { Id = 0};

        var response = await  _handler.GetByIdAsync(getProductRequest);
        
        Assert.Null(response.Data);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task Get_By_Slug_Deve_Retornar_Response_Com_Produto_Ao_Passar_Slug_Cadastrado()
    {
        var expectedTitle = _faker.Commerce.ProductName();
        var expectedDescription = _faker.Commerce.ProductDescription();
        
        var createProductRequest = new CreateProductRequest
        {
            Title = expectedTitle,
            Description = expectedDescription
        };
        var productCreated  = await _handler.CreateAsync(createProductRequest);

        var slug = productCreated.Data!.Slug;
        
        var getProductRequest = new GetProductBySlugRequest
        {
            Slug = productCreated.Data.Slug
        };

        var response = await _handler.GetBySlugAsync(getProductRequest);
        
        
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Data);
        Assert.Equal(slug,response.Data!.Slug);
    }
}