using Domain.Aggregates.Organization;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WebService;

namespace WebServiceClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var provider = CreateServiceProvider();

            var scope = provider.CreateScope();
            var scopedProvider = scope.ServiceProvider;

            var dbContext = scopedProvider.GetRequiredService<DatabaseContext>();

            var organizations = Enumerable.Range(1, 10).Select(p => OrganizationFactory()).ToList();

            dbContext.AddRange(organizations);
            dbContext.SaveChanges();
        }
        private static IServiceProvider CreateServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.InitInfrastructure();

            return serviceCollection.BuildServiceProvider();
        }

        private static Organization OrganizationFactory()
        {
            var org = new Organization(GenerateGuidString(), GenerateGuidString());
            var childOrg = new ChildOrganization(org, GenerateGuidString(), GenerateGuidString());
            org.AddChildOrganization(childOrg);

            var consObj = new ConsumptionObject(childOrg, GenerateGuidString(), GenerateGuidString());
            childOrg.AddConsumptionObject(consObj);

            var measPoint = new ElectricityMeasurementPoint(consObj, GenerateGuidString(), 
                new(GenerateGuidString(), GenerateGuidString(), (DateTime.Now - TimeSpan.FromDays(500)), TimeSpan.FromDays(100)),
                new(GenerateGuidString(),5.23, DateTime.Now - TimeSpan.FromDays(500), TimeSpan.FromDays(100), GenerateGuidString()),
                new(GenerateGuidString(), 5.12, GenerateGuidString(), DateTime.Now - TimeSpan.FromDays(500), TimeSpan.FromDays(100)));

            consObj.AddElectricityMeasurementPoint(measPoint);

            var suplyPoint = new ElectricitySupplyPoint(consObj, GenerateGuidString(), 1000.54);
            consObj.AddElectricitySupplyPoint(suplyPoint);

            var device = new CalculationAccountingDevice(suplyPoint);

            device.AddElectricityMeasurementPoint(measPoint, DateTime.Now - TimeSpan.FromDays(500), DateTime.Now + TimeSpan.FromDays(500));

            return org;
        }

        private static string GenerateGuidString() => Guid.NewGuid().ToString();
    }
}