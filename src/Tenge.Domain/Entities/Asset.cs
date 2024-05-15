using Tenge.Domain.Commons;

namespace Tenge.Domain.Entities;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
}
