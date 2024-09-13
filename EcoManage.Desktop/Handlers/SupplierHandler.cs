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

        public Task<Response<Supplier?>> CreateAsync(CreateSupplierRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Supplier?>> DeleteAsync(DeleteSupplierRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Supplier>>> GetAllAsync(GetAllSupplierRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetFromJsonAsync<PagedResponse<List<Supplier>>>(DesktopConfiguration.ApiUrl + "v1/suppliers");
                }
                catch
                {
                    var result = new PagedResponse<List<Supplier>>(null, 400, "Não foi possivel obter fornecedores");
                    MessageBox.Show(result.Message);
                    return result;
                } 
            }
        }

        public Task<Response<Supplier?>> GetByIdAsync(GetSupplierByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Supplier?>> UpdateAsync(UpdateSupplierRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
