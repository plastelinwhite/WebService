using Domain.Aggregates.Organization;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebService.Application.Dto;
using WebService.Application.Queries;

namespace WebService.Application.Handlers
{
    public class GetCalculationAccountingDeviceHandler : IRequestHandler<GetCalculationAccountingDevice, GetCalculationAccountingDeviceResponse>
    {
        private readonly DatabaseContext _databaseContext;

        public GetCalculationAccountingDeviceHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<GetCalculationAccountingDeviceResponse> Handle(GetCalculationAccountingDevice request, CancellationToken cancellationToken)
        {
            var calculationAccountDevices = await _databaseContext
                .CalculationAccountingToMeasurementMappings
                .AsNoTracking()
                .Where(p => p.StartTime >= request.StartSearchPeriod && p.EndTime <= request.EndSearchPeriod)
                .Select(p => p.CalculationAccountingDevice)
                .ToListAsync();

            return new GetCalculationAccountingDeviceResponse
            {
                CalculationAccountingDevices = calculationAccountDevices.Select(p => new CalculationAccountingDeviceDto
                {
                    Id = p.Id
                }).ToList()
            };
        }
    }
}
