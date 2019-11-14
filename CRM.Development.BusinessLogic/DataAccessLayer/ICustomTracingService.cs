

namespace CRM.Development.Businesslogic.DataAccessLayer
{
    public interface ICustomTracingService
    {
        void Trace(string message, params object[] args);
    }
}
