using EcoManage.Domain.Entities;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;

namespace EcoManage.Domain.Handlers;

public interface IProductHandler
{
    Task<Response<Product?>> CreateAsync(CreateProductRequest request);
    Task<Response<Product?>> GetByIdAsync(GetProductByIdRequest request);
    Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request);
    Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request);
    Task<Response<Product?>> UpdateAsync(UpdateProductRequest request);
    Task<Response<Product?>> InactiveAsync(InactivateProductRequest request);
}