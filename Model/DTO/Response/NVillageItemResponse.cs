using RiskFirst.Hateoas.Models;

namespace Naruto_Universe.Model.Response;

public class NVillageItemResponse: LinkContainer
{
    public int  Id { get; set; }
    public string Name { get; set; } = string.Empty;
}