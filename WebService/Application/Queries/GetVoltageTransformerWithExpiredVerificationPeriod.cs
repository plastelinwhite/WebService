namespace WebService.Application.Queries
{
    public class GetVoltageTransformerWithExpiredVerificationPeriod : IQuery<GetVoltageTransformerWithExpiredVerificationPeriodResponse>
    {
        public long ConsumptionObjectId { get; init; }
    }
}
