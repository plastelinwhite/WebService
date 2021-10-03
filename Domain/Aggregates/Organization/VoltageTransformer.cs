using System;

namespace Domain.Aggregates.Organization
{
    public class VoltageTransformer
    {
        public VoltageTransformer(string number, double transformCoefficient, DateTime verificationDate, TimeSpan verificationValidityPeriod, string transformerType)
        {
            Number = number;
            TransformCoefficient = transformCoefficient;
            VerificationDate = verificationDate;
            VerificationValidityPeriod = verificationValidityPeriod;
            TransformerType = transformerType;
        }

        public string Number { get; protected set; }

        public double TransformCoefficient { get; protected set; }

        public DateTime VerificationDate { get; protected set; }

        public TimeSpan VerificationValidityPeriod { get; protected set; }

        public string TransformerType { get; protected set; }


#pragma warning disable CS8618
        protected VoltageTransformer() { }
#pragma warning restore CS8618 
    }
}
