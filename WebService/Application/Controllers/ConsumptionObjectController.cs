using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebService.Application.Commands;
using WebService.Application.Queries;

namespace WebService.Application.Controllers
{
    [Route(Constants.DefaultApiRoute)]
    [ApiController]
    public class ConsumptionObjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsumptionObjectController(IMediator mediator) => _mediator = mediator;

        [HttpPost(nameof(CreateMeasurementPoint))]
        public async Task CreateMeasurementPoint(CreateMeasurementPointCmd createMeasurementPointCmd) =>
            await _mediator.Send(createMeasurementPointCmd);

        [HttpPost(nameof(GetCountersWithExpiredVerificationPeriod))]
        public async Task<GetCountersWithExpiredVerificationPeriodResponse> GetCountersWithExpiredVerificationPeriod(GetCountersWithExpiredVerificationPeriod cmd)
            => await _mediator.Send(cmd);

        [HttpPost(nameof(GetElectricityTransformerWithExpiredVerificationPeriod))]
        public async Task<GetElectricityTransformerWithExpiredVerificationPeriodResponse> GetElectricityTransformerWithExpiredVerificationPeriod(
            GetElectricityTransformerWithExpiredVerificationPeriod cmd) => 
            await _mediator.Send(cmd);

        [HttpPost(nameof(GetVoltageTransformerWithExpiredVerificationPeriod))]
        public async Task<GetVoltageTransformerWithExpiredVerificationPeriodResponse> GetVoltageTransformerWithExpiredVerificationPeriod(
            GetVoltageTransformerWithExpiredVerificationPeriod cmd) =>
            await _mediator.Send(cmd); 


    }
}
