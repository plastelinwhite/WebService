using System;

namespace WebService.Application.Dto
{
    public class ElectricityMeterDto
    {
        public string Number { get; init; }

        public string Type { get; init; }

        public DateTime VerificationDate { get; init; }

        public TimeSpan VerificationValidityPeriod { get; init; }
    }
}