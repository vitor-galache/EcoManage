using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Web.Handlers;

public class SupplierHandler : ISupplierHandler
{
    public Task<Response<Supplier?>> CreateAsync(CreateSupplierRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Supplier>>> GetAllAsync(GetAllSupplierRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Supplier?>> GetByIdAsync(GetSupplierByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Supplier?>> UpdateAsync(UpdateSupplierRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Supplier?>> DeleteAsync(DeleteSupplierRequest request)
    {
        throw new NotImplementedException();
    }
}