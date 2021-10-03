namespace WebService.Application.Queries
{
    public class GetCountersWithExpiredVerificationPeriod : IQuery<GetCountersWithExpiredVerificationPeriodResponse>
    {
        public long ConsumptionObjectId { get; init; }
    }
}
