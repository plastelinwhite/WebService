using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebService.Application.Dto;
using WebService.Application.Queries;

namespace WebService.Application.Handlers
{
    public class GetCountersWithExpiredVerificationPeriodHandler : IRequestHandler<GetCountersWithExpiredVerificationPeriod, GetCountersWithExpiredVerificationPeriodResponse>
    {
        private readonly DatabaseContext _databaseContext;

        public GetCountersWithExpiredVerificationPeriodHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<GetCountersWithExpiredVerificationPeriodResponse> Handle(GetCountersWithExpiredVerificationPeriod request, CancellationToken cancellationToken)
        {
            var expiredMeters = _databaseContext.ElectricityMeasurementPoints
                .AsNoTracking()
                .Where(p => p.ConsumptionObject.Id == request.ConsumptionObjectId)
                .Select(p => p.ElectricityMeter)
                .AsEnumerable()
                .Where(p => (p.VerificationDate + p.VerificationValidityPeriod) <= DateTime.Now)
                .ToList();
            
            return Task.FromResult(new GetCountersWithExpiredVerificationPeriodResponse
            {
                Counters = expiredMeters.Select(p => new ElectricityMeterDto
                {
                    Number = p.Number,
                    Type = p.Type,
                    VerificationDate = p.VerificationDate,
                    VerificationValidityPeriod = p.VerificationValidityPeriod
                }).ToList()
            });
        }
    }
}
