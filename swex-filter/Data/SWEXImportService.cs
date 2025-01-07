using System.Text.Json;
using SwexFilter.Models;

namespace SwexFilter.Data;

public class SwexImportService(DataContext dataContext)
{
    public void ImportRunes(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var importedRunes = JsonSerializer.Deserialize<List<SwexRune>>(jsonData);

        if (importedRunes is not null) dataContext.ImportRunes(importedRunes);
    }
}