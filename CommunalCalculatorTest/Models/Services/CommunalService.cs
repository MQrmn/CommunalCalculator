namespace Core
{
    internal abstract class CommunalService
    {
        internal CommunalRate Rate { get; set; }
        internal abstract decimal GetSalary();
    }
}
