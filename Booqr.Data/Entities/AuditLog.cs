namespace Booqr.Data.Entities;

public class AuditLog
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string HttpMethod { get; set; } = string.Empty;
    public DateTime TimestampUtc { get; set; }
}
