using System.Collections.Generic;
using WebService.Application.Dto;

namespace WebService.Application.Queries
{
    public class GetCalculationAccountingDeviceResponse
    {
        public IReadOnlyCollection<CalculationAccountingDeviceDto> CalculationAccountingDevices { get; init; }
    }
}
