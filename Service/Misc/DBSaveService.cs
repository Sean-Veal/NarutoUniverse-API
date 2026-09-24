using Microsoft.EntityFrameworkCore;
using Naruto_Universe.Data;
using Naruto_Universe.Mapper;
using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Service.Misc;

public class DBSaveService: IDBSaveService
{
    
    private readonly ILogger<DBSaveService> _logger;
    private readonly AppDbContext _dbContext;

    public DBSaveService(
        ILogger<DBSaveService> logger,
        AppDbContext dbContext
    )
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task SaveData(NCharacterFile characterFile, List<NJutsuFile> jutsuFiles)
    {
        _logger.LogInformation($"Starting save service for {characterFile.Name}");
        var characterExists = await _dbContext.NCharacters.AnyAsync(c => c.Name.ToLower() == characterFile.Name.ToLower());
        if (characterExists)
        {
            _logger.LogInformation("Character already exists");
            return;
        }

        var country = await BuildCountry(characterFile.NVillageFile?.NCountryFile);
        var village = await BuildVillage(characterFile.NVillageFile, country);
        var characterMediaList = await BuildDebutList(characterFile.Debuts);
        var chakraNaturesList = await BuildChakraNaturesList(characterFile.ChakraNatures);
        var character = characterFile.ToNCharacter(village, chakraNaturesList);
        character.MediaList = characterMediaList;
        foreach (var jutsuFile in jutsuFiles)
        {
            var jutsuMediaList = await BuildDebutList(jutsuFile.Debuts);
            var jutsu = jutsuFile.ToNJutsu();
            var classifications = await BuildClassifications(jutsuFile.Classifications);
            jutsu.JutsuClassifications  = classifications;
            jutsu.MediaList = jutsuMediaList;
            // Find Existing Jutsu
            if (await _dbContext.NJutsus.AnyAsync(j => j.Name.ToLower() == jutsu.Name.ToLower()))
            {
                _logger.LogInformation($"Jutsu {jutsu.Name} already exists");
                var existingJutsu = await _dbContext.NJutsus.FirstOrDefaultAsync( j => string.Equals(j.Name.ToLower(), jutsu.Name.ToLower()));
                character.Jutsus.Add(existingJutsu!);
            }
            else
            {
                // add to character
                _logger.LogInformation($"Adding {jutsu.Name} to DB");
                var createdJutsu  = await _dbContext.NJutsus.AddAsync(jutsu);
                character.Jutsus.Add(createdJutsu.Entity);
            }
        }
        _logger.LogInformation($"Saving Character {character.Name} to DB");
        await _dbContext.NCharacters.AddAsync(character);
        _logger.LogInformation("Saving all changes");
        await _dbContext.SaveChangesAsync();
    }

    private async Task<List<NChakraNature>> BuildChakraNaturesList(List<NChakraNatureFile> chakraNatureFiles)
    {
        var chakraNatures = new List<NChakraNature>();
        _logger.LogInformation("Building Chakra Nature List");
        foreach (var chakraNature in chakraNatureFiles)
        {
            var existingChakraNature =
                await _dbContext.NChakraNatures.FirstOrDefaultAsync(c =>
                    c.Name.ToLower().Equals(chakraNature.Name.ToLower()));
            if (existingChakraNature is not null)
            {
                chakraNatures.Add(existingChakraNature);
            }
            else
            {
                _logger.LogInformation($"Adding {chakraNature.Name} to DB");
                var createdChakraNature = chakraNature.ToNChakraNature();
                await _dbContext.NChakraNatures.AddAsync(createdChakraNature);
                await  _dbContext.SaveChangesAsync();
                chakraNatures.Add(createdChakraNature);
            }
        }

        return chakraNatures;
    }

    private async Task<NVillage> BuildVillage(NVillageFile? nvillageFile, NCountry country)
    {
        if (nvillageFile is null) throw new Exception("NVillageFile is null");
        var existingVillage = await _dbContext.NVillages
            .FirstOrDefaultAsync(v  => v.Name.ToLower().Equals(nvillageFile.Name.ToLower()));
        if (existingVillage is not null)
        {
            _logger.LogInformation($"Village already exists: {nvillageFile.Name}");
            return existingVillage;
        }

        var village = nvillageFile.ToNVillage(country);
        await _dbContext.NVillages.AddAsync(village);
        await _dbContext.SaveChangesAsync();
        return village;
    }

    private async Task<NCountry> BuildCountry(NCountryFile? countryFile)
    {
        if (countryFile is null) throw new Exception("CountryFile is null");
        var existingCountry = await _dbContext.NCountries
            .FirstOrDefaultAsync(c => c.Name.ToLower().Equals(countryFile.Name.ToLower()));
        if (existingCountry is not null)
        {
            _logger.LogInformation($"Country already exists: {countryFile.Name}");
            return existingCountry;
        }

        var country = new NCountry
        {
            Name = countryFile.Name,
            Description = countryFile.Description
        };
        await _dbContext.NCountries.AddAsync(country);
        await _dbContext.SaveChangesAsync();
        return country;
    }

    private async Task<List<NMedia>> BuildDebutList(List<NDebutFile> debutFiles)
    {
        _logger.LogInformation("Building Media List");
        List<NMedia> mediaList = [];

        foreach (var debut in debutFiles)
        {
            var arc = debut.NArcFile.ToNArc();
            var existingArc =
                await _dbContext.NArcs.FirstOrDefaultAsync(a =>
                    string.Equals(a.Name.ToLower(), arc.Name.ToLower()));
            if (existingArc is not null)
            {
                _logger.LogInformation($"Arc already exists: {arc.Name}");
                arc = existingArc;
            }
            else
            {
                _logger.LogInformation($"Saving Arc: {arc.Name}");
                await _dbContext.NArcs.AddAsync(arc);
                await _dbContext.SaveChangesAsync();
            }
            
            mediaList.Add(await SaveMediaItem(arc, debut));
        }
        await _dbContext.SaveChangesAsync();
        return mediaList;
    }

    private async Task<NMedia> SaveMediaItem(NArc arc, NDebutFile? debutFile)
    {
        if (debutFile is null) throw new Exception("DebutFile is null");
        var media = debutFile.ToNMedia(arc);
        var existingMedia = await _dbContext.NMediae.FirstOrDefaultAsync(m => m.MediaType == media.MediaType && m.EntryIndex == media.EntryIndex);
        if (existingMedia is not null)
        {
            _logger.LogInformation($"Media already exists: {media.Name}");
            return existingMedia;
        }
        _logger.LogInformation($"Saving Media: {media.Name}");
        await _dbContext.NMediae.AddAsync(media);
        return media;
    }

    private async Task<List<NJutsuClassification>> BuildClassifications(List<NJutsuClassFile> classifications)
    {
        List<NJutsuClassification> classificationList = [];
        
        var jutsuClassifications = classifications.Select(c => new NJutsuClassification
        {
            Name = c.Name,
            Description = c.Description
        }).ToList();

        foreach (var classification in jutsuClassifications)
        {
            var existingItem = await _dbContext.NJutsuClassifications
                .FirstOrDefaultAsync(c => c.Name.ToLower().Equals(classification.Name.ToLower()));
            if (existingItem == null)
            {
                await _dbContext.NJutsuClassifications.AddAsync(classification);
                await  _dbContext.SaveChangesAsync();
                classificationList.Add(classification);
            }
            else
            {
                classificationList.Add(existingItem);
            }
        }
        
        return classificationList;
    }
}