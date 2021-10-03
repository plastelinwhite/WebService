using System;

namespace WebService.Application.Dto
{
    public class VoltageTransformerDto
    {
        public string Number { get; init; }

        public double TransformCoefficient { get; init; }

        public DateTime VerificationDate { get; init; }

        public TimeSpan VerificationValidityPeriod { get; init; }

        public string TransformerType { get; init; }
    }
}