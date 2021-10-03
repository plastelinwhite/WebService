using System;

namespace WebService.Application.Dto
{
    public class ElectricityTransformerDto
    {
        public string Number { get; init; }

        public double TransformCoefficient { get; init; }

        public string TranformerType { get; init; }

        public DateTime VerificationDate { get; init; }

        public TimeSpan VerificationValidityPeriod { get; init; }
    }
}