using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;
using EcoManage.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EcoManage.Mobile.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private HttpClient _client = ApiService.Instance.Client;

        public async Task<Response<Product?>> CreateAsync(CreateProductRequest request)
        {
            var response = await _client.PostAsJsonAsync($"v1/products", request);
            var result = await response.Content.ReadFromJsonAsync<Response<Product?>>()
                   ?? new Response<Product?>(null, 400, "Não foi possível processar a resposta");
            return response.IsSuccessStatusCode ? result : new Response<Product?>(null, 400, result.Message);
        }

        public async Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request)
        { 
            return await _client.GetFromJsonAsync<PagedResponse<List<Product>?>>("v1/products") 
                   ?? new PagedResponse<List<Product>?>(null, 400, "Não foi possível obter os produtos");
        }

        public Task<Response<Product?>> GetByIdAsync(GetProductByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Product?>> InactiveAsync(InactivateProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Product?>> UpdateAsync(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
