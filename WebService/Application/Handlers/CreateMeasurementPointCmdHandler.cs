using Domain.Aggregates.Organization;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebService.Application.Commands;

namespace WebService.Application.Handlers
{
    public class CreateMeasurementPointCmdHandler : IRequestHandler<CreateMeasurementPointCmd>
    {
        private readonly DatabaseContext _databaseContext;

        public CreateMeasurementPointCmdHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Unit> Handle(CreateMeasurementPointCmd request, CancellationToken cancellationToken)
        {
            var consObject = await _databaseContext.ConsumptionObjects
                .Where(p => p.Id == request.ConsumptionObjectId)
                .Include(p => p.ElectricityMeasurementPoints)
                .FirstOrDefaultAsync();

            if (consObject is null)
                throw new KeyNotFoundException($"Consumption Object with id {request.ConsumptionObjectId} not exist");

            var electricityTransformer = new ElectricityTransformer(request.ElectricityTransformer.Number,
                request.ElectricityTransformer.TransformCoefficient, 
                request.ElectricityTransformer.TranformerType,
                request.ElectricityTransformer.VerificationDate,
                request.ElectricityTransformer.VerificationValidityPeriod);

            var voltageTransformer = new VoltageTransformer(request.VoltageTransformer.Number,
                request.VoltageTransformer.TransformCoefficient,
                request.VoltageTransformer.VerificationDate,
                request.VoltageTransformer.VerificationValidityPeriod,
                request.VoltageTransformer.TransformerType);

            var electricityMeter = new ElectricityMeter(request.ElectricityMeter.Number,
                request.ElectricityMeter.Type,
                request.ElectricityMeter.VerificationDate,
                request.ElectricityMeter.VerificationValidityPeriod);

            var measurementPoint = new ElectricityMeasurementPoint(consObject, request.MeasurementPointName,
                electricityMeter, voltageTransformer, electricityTransformer);

            consObject.AddElectricityMeasurementPoint(measurementPoint);

            _databaseContext.Update(consObject);
            await _databaseContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
