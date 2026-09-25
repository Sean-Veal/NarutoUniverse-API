using RiskFirst.Hateoas.Models;

namespace Naruto_Universe.Model.Response;

public class NMediaItemResponse: LinkContainer
{
    public int Id  { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}