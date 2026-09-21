using System.Text.Json;
using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Service.Misc;

public class DBInitializer: IDBInitializer
{
   private readonly ILogger<DBInitializer>  _logger;
   private readonly string FILE_DIRECTORY = "JsonFiles";
   private readonly IDBSaveService _saveService;

   public DBInitializer(
      ILogger<DBInitializer> logger,
      IDBSaveService saveService
      )
   {
      _logger = logger;
      _saveService = saveService;
   }

   public async Task InitializeDbAsync()
   {
      _logger.LogInformation("Reading files");
      var fileNames = Directory.GetFiles(FILE_DIRECTORY);
      _logger.LogInformation($"Reading files with length: {fileNames.Length}");
      foreach (var fileName in fileNames)
      {
         _logger.LogInformation($"Reading file: {fileName}");
         await using FileStream openStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
         NCharacterFile? characterFile = await JsonSerializer.DeserializeAsync<NCharacterFile>(openStream);
         if (characterFile == null)
         {
            _logger.LogError("Character file failed to serialize");
         }
         else
         {
            _logger.LogInformation($"Success deserializing character file: {characterFile.Name}");
            await _saveService.SaveData(characterFile, characterFile.Jutsus);
         }

      }
   }
}