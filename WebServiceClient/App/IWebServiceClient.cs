using Refit;
using WebService.Application.Commands;
using WebService.Application.Queries;

namespace WebServiceClient.App
{
    public interface IWebServiceClient
    {
        [Post("/api/ConsumptionObject/CreateMeasurementPoint")]
        Task CreateMeasurementPoint(CreateMeasurementPointCmd createMeasurementPointCmd);

        [Post("/api/ConsumptionObject/GetCountersWithExpiredVerificationPeriod")]
        Task<GetCountersWithExpiredVerificationPeriodResponse> GetCountersWithExpiredVerificationPeriod(
            GetCountersWithExpiredVerificationPeriod cmd);

        [Post("/api/ConsumptionObject/GetElectricityTransformerWithExpiredVerificationPeriod")]
        Task<GetElectricityTransformerWithExpiredVerificationPeriodResponse> GetElectricityTransformerWithExpiredVerificationPeriod(
            GetElectricityTransformerWithExpiredVerificationPeriod cmd);

        [Post("/api/ConsumptionObject/GetVoltageTransformerWithExpiredVerificationPeriod")]
        Task<GetVoltageTransformerWithExpiredVerificationPeriodResponse> GetVoltageTransformerWithExpiredVerificationPeriod(
            GetVoltageTransformerWithExpiredVerificationPeriod cmd);

        [Post("/api/CalculationAccountingDevice/GetByDateFilter")]
        Task<GetCalculationAccountingDeviceResponse> GetByFilter(
            GetCalculationAccountingDevice query);
    }
}
