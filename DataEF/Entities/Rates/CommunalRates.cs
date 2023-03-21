using DataEF.Entities.Rates;
using System.Runtime.CompilerServices;

namespace DataEF.Entities
{
    internal class CommunalRates
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public decimal Normative { get; set; }
        public ServiceType RateType { get; set; }
    }
}
