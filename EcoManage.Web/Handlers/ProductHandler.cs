using System.Net.Http.Json;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;

namespace EcoManage.Web.Handlers;

public class ProductHandler(IHttpClientFactory httpClientFactory) : IProductHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Product?>> CreateAsync(CreateProductRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/products", request);

        return await result.Content.ReadFromJsonAsync<Response<Product?>>()
               ?? new Response<Product?>(null, 400, "Não foi possível cadastrar o produto");
    }

    public async Task<Response<Product?>> GetByIdAsync(GetProductByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Product?>>($"v1/products/{request.Id}")
           ?? new Response<Product?>(null, 400, "Não foi possível obter o produto");

    public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
        => await _client.GetFromJsonAsync<Response<Product?>>($"v1/products/{request.Slug}")
           ?? new Response<Product?>(null, 400, "Não foi possível obter o produto");

    public async Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Product>?>>("v1/products")
           ?? new PagedResponse<List<Product>?>(null, 400, "Não foi possível obter os produtos");

    public async Task<Response<Product?>> UpdateAsync(UpdateProductRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/products/{request.Id}", request);

        return await result.Content.ReadFromJsonAsync<Response<Product?>>()
               ?? new Response<Product?>(null, 400, "Não foi possível atualzar o produto");
    }

    public async Task<Response<Product?>> InactiveAsync(InactivateProductRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/products/{request.Id}/inactivate",request);

        return await result.Content.ReadFromJsonAsync<Response<Product?>>()
               ?? new Response<Product?>(null, 400, "Não foi possível inativar o produto");
    }
}