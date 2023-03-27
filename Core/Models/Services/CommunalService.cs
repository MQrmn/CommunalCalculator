namespace Core
{
    public abstract class CommunalService
    {
        public decimal VolumeOfServices { get; set; }
        public decimal Cost { get; set; }
        public int ServiceType { get; set; }


        internal CommunalRate Rate { get; set; }
        internal abstract decimal Calculate();
    }
}
