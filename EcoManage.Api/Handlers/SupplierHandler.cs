using EcoManage.Api.Data;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Enums;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;
using EcoManage.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Document = EcoManage.Domain.ValueObjects.Document;

namespace EcoManage.Api.Handlers;

public class SupplierHandler(AppDbContext context) : ISupplierHandler
{
    public async Task<Response<Supplier?>> CreateAsync(CreateSupplierRequest request)
    {
        #region 01.Criando ValueObjects

        var name = request.CompanyName;
        var document = new Document(request.DocumentNumber, EDocumentType.Cnpj);
        var address = new Address(request.Street, request.Number);
        var zipCode = new ZipCode(request.ZipCode);
        var email = new Email(request.Email);
        var contact = request.Contact;
        var supplier = new Supplier(name, document, address, zipCode, email, contact);

        #endregion

        #region 02.Validations

        if (supplier.Invalid)
            return new Response<Supplier?>(null, 400, "Fornecedor inválido");

        #endregion

        #region 03.Persistindo fornecedor no banco

        try
        {
            await context.Suppliers.AddAsync(supplier);
            await context.SaveChangesAsync();
            return new Response<Supplier?>(supplier, 201, "Fornecedor criado com sucesso");
        }
        catch
        {
            return new Response<Supplier?>(null, 500, "Ocorreu um erro ao cadastrar fornecedor");
        }

        #endregion
    }

    public Task<PagedResponse<List<Supplier>>> GetAllAsync(GetAllSupplierRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Supplier?>> GetByIdAsync(GetSupplierByIdRequest request)
    {
        var supplier = await context.Suppliers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        return supplier is null
            ? new Response<Supplier?>(null, 404, "Fornecedor não encontrado")
            : new Response<Supplier?>(supplier);
    }

    public async Task<Response<Supplier?>> UpdateAsync(UpdateSupplierRequest request)
    {
        var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (supplier is null)
            return new Response<Supplier?>(null, 404, "Fornecedor não encontrado");

        try
        {
            supplier.ChangeCompanyName(request.CompanyName);

            supplier.ChangeEmail(request.Email);

            supplier.ChangeContact(request.Contact);

            if (supplier.Invalid)
                return new Response<Supplier?>(null, 400, "Fornecedor inválido");

            context.Suppliers.Update(supplier);
            await context.SaveChangesAsync();
            return new Response<Supplier?>(supplier, message: "Fornecedor atualizado");
        }
        catch
        {
            return new Response<Supplier?>(null, 500, "Ocorreu um erro ao atualizar o fornecedor");
        }
    }

    public async Task<Response<Supplier?>> DeleteAsync(DeleteSupplierRequest request)
    {
        var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (supplier is null)
            return new Response<Supplier?>(null, 404, "Fornecedor não encontrado");

        try
        {
            context.Suppliers.Remove(supplier);
            await context.SaveChangesAsync();
            return new Response<Supplier?>(supplier, message: "Fornecedor excluído");
        }
        catch
        {
            return new Response<Supplier?>(null, 500, "Ocorreu um erro ao excluir fornecedor");
        }
    }
}