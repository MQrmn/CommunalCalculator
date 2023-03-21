namespace Core
{
    internal abstract class CommunalService
    {
        private protected CommunalRate Rate { get; set; }
        internal abstract double GetSalary();
    }
}
