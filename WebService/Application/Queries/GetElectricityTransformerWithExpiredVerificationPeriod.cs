namespace WebService.Application.Queries
{
    public class GetElectricityTransformerWithExpiredVerificationPeriod : IQuery<GetElectricityTransformerWithExpiredVerificationPeriodResponse>
    {
        public long ConsumptionObjectId { get; init; }
    }
}
