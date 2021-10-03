using Domain;
using Domain.Aggregates.Organization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebService.Application.Queries;

namespace WebService.Application.Controllers
{
    [Route(Constants.DefaultApiRoute)]
    [ApiController]
    public class CalculationAccountingDeviceController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CalculationAccountingDeviceController(IMediator mediator) => _mediator = mediator;

        [HttpPost(nameof(GetByDateFilter))]
        public async Task<GetCalculationAccountingDeviceResponse> GetByDateFilter(GetCalculationAccountingDevice query) =>
            await _mediator.Send(query);
    }
}
