using System;

namespace WebService.Application.Queries
{
    public class GetCalculationAccountingDevice : IQuery<GetCalculationAccountingDeviceResponse>
    {
        public DateTime StartSearchPeriod { get; init; }

        public DateTime EndSearchPeriod {  get; init; }
    }
}
