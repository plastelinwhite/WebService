using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Application.Dto;
using WebService.Application.Queries;
using WebServiceClient.App;

namespace WebServiceClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");

            var webServiceClient = RestService.For<IWebServiceClient>(client, new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            });

            RunTests(webServiceClient).Wait();
        }

        private static async Task RunTests(IWebServiceClient webServiceClient)
        {
            Console.WriteLine("Start tests");
            Console.WriteLine("Run test CreateMeasurementPoint");

            await TestCreateMeasurementPoint(webServiceClient);

            Console.WriteLine("Test CreateMeasurementPoint Sucess");
            WaitNextTest();


            Console.WriteLine("Run test GetCountersWithExpiredVerificationPeriod");

            var getCountersWithExpiredVerificationPeriodResult = await TestGetCountersWithExpiredVerificationPeriod(webServiceClient);

            Console.WriteLine("Test GetCountersWithExpiredVerificationPeriod Sucess");
            Console.WriteLine($"Test result:\n{JsonConvert.SerializeObject(getCountersWithExpiredVerificationPeriodResult)}");
            WaitNextTest();


            Console.WriteLine("Run test GetElectricityTransformerWithExpiredVerificationPeriod");

            var getElectricityTransformerWithExpiredVerificationPeriodResult = await TestGetElectricityTransformerWithExpiredVerificationPeriod(webServiceClient);

            Console.WriteLine("Test GetElectricityTransformerWithExpiredVerificationPeriod Sucess");
            Console.WriteLine($"Test result:\n{JsonConvert.SerializeObject(getElectricityTransformerWithExpiredVerificationPeriodResult)}");
            WaitNextTest();


            Console.WriteLine("Run test GetVoltageTransformerWithExpiredVerificationPeriod");

            var getVoltageTransformerWithExpiredVerificationPeriodResult = await TestGetVoltageTransformerWithExpiredVerificationPeriod(webServiceClient);

            Console.WriteLine("Test GetVoltageTransformerWithExpiredVerificationPeriod Sucess");
            Console.WriteLine($"Test result:\n{JsonConvert.SerializeObject(getVoltageTransformerWithExpiredVerificationPeriodResult)}");
            WaitNextTest();


            Console.WriteLine("Run test GetCalculationAccountingDevicesByFilter");

            var getCalculationAccountingDevicesByFilterResult = await TestGetCalculationAccountingDevicesByFilter(webServiceClient);

            Console.WriteLine("Test GetCalculationAccountingDevicesByFilter Sucess");
            Console.WriteLine($"Test result:\n{JsonConvert.SerializeObject(getCalculationAccountingDevicesByFilterResult)}");
        }

        private static string GenerateGuidString() => Guid.NewGuid().ToString();

        private static void WaitNextTest()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private static async Task TestCreateMeasurementPoint(IWebServiceClient webServiceClient) => await webServiceClient.CreateMeasurementPoint(new()
        {
            ConsumptionObjectId = 1,
            MeasurementPointName = GenerateGuidString(),
            ElectricityMeter = new ElectricityMeterDto
            {
                Number = GenerateGuidString(),
                VerificationDate = DateTime.Now,
                Type = GenerateGuidString(),
                VerificationValidityPeriod = TimeSpan.FromDays(365)
            },
            ElectricityTransformer = new ElectricityTransformerDto
            {
                Number = GenerateGuidString(),
                TranformerType = GenerateGuidString(),
                VerificationDate = DateTime.Now,
                VerificationValidityPeriod = TimeSpan.FromDays(365),
                TransformCoefficient = 5.25
            },
            VoltageTransformer = new VoltageTransformerDto
            {
                Number = GenerateGuidString(),
                TransformCoefficient = 5.25,
                TransformerType = GenerateGuidString(),
                VerificationDate = DateTime.Now,
                VerificationValidityPeriod = TimeSpan.FromDays(365)
            }
        });

        private static async Task<GetCountersWithExpiredVerificationPeriodResponse> TestGetCountersWithExpiredVerificationPeriod
            (IWebServiceClient webServiceClient) => await webServiceClient.GetCountersWithExpiredVerificationPeriod(new()
            {
                ConsumptionObjectId = 1
            });

        private static async Task<GetElectricityTransformerWithExpiredVerificationPeriodResponse> TestGetElectricityTransformerWithExpiredVerificationPeriod
            (IWebServiceClient webServiceClient) => await webServiceClient.GetElectricityTransformerWithExpiredVerificationPeriod(new() 
            { 
                ConsumptionObjectId = 1 
            });

        private static async Task<GetVoltageTransformerWithExpiredVerificationPeriodResponse> TestGetVoltageTransformerWithExpiredVerificationPeriod
            (IWebServiceClient webServiceClient) => await webServiceClient.GetVoltageTransformerWithExpiredVerificationPeriod(new()
            {
                ConsumptionObjectId = 1
            });

        private static async Task<GetCalculationAccountingDeviceResponse> TestGetCalculationAccountingDevicesByFilter(IWebServiceClient webServiceClient) =>
            await webServiceClient.GetByFilter(new()
            {
                StartSearchPeriod = DateTime.Parse("1/01/2019 0:0:0"),
                EndSearchPeriod = DateTime.Parse("1/01/2020 0:0:0")
            });
    }
}
