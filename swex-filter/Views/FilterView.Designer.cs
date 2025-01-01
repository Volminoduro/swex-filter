using MyApp.Models.Enums;

namespace RuneManager.Views
{
    partial class FilterView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewFilters;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnActivateAllFilters;
        private System.Windows.Forms.Button btnDeactivateAllFilters;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewFilters = new System.Windows.Forms.DataGridView();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.btnActivateAllFilters = new System.Windows.Forms.Button();
            this.btnDeactivateAllFilters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilters)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFilters
            // 
            this.dataGridViewFilters.AllowUserToAddRows = false;
            this.dataGridViewFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "IsActive",
                    Name = "IsActive",
                    HeaderText = "Is Active",
                    Frozen = true
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Name",
                    Frozen = true
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Set",
                    HeaderText = "Set",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneSet)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Slot",
                    HeaderText = "Slot",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneSlot)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Stars",
                    HeaderText = "Stars",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneStars)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Rarity",
                    HeaderText = "Rarity",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneRarity)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "MainStat",
                    HeaderText = "Main Stat",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneTypeStat)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MinMainStatValue",
                    HeaderText = "Min Main Stat Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaxMainStatValue",
                    HeaderText = "Max Main Stat Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "InnateStat",
                    HeaderText = "Innate Stat",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneTypeStat)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MinInnateStatValue",
                    HeaderText = "Min Innate Stat Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaxInnateStatValue",
                    HeaderText = "Max Innate Stat Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat1",
                    HeaderText = "Sub Stat 1",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneTypeStat)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MinSubStat1Value",
                    HeaderText = "Min Sub Stat 1 Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaxSubStat1Value",
                    HeaderText = "Max Sub Stat 1 Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat2",
                    HeaderText = "Sub Stat 2",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneTypeStat)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MinSubStat2Value",
                    HeaderText = "Min Sub Stat 2 Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaxSubStat2Value",
                    HeaderText = "Max Sub Stat 2 Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat3",
                    HeaderText = "Sub Stat 3",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneTypeStat)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MinSubStat3Value",
                    HeaderText = "Min Sub Stat 3 Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaxSubStat3Value",
                    HeaderText = "Max Sub Stat 3 Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat4",
                    HeaderText = "Sub Stat 4",
                    DataSource = new object[] { "" }.Concat(Enum.GetValues(typeof(RuneTypeStat)).Cast<object>()).ToArray()
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MinSubStat4Value",
                    HeaderText = "Min Sub Stat 4 Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaxSubStat4Value",
                    HeaderText = "Max Sub Stat 4 Value"
                }
            });
            this.dataGridViewFilters.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewFilters.Name = "dataGridViewFilters";
            this.dataGridViewFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFilters.Size = new System.Drawing.Size(1100, 368);
            this.dataGridViewFilters.TabIndex = 0;            
            this.dataGridViewFilters.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFilters_CellValueChanged);
            this.dataGridViewFilters.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewFilters_CurrentCellDirtyStateChanged);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(12, 386);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddFilter.TabIndex = 1;
            this.btnAddFilter.Text = "Add Filter";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.Location = new System.Drawing.Point(93, 386);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFilter.TabIndex = 3;
            this.btnDeleteFilter.Text = "Delete Filter";
            this.btnDeleteFilter.UseVisualStyleBackColor = true;
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            // 
            // btnActivateAllFilters
            // 
            this.btnActivateAllFilters.Location = new System.Drawing.Point(174, 386);
            this.btnActivateAllFilters.Name = "btnActivateAllFilters";
            this.btnActivateAllFilters.Size = new System.Drawing.Size(125, 23);
            this.btnActivateAllFilters.TabIndex = 4;
            this.btnActivateAllFilters.Text = "Activate All Filters";
            this.btnActivateAllFilters.UseVisualStyleBackColor = true;
            this.btnActivateAllFilters.Click += new System.EventHandler(this.btnActivateAllFilters_Click);
            // 
            // btnDeactivateAllFilters
            // 
            this.btnDeactivateAllFilters.Location = new System.Drawing.Point(305, 386);
            this.btnDeactivateAllFilters.Name = "btnDeactivateAllFilters";
            this.btnDeactivateAllFilters.Size = new System.Drawing.Size(125, 23);
            this.btnDeactivateAllFilters.TabIndex = 5;
            this.btnDeactivateAllFilters.Text = "Deactivate All Filters";
            this.btnDeactivateAllFilters.UseVisualStyleBackColor = true;
            this.btnDeactivateAllFilters.Click += new System.EventHandler(this.btnDeactivateAllFilters_Click);
            // 
            // FilterView
            // 
            this.ClientSize = new System.Drawing.Size(1124, 450);
            this.Controls.Add(this.btnDeactivateAllFilters);
            this.Controls.Add(this.btnActivateAllFilters);
            this.Controls.Add(this.btnDeleteFilter);
            this.Controls.Add(this.btnAddFilter);
            this.Controls.Add(this.dataGridViewFilters);
            this.Name = "FilterView";
            this.Text = "Filters";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilters)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
