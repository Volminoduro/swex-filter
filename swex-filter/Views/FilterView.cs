using SwexFilter.Controllers;
using SwexFilter.Models;

namespace SwexFilter.Views
{
    public partial class FilterView : Form
    {
        private readonly FilterController _filterController;
        private readonly RuneView _runeView;
        private Filter _copiedFilter;

        public FilterView(FilterController filterController, RuneView runeView)
        {
            _filterController = filterController;
            _runeView = runeView;
            InitializeComponent();
            LoadFilters();
        }

        private void LoadFilters()
        {
            var filters = _filterController.GetFilters();
            dataGridViewFilters.DataSource = new BindingSource { DataSource = filters };
            _runeView.LoadRunes();

            // Adding key press handling
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FilterView_KeyDown);
        }
        private void FilterView_KeyDown(object sender, KeyEventArgs e)
        {
            // Copy (Ctrl+C)
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedFilter();
            }
            // Paste (Ctrl+V)
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteCopiedFilter();
            }
        }

        private void CopySelectedFilter()
        {
            if (dataGridViewFilters.SelectedRows.Count > 0)
            {
                var filter = (Filter)dataGridViewFilters.SelectedRows[0].DataBoundItem;
                _copiedFilter = new Filter
                {
                    Set = filter.Set,
                    Slot = filter.Slot,
                    Rarity = filter.Rarity,
                    MainStat = filter.MainStat,
                    MinMainStatValue = filter.MinMainStatValue,
                    MaxMainStatValue = filter.MaxMainStatValue,
                    SubStat1 = filter.SubStat1,
                    MinSubStat1Value = filter.MinSubStat1Value,
                    MaxSubStat1Value = filter.MaxSubStat1Value,
                    SubStat2 = filter.SubStat2,
                    MinSubStat2Value = filter.MinSubStat2Value,
                    MaxSubStat2Value = filter.MaxSubStat2Value,
                    SubStat3 = filter.SubStat3,
                    MinSubStat3Value = filter.MinSubStat3Value,
                    MaxSubStat3Value = filter.MaxSubStat3Value,
                    SubStat4 = filter.SubStat4,
                    MinSubStat4Value = filter.MinSubStat4Value,
                    MaxSubStat4Value = filter.MaxSubStat4Value,
                    InnateStat = filter.InnateStat,
                    MinInnateStatValue = filter.MinInnateStatValue,
                    MaxInnateStatValue = filter.MaxInnateStatValue,
                    IsActive = filter.IsActive // Name ignored
                };
            }
        }

        private void PasteCopiedFilter()
        {
            if (_copiedFilter != null && dataGridViewFilters.SelectedRows.Count > 0)
            {
                var filter = (Filter)dataGridViewFilters.SelectedRows[0].DataBoundItem;
                filter.Set = _copiedFilter.Set;
                filter.Slot = _copiedFilter.Slot;
                filter.Rarity = _copiedFilter.Rarity;
                filter.MainStat = _copiedFilter.MainStat;
                filter.MinMainStatValue = _copiedFilter.MinMainStatValue;
                filter.MaxMainStatValue = _copiedFilter.MaxMainStatValue;
                filter.SubStat1 = _copiedFilter.SubStat1;
                filter.MinSubStat1Value = _copiedFilter.MinSubStat1Value;
                filter.MaxSubStat1Value = _copiedFilter.MaxSubStat1Value;
                filter.SubStat2 = _copiedFilter.SubStat2;
                filter.MinSubStat2Value = _copiedFilter.MinSubStat2Value;
                filter.MaxSubStat2Value = _copiedFilter.MaxSubStat2Value;
                filter.SubStat3 = _copiedFilter.SubStat3;
                filter.MinSubStat3Value = _copiedFilter.MinSubStat3Value;
                filter.MaxSubStat3Value = _copiedFilter.MaxSubStat3Value;
                filter.SubStat4 = _copiedFilter.SubStat4;
                filter.MinSubStat4Value = _copiedFilter.MinSubStat4Value;
                filter.MaxSubStat4Value = _copiedFilter.MaxSubStat4Value;
                filter.InnateStat = _copiedFilter.InnateStat;
                filter.MinInnateStatValue = _copiedFilter.MinInnateStatValue;
                filter.MaxInnateStatValue = _copiedFilter.MaxInnateStatValue;
                filter.IsActive = _copiedFilter.IsActive; // Name ignored

                dataGridViewFilters.Refresh();
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            string baseName = "Filter";
            string filterName = baseName;
            int counter = 1;

            // Ensure the filter name is unique
            while (_filterController.GetFilters().Any(f => f.Name == filterName))
            {
                filterName = $"{baseName} {counter}";
                counter++;
            }

            // Create a new filter with the unique name
            var newFilter = new Filter { Name = filterName, IsActive = false };

            // Add the new filter
            _filterController.AddFilter(newFilter);

            // Reload filters to display the new entry
            LoadFilters();
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            if (dataGridViewFilters.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridViewFilters.SelectedRows)
                {
                    var filter = (Filter)selectedRow.DataBoundItem;

                    // Delete the filter
                    _filterController.DeleteFilter(filter.Name);
                }

                // Reload filters to reflect the changes
                LoadFilters();
            }
            else
            {
                MessageBox.Show("Please select filters to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dataGridViewFilters_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            List<int> indexes = new List<int>();
            indexes.Add(dataGridViewFilters.Columns["IsActive"].Index);
            indexes.Add(dataGridViewFilters.Columns["SetColumn"].Index);
            indexes.Add(dataGridViewFilters.Columns["SlotColumn"].Index);
            indexes.Add(dataGridViewFilters.Columns["StarsColumn"].Index);
            indexes.Add(dataGridViewFilters.Columns["RarityColumn"].Index);
            indexes.Add(dataGridViewFilters.Columns["MainStatColumn"].Index);
            indexes.Add(dataGridViewFilters.Columns["InnateStatColumn"].Index);
            indexes.Add(dataGridViewFilters.Columns["SubStat1Column"].Index);
            indexes.Add(dataGridViewFilters.Columns["SubStat2Column"].Index);
            indexes.Add(dataGridViewFilters.Columns["SubStat3Column"].Index);
            indexes.Add(dataGridViewFilters.Columns["SubStat4Column"].Index);
            if (indexes.Contains(dataGridViewFilters.CurrentCell.ColumnIndex))
            {
                if (dataGridViewFilters.IsCurrentCellDirty)
                {
                    dataGridViewFilters.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void DataGridViewFilters_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the column is a DataGridViewComboBoxColumn
            if (dataGridViewFilters.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                dataGridViewFilters.BeginEdit(true);
                ComboBox comboBox = dataGridViewFilters.EditingControl as ComboBox;
                if (comboBox != null)
                {
                    comboBox.DroppedDown = true;
                }
            }
        }

        private void DataGridViewFilters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridViewFilters.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
                {
                    dataGridViewFilters.BeginEdit(true);

                    ComboBox comboBox = dataGridViewFilters.EditingControl as ComboBox;
                    if (comboBox != null)
                    {
                        comboBox.DroppedDown = true;
                    }
                }
            }
        }

        private void dataGridViewFilters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var filter = (Filter)dataGridViewFilters.Rows[e.RowIndex].DataBoundItem;
                _filterController.UpdateFilter(filter);
                // Check if the filter name already exists
                if (_filterController.GetFilters().Any(f => f.Name == filter.Name && f != filter))
                {
                    MessageBox.Show("A filter with this name already exists. Please choose another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Restore the old filter name
                    dataGridViewFilters.CancelEdit();
                }
                else
                {
                    // Check for empty filter name
                    if (string.IsNullOrWhiteSpace(filter.Name))
                    {
                        MessageBox.Show("Filter name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridViewFilters.CancelEdit();
                    }
                    else
                    {
                        _filterController.UpdateFilter(filter);
                        _runeView.LoadRunes();
                    }
                }
            }
        }

        private void btnActivateAllFilters_Click(object sender, EventArgs e)
        {
            var filters = _filterController.GetFilters();

            foreach (var filter in filters)
            {
                filter.IsActive = true;
                _filterController.UpdateFilter(filter);
            }

            LoadFilters();
        }

        private void btnDeactivateAllFilters_Click(object sender, EventArgs e)
        {
            var filters = _filterController.GetFilters();

            foreach (var filter in filters)
            {
                filter.IsActive = false;
                _filterController.UpdateFilter(filter);
            }

            LoadFilters();
        }
    }
}
