namespace Booqr.Logic.Interfaces;

public interface IAuditService
{
    Task LogAsync(string userName, string path, string httpMethod, DateTime timestampUtc);
}
