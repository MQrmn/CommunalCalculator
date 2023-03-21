namespace Core
{
    internal class House
    {
        internal CommunalService ColdWater { get; set; }
        internal CommunalService HotWater { get; set; }
        internal CommunalService ElectroEnergy { get; set; }
        private int _residentsCount { get; set; }
        internal int ResidentsCount {
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
    }
}
