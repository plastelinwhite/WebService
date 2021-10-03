using System;

namespace Domain.Aggregates.Organization
{
    public class CalculationAccountingToMeasurementMapping : Entity
    {
        public CalculationAccountingToMeasurementMapping(CalculationAccountingDevice calculationAccountingDevice, ElectricityMeasurementPoint electricityMeasurementPoint, DateTime startTime, DateTime endTime)
        {
            CalculationAccountingDevice = calculationAccountingDevice;
            ElectricityMeasurementPoint = electricityMeasurementPoint;
            StartTime = startTime;
            EndTime = endTime;
        }

        public virtual CalculationAccountingDevice CalculationAccountingDevice { get; protected set; }

        public virtual ElectricityMeasurementPoint ElectricityMeasurementPoint {  get; protected set; }

        public DateTime StartTime {  get; protected set; }

        public DateTime EndTime {  get; protected set; }

#pragma warning disable CS8618
        protected CalculationAccountingToMeasurementMapping() { }
#pragma warning restore CS8618 
    }
}
