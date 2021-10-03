using System.Collections.Generic;
using WebService.Application.Dto;

namespace WebService.Application.Queries
{
    public class GetVoltageTransformerWithExpiredVerificationPeriodResponse
    {
        public IEnumerable<VoltageTransformerDto> Transformers { get; init; }
    }
}
