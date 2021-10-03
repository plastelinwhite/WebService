using System.Collections.Generic;

namespace Domain.Aggregates.Organization
{
    public class ChildOrganization : Entity
    {
        private readonly List<ConsumptionObject> _consumptionObjects;

        public ChildOrganization(Organization parentOrganization, string name, string address)
        {
            ParentOrganization = parentOrganization;
            Name = name;
            Address = address;
            _consumptionObjects = new();
        }

        public virtual Organization ParentOrganization {  get; protected set; }

        public string Name { get; protected set; }

        public string Address { get; protected set; }

        public virtual IReadOnlyCollection<ConsumptionObject> ConsumptionObjects => _consumptionObjects;

        public void AddConsumptionObject(ConsumptionObject consumptionObject)
        {
            _consumptionObjects.Add(consumptionObject);
        }

#pragma warning disable CS8618
        protected ChildOrganization() { }
#pragma warning restore CS8618 
    }
}
