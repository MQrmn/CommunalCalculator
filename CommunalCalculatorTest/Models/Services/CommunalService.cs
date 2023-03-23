namespace Core
{
    internal abstract class CommunalService
    {
        internal CommunalRate Rate { get; set; }
        internal Enums.ServiceTypes Type { get; set; }
        internal abstract decimal GetSalary();
    }
}
