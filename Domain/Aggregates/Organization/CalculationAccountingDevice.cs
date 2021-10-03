using System;
using System.Collections.Generic;

namespace Domain.Aggregates.Organization
{
    public class CalculationAccountingDevice : Entity
    {
        private readonly List<CalculationAccountingToMeasurementMapping> _measurementMappings = new();

        public CalculationAccountingDevice(ElectricitySupplyPoint electricitySupplyPoint)
        {
            ElectricitySupplyPoint = electricitySupplyPoint;
        }

        public virtual ElectricitySupplyPoint ElectricitySupplyPoint {  get; protected set; }

        public virtual IReadOnlyCollection<CalculationAccountingToMeasurementMapping> MeasurementMappings => _measurementMappings;

        public void AddElectricityMeasurementPoint(ElectricityMeasurementPoint measurementPoint, DateTime from, DateTime to)
        {
            var mapping = new  CalculationAccountingToMeasurementMapping(this, measurementPoint, from, to);

            _measurementMappings.Add(mapping);
        }

#pragma warning disable CS8618
        protected CalculationAccountingDevice() { }
#pragma warning restore CS8618 
    }
}
