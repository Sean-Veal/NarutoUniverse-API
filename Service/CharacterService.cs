using Naruto_Universe.Mapper;
using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.Response;
using Naruto_Universe.Repository;
using Naruto_Universe.Util;
using RiskFirst.Hateoas;
using ApplicationException = Naruto_Universe.Exceptions.ApplicationException;

namespace Naruto_Universe.Service;

public class CharacterService( 
    ILogger<CharacterService> logger,
    ICharacterRepository repo,
    ILinksService linksService
    ): ICharacterService
{ 
    public async Task<NCharacterResponse> GetByIdAsync(int id)
    {
        logger.LogInformation("Getting character with id {id}", id);
        var result = await repo.GetByIdAsync(id);
        if (result.IsSuccess)
        {
            var response = result.Value.ToNCharacterResponse();
            await linksService.AddLinksAsync(response.Village);
            await linksService.AddLinksAsync(response.KekkeiGenkai);
            var jutsuTasks = response.Jutsu.Select(async j =>
            {
                await linksService.AddLinksAsync(j);
                return j;
            });
            var chakraNatureTasks = response.ChakraNatures.Select(async c =>
            {
                await linksService.AddLinksAsync(c);
                return c;
            });
            await linksService.AddLinksAsync(response.Clan);
            var mediaTask = response.Debut.Select(async d =>
            {
                await linksService.AddLinksAsync(d);
                return d;
            });
            var jutsuList = await Task.WhenAll(jutsuTasks);
            var chakraNaturesList = await Task.WhenAll(chakraNatureTasks);
            var mediaList = await Task.WhenAll(mediaTask);
            response.Jutsu = jutsuList.ToList();
            response.ChakraNatures = chakraNaturesList.ToList();
            response.Debut = mediaList.ToList();
            return response;
        }
        throw new ApplicationException(result.Error);
    }
}