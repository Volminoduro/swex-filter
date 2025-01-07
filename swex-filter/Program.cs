using SwexFilter.Controllers;
using SwexFilter.Data;
using SwexFilter.Views;

namespace SwexFilter;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        DataContext dataContext = new("filters.json", "runes.json");

        RuneController runeController = new(dataContext);
        FilterController filterController = new(dataContext);

        Application.Run(new MainForm(filterController, runeController, dataContext));
    }
}