using System.Security.Claims;
using EcoManage.Api.Common.Api;
using EcoManage.Domain;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Suppliers;

public class GetAllSupplierEndpoint : IEndpoint
{
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Supplier: Get All")
                .WithSummary("Obtem todos fornecedores cadastrados")
                .Produces<PagedResponse<List<Supplier>?>>();
        private static async Task<IResult> HandleAsync(ISupplierHandler handler, ClaimsPrincipal user, int pageSize = Configuration.DefaultPageSize, int pageNumber = Configuration.DefaultPageNumber)
        {
            
            var request = new GetAllSupplierRequest
            {
                
            };
            
            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
}