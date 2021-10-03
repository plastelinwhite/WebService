using System;
using System.Collections.Generic;

namespace Domain.Aggregates.Organization
{
    public class ElectricityMeasurementPoint : Entity
    {
        private List<CalculationAccountingToMeasurementMapping> _calculationAccountingDevicesMapping = new();

        public ElectricityMeasurementPoint(ConsumptionObject consumptionObject, string name, ElectricityMeter electricityMeter, 
            VoltageTransformer voltageTransformer, ElectricityTransformer electricityTransformer)
        {
            ConsumptionObject = consumptionObject;
            Name = name;
            ElectricityMeter = electricityMeter;
            VoltageTransformer = voltageTransformer;
            ElectricityTransformer = electricityTransformer;
        }

        public virtual ConsumptionObject ConsumptionObject { get; protected set; }

        public string Name { get; protected set; }

        public ElectricityMeter ElectricityMeter { get; protected set; }

        public VoltageTransformer VoltageTransformer { get; protected set; }

        public ElectricityTransformer ElectricityTransformer { get; protected set; }

        public virtual IReadOnlyCollection<CalculationAccountingToMeasurementMapping> CalculationAccountingDevicesMapping => _calculationAccountingDevicesMapping;

        public void AddCalculationAccountingDevice(CalculationAccountingDevice device, DateTime from, DateTime to)
        {
            var mapping = new CalculationAccountingToMeasurementMapping(device, this, from, to);

            _calculationAccountingDevicesMapping.Add(mapping);
        }

#pragma warning disable CS8618
        protected ElectricityMeasurementPoint() { }
#pragma warning restore CS8618 
    }
}
