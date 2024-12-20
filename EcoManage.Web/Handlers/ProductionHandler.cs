using System.Net.Http.Json;
using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Web.Handlers;

public class ProductionHandler(IHttpClientFactory httpClientFactory)
    : IProductionHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Production?>> CreateProductionAsync(CreateProductionRequest request)
    {
        var response = await _client.PostAsJsonAsync("v1/productions", request);
        var result = await response.Content.ReadFromJsonAsync<Response<Production?>>()?? new Response<Production?>(null,400,"Não foi possível processar a resposta");

        return response.IsSuccessStatusCode ? result : new Response<Production?>(null, 400, result.Message);
    }

    public async Task<Response<Production?>> CancelAsync(CancelProductionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/productions/{request.Id}/cancel", request);

        return await result.Content.ReadFromJsonAsync<Response<Production?>>()
               ?? new Response<Production?>(null, 400, "Não foi possível cancelar produção");
    }

    public async Task<Response<Production?>> GetByIdAsync(GetProductionByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Production?>>($"v1/productions/{request.Id}")
           ?? new Response<Production?>(null, 400, "Não foi possível obter produção");

    public async Task<Response<Production?>> GetByNumberAsync(GetProductionByNumberRequest request)
        => await _client.GetFromJsonAsync<Response<Production?>>($"v1/productions/{request.Number}")
           ?? new Response<Production?>(null, 400, "Não foi possível obter produção");

    public async Task<Response<Production?>> ToHarvestAsync(UpdateProductionToHarvestRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/productions/{request.Id}/to-harvest", request);

        return await result.Content.ReadFromJsonAsync<Response<Production?>>()
               ?? new Response<Production?>(null, 400, "Não foi possível atualizar status para colheita");
    }

    public async Task<Response<Production?>> ToCultivationAsync(UpdateProductionToCultivationRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/productions/{request.Id}/to-cultivation", request);

        return await result.Content.ReadFromJsonAsync<Response<Production?>>()
               ?? new Response<Production?>(null, 400, "Não foi possível atualizar status para cultivo");
    }
    public async Task<PagedResponse<List<Production>?>> GetAllAsync(GetAllProductionsRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Production>?>>("v1/productions")
           ?? new PagedResponse<List<Production>?>(null, 400, "Não foi possível obter produções");
    public async Task<Response<Production?>> FinishAsync(FinishProductionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/productions/{request.Id}/finish", request);
        return await result.Content.ReadFromJsonAsync<Response<Production?>>()
               ?? new Response<Production?>(null, 400, "Não foi possível finalizar produção");
    }
}