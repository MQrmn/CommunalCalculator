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

        internal override decimal Calculate()
        {
            this.VolumeOfServices = Rate.Normative * _residentsCount;
            this.Cost = Rate.Cost * this.VolumeOfServices;
            return this.Cost;
        }
    }
}
