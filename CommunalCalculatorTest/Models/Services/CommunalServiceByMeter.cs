namespace Core
{
    internal abstract class CommunalServiceByMeter : CommunalService
    {
        private protected decimal _serviceVolume;

        public CommunalServiceByMeter(decimal serviceVolume)
        {
            _serviceVolume = serviceVolume;
        }
        public CommunalServiceByMeter(decimal previousValue, decimal currentValue)
        {
            _serviceVolume = currentValue - previousValue;
        }

        public decimal ServiceVolume
        {
            get 
            { 
                return _serviceVolume; 
            }
            set 
            { 
                if (value > 0)
                    _serviceVolume = value; 
            }
        }

        internal override decimal GetSalary()
        {
            return Rate.Cost * _serviceVolume;
        }
    }
}
