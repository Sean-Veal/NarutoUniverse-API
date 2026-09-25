using RiskFirst.Hateoas.Models;

namespace Naruto_Universe.Model.Response;

public class NClanItemResponse: LinkContainer
{
    public int Id  { get; set; }
    public string Name { get; set; } = string.Empty;
}