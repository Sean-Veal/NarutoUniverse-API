namespace Naruto_Universe.Service;

public class ImageService(ILogger<ImageService> logger): IImageService
{
    private const string BaseUrl =
        "https://raw.githubusercontent.com/Sean-Veal/NarutoUniverse-API/main/Images/Characters/";
    public string GetImageForCharacter(string name)
    {
        var lowerName = name.ToLowerInvariant();
        var firstName = lowerName.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
        return $"{BaseUrl}{firstName}";
    }
}