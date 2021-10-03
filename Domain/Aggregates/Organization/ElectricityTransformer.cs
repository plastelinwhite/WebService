using System;

namespace Domain.Aggregates.Organization
{
    public class ElectricityTransformer
    {
        public ElectricityTransformer(string number, double transformCoefficient, string tranformerType, DateTime verificationDate, TimeSpan verificationValidityPeriod)
        {
            Number = number;
            TransformCoefficient = transformCoefficient;
            TranformerType = tranformerType;
            VerificationDate = verificationDate;
            VerificationValidityPeriod = verificationValidityPeriod;
        }

        public string Number { get; protected set; }

        public double TransformCoefficient { get; protected set; }

        public string TranformerType { get; protected set; }

        public DateTime VerificationDate { get; protected set; }

        public TimeSpan VerificationValidityPeriod { get; protected set; }

#pragma warning disable CS8618
        protected ElectricityTransformer() { }
#pragma warning restore CS8618 
    }
}
