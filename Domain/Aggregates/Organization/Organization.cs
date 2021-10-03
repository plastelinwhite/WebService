using System.Collections.Generic;

namespace Domain.Aggregates.Organization
{
    public class Organization : Entity
    {
        private readonly List<ChildOrganization> _childOrganizations;

        public Organization(string name, string address)
        {
            Name = name;
            Address = address;

            _childOrganizations = new();
        }

        public string Name { get; protected set; }

        public string Address { get; protected set; }

        public virtual IReadOnlyCollection<ChildOrganization> ChildOrganizations => _childOrganizations;

        public void AddChildOrganization(ChildOrganization childOrganization)
        {
            _childOrganizations.Add(childOrganization);
        }

#pragma warning disable CS8618
        protected Organization() { }
#pragma warning restore CS8618 
    }
}
