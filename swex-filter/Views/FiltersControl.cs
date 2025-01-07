using SwexFilter.Controllers;

namespace SwexFilter.Views;

public partial class FiltersControl : UserControl
{
    private readonly FilterController _filterController;

    public FiltersControl(FilterController filterController)
    {
        _filterController = filterController;
        InitializeComponent();
        LoadFilters();
    }

    private void LoadFilters()
    {
        var filters = _filterController.GetFilters();
        FitersDatagridView.DataSource = new BindingSource { DataSource = filters };
    }
}