using SwexFilter.Data;
using SwexFilter.Models;

namespace SwexFilter.Controllers
{
    public class RuneController(DataContext dataContext)
    {
        private readonly DataContext _dataContext = dataContext;

        public IList<SWEXRune> GetRunes()
        {
            return _dataContext.Runes;
        }

        public void ImportRunes(IEnumerable<SWEXRune> runes)
        {
            _dataContext.ImportRunes(runes);
        }
    }
}
