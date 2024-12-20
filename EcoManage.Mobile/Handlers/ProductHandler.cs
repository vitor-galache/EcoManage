﻿using EcoManage.Domain.Entities;
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

        public async Task<Response<Product?>> GetByIdAsync(GetProductByIdRequest request)
        {
            return await _client.GetFromJsonAsync<Response<Product?>>($"v1/products/{request.Id}")
                    ?? new Response<Product?>(null, 400, "Não foi possível obter os produtos");
        }

        public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
        {
            return await _client.GetFromJsonAsync<Response<Product?>>($"v1/products/{request.Slug}")
                    ?? new Response<Product?>(null, 400, "Não foi possível obter os produtos");
        }

        public async Task<Response<Product?>> InactiveAsync(InactivateProductRequest request)
        {
            var response = await _client.PutAsJsonAsync($"v1/products/{request.Id}/inactivate",request);
            var result = await response.Content.ReadFromJsonAsync<Response<Product?>>()
                   ?? new Response<Product?>(null, 400, "Não foi possível processar a resposta");
            return response.IsSuccessStatusCode ? result : new Response<Product?>(null, 400, result.Message);
        }

        public async Task<Response<Product?>> UpdateAsync(UpdateProductRequest request)
        {
            var response = await _client.PutAsJsonAsync($"v1/products/{request.Id}", request);
            var result = await response.Content.ReadFromJsonAsync<Response<Product?>>()
                   ?? new Response<Product?>(null, 400, "Não foi possível processar a resposta");
            return response.IsSuccessStatusCode ? result : new Response<Product?>(null, 400, result.Message);
        }
    }
}
