using Booqr.Data.Entities;
using Booqr.Logic.Interfaces;

namespace Booqr.Logic.Services;

public class AuditService : IAuditService
{
    public Task LogAsync(string userName, string path, string httpMethod, DateTime timestampUtc)
    {
        return Task.CompletedTask;
    }
}
