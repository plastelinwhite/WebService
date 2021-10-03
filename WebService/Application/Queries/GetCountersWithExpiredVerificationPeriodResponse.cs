using System.Collections.Generic;
using WebService.Application.Dto;

namespace WebService.Application.Queries
{
    public class GetCountersWithExpiredVerificationPeriodResponse
    {
        public IReadOnlyCollection<ElectricityMeterDto> Counters { get; init; }
    }
}
