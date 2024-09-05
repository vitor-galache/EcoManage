using EcoManage.Api.Data;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace EcoManage.Api.Handlers;

public class ProductHandler(AppDbContext context) : IProductHandler
{
    public async Task<Response<Product?>> CreateAsync(CreateProductRequest request)
    {
        try
        {
            var product = new Product(request.Title,request.Description);
            
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return new Response<Product?>(product, 201, "Produto cadastrado com sucesso!");
        }
        catch
        {
            return new Response<Product?>(null, 500, "Não foi possível cadastrar o produto");
        }
    }

    public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
    {
        try
        {
            var product = await context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Slug == request.Slug);
            return product is null 
                ? new Response<Product?>(null, 404, "Produto não encontrado") 
                : new Response<Product?>(product);
        }
        catch
        {
            return new Response<Product?>(null, 500, "Não foi possível obter o produto");
        }
    }

    public async Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request)
    {
        try
        {
            var query = context.Products.AsNoTracking()
                .Where(x=>x.IsActive)
                .OrderBy(x => x.Title);

            var products = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            var count = await query.CountAsync();
            return new PagedResponse<List<Product>?>(products, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Product>?>(null, 500, "Não foi possível obter os produtos");
        }
    }

    public async Task<Response<Product?>> UpdateAsync(UpdateProductRequest request)
    {
        Product? product;
        try
        {
            product = await context.Products.FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (product is null)
                return new Response<Product?>(null, 404, "Produto não encontrado");
            
            product.ChangeInfo(request.Title,request.Description);

            context.Products.Update(product);
            await context.SaveChangesAsync();
            return new Response<Product?>(product, 200, "As informações do produto foram atualizadas com sucesso");
        }
        catch
        {
            return new Response<Product?>(null, 500, "Erro ao atualizar informações do produto");
        }
    }

    public async Task<Response<Product?>> InactiveAsync(InactivateProductRequest request)
    {
        Product? product;
        try
        {
            
            product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if (product is null)
                return new Response<Product?>(null, 404, "Produto não encontrado");
            
            product.Inactivate();
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return new Response<Product?>(product, 200, "Produto inativado com sucesso!");
        }
        catch
        {
            return new Response<Product?>(null, 500, "Erro ao inativar produto");
        }
    }
}