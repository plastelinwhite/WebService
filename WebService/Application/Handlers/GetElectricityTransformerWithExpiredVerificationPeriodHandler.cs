using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebService.Application.Dto;
using WebService.Application.Queries;

namespace WebService.Application.Handlers
{
    public class GetElectricityTransformerWithExpiredVerificationPeriodHandler : 
        IRequestHandler<GetElectricityTransformerWithExpiredVerificationPeriod, 
            GetElectricityTransformerWithExpiredVerificationPeriodResponse>
    {
        private readonly DatabaseContext _databaseContext;

        public GetElectricityTransformerWithExpiredVerificationPeriodHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<GetElectricityTransformerWithExpiredVerificationPeriodResponse> Handle(GetElectricityTransformerWithExpiredVerificationPeriod request, CancellationToken cancellationToken)
        {
            var expiredTransformers = _databaseContext.ElectricityMeasurementPoints
                .AsNoTracking()
                .Where(p => p.ConsumptionObject.Id == request.ConsumptionObjectId)
                .Select(p => p.ElectricityTransformer)
                .AsEnumerable()
                .Where(p => (p.VerificationDate + p.VerificationValidityPeriod) <= DateTime.Now)
                .ToList();

            return Task.FromResult(new GetElectricityTransformerWithExpiredVerificationPeriodResponse
            {
                Transformers = expiredTransformers.Select(p => new ElectricityTransformerDto
                {
                    Number = p.Number,
                    VerificationDate = p.VerificationDate,
                    VerificationValidityPeriod = p.VerificationValidityPeriod,
                    TranformerType = p.TranformerType,
                    TransformCoefficient = p.TransformCoefficient
                }).ToList()
            });
        }
    }
}
