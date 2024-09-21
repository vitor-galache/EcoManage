using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EcoManage.Desktop.Handlers
{
    public class SupplierHandler : ISupplierHandler
    {

        public async Task<Response<Supplier?>> CreateAsync(CreateSupplierRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.PostAsJsonAsync($"{DesktopConfiguration.ApiUrl}v1/suppliers", request);
                return await result.Content.ReadFromJsonAsync<Response<Supplier?>>()
                       ?? new Response<Supplier?>(null, 400, "Falha ao cadastrar fornecedor");
            }
        }

        public async Task<Response<Supplier?>> DeleteAsync(DeleteSupplierRequest request)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync($"{DesktopConfiguration.ApiUrl}v1/suppliers/{request.Id}");

                return await result.Content.ReadFromJsonAsync<Response<Supplier?>>()
                       ?? new Response<Supplier?>(null, 400, "Não foi possível excluir fornecedor");
            }
        }

        public async Task<PagedResponse<List<Supplier>>> GetAllAsync(GetAllSupplierRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetFromJsonAsync<PagedResponse<List<Supplier>?>>(DesktopConfiguration.ApiUrl + "v1/suppliers");
                }
                catch
                {
                    var result = new PagedResponse<List<Supplier>?>(null, 400, "Não foi possivel obter fornecedores");
                    MessageBox.Show(result.Message);
                    return result;
                }
            }
        }

        public async Task<Response<Supplier?>> GetByIdAsync(GetSupplierByIdRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetFromJsonAsync<Response<Supplier?>>(DesktopConfiguration.ApiUrl + "v1/suppliers/" + request.Id);
                }
                catch
                {
                    var result = new Response<Supplier?>(null, 400, "Não foi possivel obter fornecedores");
                    MessageBox.Show(result.Message);
                    return result;
                }
            }
        }

        public async Task<Response<Supplier?>> UpdateAsync(UpdateSupplierRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.PutAsJsonAsync($"{DesktopConfiguration.ApiUrl}v1/suppliers/{request.Id}", request);

                return await result.Content.ReadFromJsonAsync<Response<Supplier?>>()
                       ?? new Response<Supplier?>(null, 400, "Não foi possível atualizar fornecedor");
            }
        }
    }
}
