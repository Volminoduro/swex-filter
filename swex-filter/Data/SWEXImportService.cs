using Newtonsoft.Json;
using SwexFilter.Models;

namespace SwexFilter.Data
{
    public class SWEXImportService
    {
        private readonly IDataContext _dataContext;

        public SWEXImportService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void ImportRunes(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            var importedRunes = JsonConvert.DeserializeObject<List<SWEXRune>>(jsonData);

            if (importedRunes != null)
            {
                _dataContext.ImportRunes(importedRunes);
            }
        }
    }
}
