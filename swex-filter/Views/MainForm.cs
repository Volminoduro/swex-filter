using SwexFilter.Controllers;
using SwexFilter.Data;

namespace SwexFilter.Views;

public partial class MainForm : Form
{
    private readonly DataContext _dataContext;
    private readonly FilterController _filterController;
    private readonly RuneController _runeController;

    public MainForm(FilterController filterController, RuneController runeController, DataContext dataContext)
    {
        _filterController = filterController;
        _runeController = runeController;
        _dataContext = dataContext;
        InitializeComponent();
        InitializeCustomControls();
    }

    private void InitializeCustomControls()
    {
        // Create and configure the FilterView
        FiltersControl filtersControl = new(_filterController)
        {
            Dock = DockStyle.Top, // Dock top to stack below RuneView
            Height = 100 // Adjust the height as needed
        };

        // Add the controls to the panel
        MainFormPanel.Controls.Add(filtersControl);

        // Add the panel to the form
        Controls.Add(MainFormPanel);
    }
}