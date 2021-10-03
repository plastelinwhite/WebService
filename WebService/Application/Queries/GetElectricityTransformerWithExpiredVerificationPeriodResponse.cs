using System.Collections.Generic;
using WebService.Application.Dto;

namespace WebService.Application.Queries
{
    public class GetElectricityTransformerWithExpiredVerificationPeriodResponse
    {
        public IEnumerable<ElectricityTransformerDto> Transformers { get; init; }
    }
}
