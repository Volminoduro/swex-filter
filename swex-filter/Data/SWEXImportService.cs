using SwexFilter.Models;

namespace SwexFilter.Data;
public class SWEXImportService(DataContext dataContext)
{
    public void ImportRunes(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var importedRunes = System.Text.Json.JsonSerializer.Deserialize<List<SWEXRune>>(jsonData);

        if (importedRunes is not null)
        {
            dataContext.ImportRunes(importedRunes);
        }
    }
}
