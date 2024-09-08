using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Entities;

public class ProductionUnexpected : Production
{
    public static class Factories
    {
        public static ProductionUnexpected Create(string title,long productId,decimal quantityInKg)
        {
            return new ProductionUnexpected
            {
                Title = title,
                Status = default,
                HarvestType = EHarvestType.Unexpected,
                StartDate = default,
                EndDate = null
            };
        }
    }
}