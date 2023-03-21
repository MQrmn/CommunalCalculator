namespace Core
{
    internal abstract class CommunalServiceByMeter : CommunalService
    {
        private protected int _scopeOfServices;

        public CommunalServiceByMeter(int scopeOfService)
        {
            _scopeOfServices = scopeOfService;
        }
        public CommunalServiceByMeter(int readingBefore, int readingNow)
        {
            _scopeOfServices = readingNow - readingBefore;
        }
        public int ScopeOfServices
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
    }
}
