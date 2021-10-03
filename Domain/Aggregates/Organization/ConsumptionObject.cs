using System.Collections.Generic;

namespace Domain.Aggregates.Organization
{
    public class ConsumptionObject : Entity
    {
        private readonly List<ElectricityMeasurementPoint> _electricityMeasurementPoints;
        private readonly List<ElectricitySupplyPoint> _electricitySupplyPoints;

        public ConsumptionObject(ChildOrganization organization, string name, string address)
        {
            Organization = organization;
            Name = name;
            Address = address;

            _electricityMeasurementPoints = new();
            _electricitySupplyPoints = new();
        }

        public virtual ChildOrganization Organization { get; protected set;  }

        public string Name { get; protected set; }

        public string Address { get; protected set; }

        public virtual IReadOnlyCollection<ElectricityMeasurementPoint> ElectricityMeasurementPoints => _electricityMeasurementPoints;

        public virtual IReadOnlyCollection<ElectricitySupplyPoint> ElectricitySupplyPoints => _electricitySupplyPoints;

        public void AddElectricityMeasurementPoint(ElectricityMeasurementPoint electricityMeasurementPoint) => 
            _electricityMeasurementPoints.Add(electricityMeasurementPoint);

        public void AddElectricitySupplyPoint(ElectricitySupplyPoint electricitySupplyPoint) =>
            _electricitySupplyPoints.Add(electricitySupplyPoint);

#pragma warning disable CS8618 
        protected ConsumptionObject() { }
#pragma warning restore CS8618 
    }
}
