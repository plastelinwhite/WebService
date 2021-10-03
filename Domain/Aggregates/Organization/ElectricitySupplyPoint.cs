using System.Collections.Generic;

namespace Domain.Aggregates.Organization
{
    public class ElectricitySupplyPoint : Entity
    {
        private readonly List<CalculationAccountingDevice> _calculationAccountingDevices = new();

        public ElectricitySupplyPoint(ConsumptionObject consumptionObject, string name, double maxPower)
        {
            ConsumptionObject = consumptionObject;
            Name = name;
            MaxPower = maxPower;
        }

        public virtual ConsumptionObject ConsumptionObject { get; protected set; }

        public string Name { get; protected set; }

        public double MaxPower { get; protected set;  }

        public virtual IReadOnlyCollection<CalculationAccountingDevice> CalculationAccountingDevices => _calculationAccountingDevices;

        public void AddCalculationAccountingDevice(CalculationAccountingDevice device)
            => _calculationAccountingDevices.Add(device);

#pragma warning disable CS8618
        protected ElectricitySupplyPoint() { }
#pragma warning restore CS8618 
    }
}
