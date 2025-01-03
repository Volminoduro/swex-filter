using SwexFilter.Models.Enums;

namespace SwexFilter.Views
{
    partial class RuneView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewRunes;
        private System.Windows.Forms.Button btnImport;

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
            this.dataGridViewRunes = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRunes)).BeginInit();
            this.SuspendLayout();

            var runeSetValues = Enum.GetValues(typeof(RuneSet)).Cast<RuneSet>()
                            .Select(e => new { Value = e, Display = RuneSetInfoAttribute.GetInfo(e)?.DisplayName ?? e.ToString() }).ToList();

            var runeRarityValues = Enum.GetValues(typeof(RuneRarity)).Cast<RuneRarity>()
                               .Select(e => new { Value = e, Display = RuneRarityInfoAttribute.GetInfo(e)?.DisplayName ?? e.ToString() }).ToList();

            var runeTypeStatValuesForMainStat = Enum.GetValues(typeof(RuneTypeStat)).Cast<RuneTypeStat>()
                            .Select(e => new { Value = e, Display = RuneTypeStatInfoAttribute.GetInfo(e)?.DisplayName ?? e.ToString() }).ToList();

            var runeTypeStatValuesForInnateAndSubStat = new[] { new { Value = (RuneTypeStat?)null, Display = "" } }
                             .Concat(Enum.GetValues(typeof(RuneTypeStat)).Cast<RuneTypeStat>()
                             .Select(e => new { Value = (RuneTypeStat?)e, Display = RuneTypeStatInfoAttribute.GetInfo(e)?.DisplayName ?? e.ToString() })).ToList();
            // 
            // dataGridViewRunes
            // 
            this.dataGridViewRunes.AllowUserToAddRows = false;
            this.dataGridViewRunes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRunes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Monster",
                    HeaderText = "Monster",
                    Name = "MonsterColumn",
                    Frozen = true // Freeze this column
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ID",
                    HeaderText = "ID",
                    Name = "IDColumn",
                    Frozen = true // Freeze this column
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Set",
                    HeaderText = "Set",
                    Name = "SetColumn",
                    DataSource = runeSetValues,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Slot",
                    HeaderText = "Slot",
                    Name = "SlotColumn",
                    DataSource = Enum.GetValues(typeof(RuneSlot))
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Rarity",
                    HeaderText = "Rarity",
                    Name = "RarityColumn",
                    DataSource = runeRarityValues,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Stars",
                    HeaderText = "Stars",
                    Name = "StarsColumn",
                    DataSource = Enum.GetValues(typeof(RuneStars))
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "MainStat",
                    HeaderText = "Main Stat",
                    Name = "MainStatColumn",
                    DataSource = runeTypeStatValuesForMainStat,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MainStatValue",
                    HeaderText = "Main Stat Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "InnateStat",
                    HeaderText = "Innate Stat",
                    Name = "InnateStatColumn",
                    DataSource = runeTypeStatValuesForInnateAndSubStat,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "InnateStatValue",
                    HeaderText = "Innate Stat Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat1",
                    HeaderText = "Sub Stat 1",
                    Name = "SubStat1Column",
                    DataSource = runeTypeStatValuesForInnateAndSubStat,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SubStat1Value",
                    HeaderText = "Sub Stat 1 Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat2",
                    HeaderText = "Sub Stat 2",
                    Name = "SubStat2Column",
                    DataSource = runeTypeStatValuesForInnateAndSubStat,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SubStat2Value",
                    HeaderText = "Sub Stat 2 Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat3",
                    HeaderText = "Sub Stat 3",
                    Name = "SubStat3Column",
                    DataSource = runeTypeStatValuesForInnateAndSubStat,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SubStat3Value",
                    HeaderText = "Sub Stat 3 Value"
                },
                new System.Windows.Forms.DataGridViewComboBoxColumn
                {
                    DataPropertyName = "SubStat4",
                    HeaderText = "Sub Stat 4",
                    Name = "SubStat4Column",
                    DataSource = runeTypeStatValuesForInnateAndSubStat,
                    DisplayMember = "Display",
                    ValueMember = "Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SubStat4Value",
                    HeaderText = "Sub Stat 4 Value"
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Score",
                    HeaderText = "Score",
                    Name = "ScoreColumn",
                    ReadOnly = true
                }

            });
            this.dataGridViewRunes.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRunes.Name = "dataGridViewRunes";
            this.dataGridViewRunes.Size = new System.Drawing.Size(1000, 368);
            this.dataGridViewRunes.TabIndex = 0;
            this.dataGridViewRunes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRunes_CellClick);
            this.dataGridViewRunes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewRunes_CurrentCellDirtyStateChanged);
            this.dataGridViewRunes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRunes_CellEndEdit);
            this.dataGridViewRunes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRunes_CellEnter);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 386);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import SWEX file";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // RuneView
            // 
            this.ClientSize = new System.Drawing.Size(1024, 450);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dataGridViewRunes);
            this.Name = "RuneView";
            this.Text = "Runes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRunes)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
