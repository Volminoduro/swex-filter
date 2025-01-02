using RuneManager.Controllers;
using RuneManager.Data;
using RuneManager.Models;

namespace RuneManager.Views
{
    public partial class RuneView : Form
    {
        private readonly RuneController _runeController;
        private readonly FilterController _filterController;
        private readonly IDataContext _dataContext;
        private int _currentPage = 1;
        private int _pageSize = 10;

        public RuneView(RuneController runeController, FilterController filterController, IDataContext dataContext)
        {
            _runeController = runeController;
            _filterController = filterController;
            _dataContext = dataContext;
            InitializeComponent();
            LoadRunes();
        }

        public void LoadRunes()
        {
            var runes = _runeController.GetRunes(_currentPage, _pageSize);
            var filteredRunes = _filterController.ApplyFilters(runes.ToList());
            dataGridViewRunes.DataSource = new BindingSource { DataSource = filteredRunes };
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                openFileDialog.Title = "Import SWEX file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SWEXImportService importService = new SWEXImportService(_dataContext);
                    importService.ImportRunes(openFileDialog.FileName);
                    LoadRunes();
                }
            }
        }

        private void dataGridViewRunes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            List<int> indexes = new List<int>();
            indexes.Add(dataGridViewRunes.Columns["SetColumn"].Index);
            indexes.Add(dataGridViewRunes.Columns["SlotColumn"].Index);
            indexes.Add(dataGridViewRunes.Columns["StarsColumn"].Index);
            indexes.Add(dataGridViewRunes.Columns["RarityColumn"].Index);
            indexes.Add(dataGridViewRunes.Columns["MainStatColumn"].Index);
            indexes.Add(dataGridViewRunes.Columns["InnateStatColumn"].Index);
            indexes.Add(dataGridViewRunes.Columns["SubStat1Column"].Index);
            indexes.Add(dataGridViewRunes.Columns["SubStat2Column"].Index);
            indexes.Add(dataGridViewRunes.Columns["SubStat3Column"].Index);
            indexes.Add(dataGridViewRunes.Columns["SubStat4Column"].Index);
            if (indexes.Contains(dataGridViewRunes.CurrentCell.ColumnIndex))
            {
                if (dataGridViewRunes.IsCurrentCellDirty)
                {
                    dataGridViewRunes.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void DataGridViewRunes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridViewRunes.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
                {
                    dataGridViewRunes.BeginEdit(true);

                    ComboBox comboBox = dataGridViewRunes.EditingControl as ComboBox;
                    if (comboBox != null)
                    {
                        comboBox.DroppedDown = true;
                    }
                }
            }
        }

        private void dataGridViewRunes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var rune = (SWEXRune)dataGridViewRunes.Rows[e.RowIndex].DataBoundItem;
            _runeController.UpdateRune(rune);
        }
    }
}
