namespace Core
{
    internal abstract class CommunalServiceByMeter : CommunalService
    {
        private protected decimal _scopeOfServices;

        public CommunalServiceByMeter(decimal scopeOfService)
        {
            _scopeOfServices = scopeOfService;
        }
        public CommunalServiceByMeter(decimal readingBefore, decimal readingNow)
        {
            _scopeOfServices = readingNow - readingBefore;
        }
        public decimal ScopeOfServices
        {
            get 
            { 
                return _scopeOfServices; 
            }
            set 
            { 
                if (value > 0)
                    _scopeOfServices = value; 
            }
        }

        internal override decimal GetSalary()
        {
            return Rate.Normative * _scopeOfServices;
        }
    }
}
