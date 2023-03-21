namespace Core
{
    internal abstract class CommunalServiceByNormative : CommunalService
    {
        private protected int _residentsCount;
        public CommunalServiceByNormative(int residentsCount)
        {
            _residentsCount = residentsCount;
        }
        public int ResidentsCount
        {
            get 
            { 
                return _residentsCount; 
            }
            set 
            { 
                if (value > 0)
                    _residentsCount = value; 
            }
        }

        internal override decimal GetSalary()
        {
            return Rate.Normative * Rate.Rate * _residentsCount;
        }
    }
}
