using System;

namespace Domain.Aggregates.Organization
{
    public class ElectricityMeter
    {
        public ElectricityMeter(string number, string type, DateTime verificationDate, TimeSpan verificationValidityPeriod)
        {
            Number = number;
            Type = type;
            VerificationDate = verificationDate;
            VerificationValidityPeriod = verificationValidityPeriod;
        }

        public string Number { get; protected set; }

        public string Type { get; protected set; }

        public DateTime VerificationDate { get; protected set; }

        public TimeSpan VerificationValidityPeriod { get; protected set;  }

#pragma warning disable CS8618
        protected ElectricityMeter() { }
#pragma warning restore CS8618 
    }
}
