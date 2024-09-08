using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Entities;

public class ProductionProgrammed : Production
{
    
    public static class Factories
    {
        public static ProductionProgrammed Create(string title,long productId,decimal quantityInKg,DateTime endDate)
        {
            if (endDate < DateTime.UtcNow)
                throw new Exception("A data de término de uma produção agendada não pode estar no futuro");

            return new ProductionProgrammed
            {
                Title = title,
                Status = default,
                HarvestType = EHarvestType.Programmed,
                StartDate = default,
                EndDate = endDate
            };
        }
    }
}