using SwexFilter.Data;
using SwexFilter.Models;
using SwexFilter.Utils;

namespace SwexFilter.Controllers
{
    public class RuneController
    {
        private readonly IDataContext _dataContext;
        public RuneController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SWEXRune> GetRunes(int pageNumber, int pageSize)
        {
            return PaginationHelper<SWEXRune>.Paginate(_dataContext.Runes, pageNumber, pageSize);
        }

        public void AddRune(SWEXRune rune)
        {
            _dataContext.AddRune(rune);
        }

        public void UpdateRune(SWEXRune rune)
        {
            _dataContext.UpdateRune(rune);
        }

        public void DeleteRune(int id)
        {
            _dataContext.DeleteRune(id);
        }

        public void ImportRunes(IEnumerable<SWEXRune> runes)
        {
            _dataContext.ImportRunes(runes);
        }
    }
}
