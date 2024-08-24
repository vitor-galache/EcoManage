using EcoManage.Domain.Entities;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Domain.Handlers;

public interface ISupplierHandler
{
    Task<Response<Supplier?>> CreateAsync(CreateSupplierRequest request);
    Task<PagedResponse<List<Supplier>>> GetAllAsync(GetAllSupplierRequest request);
    Task<Response<Supplier?>> GetByIdAsync(GetSupplierByIdRequest request);
    Task<Response<Supplier?>> UpdateAsync(UpdateSupplierRequest request);
    Task<Response<Supplier?>> DeleteAsync(DeleteSupplierRequest request);
}