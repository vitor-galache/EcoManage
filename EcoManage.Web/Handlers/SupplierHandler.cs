using System.Net.Http.Json;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Web.Handlers;

public class SupplierHandler(IHttpClientFactory httpClientFactory) : ISupplierHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Supplier?>> CreateAsync(CreateSupplierRequest request)
    {
        var  response = await _client.PostAsJsonAsync("v1/suppliers", request);
        var result = await response.Content.ReadFromJsonAsync<Response<Supplier?>>()?? new Response<Supplier?>(null,400,"Não foi possível processar a resposta");
        return response.IsSuccessStatusCode ? result : new Response<Supplier?>(null, 400, result.Message);
    }

    public async Task<PagedResponse<List<Supplier>>> GetAllAsync(GetAllSupplierRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Supplier>>>("v1/suppliers")
           ?? new PagedResponse<List<Supplier>>(null, 400, "Não foi possivel obter fornecedores");

    public async Task<Response<Supplier?>> GetByIdAsync(GetSupplierByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Supplier?>>($"v1/suppliers/{request.Id}")
           ?? new Response<Supplier?>(null, 400, "Não foi possivel obter fornecedor");

    public async Task<Response<Supplier?>> UpdateAsync(UpdateSupplierRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/suppliers/{request.Id}", request);

        return await result.Content.ReadFromJsonAsync<Response<Supplier?>>()
               ?? new Response<Supplier?>(null, 400, "Não foi possível atualizar fornecedor");
    }

    public async Task<Response<Supplier?>> DeleteAsync(DeleteSupplierRequest request)
    {
        var result = await _client.DeleteAsync($"v1/suppliers/{request.Id}");
        
        return await result.Content.ReadFromJsonAsync<Response<Supplier?>>()
               ?? new Response<Supplier?>(null, 400, "Não foi possível excluir fornecedor");
    }
}