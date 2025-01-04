namespace SwexFilter.Views
{
    partial class FiltersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FitersDatagridView = new DataGridView();
            IsActiveColumn = new DataGridViewCheckBoxColumn();
            NameColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)FitersDatagridView).BeginInit();
            SuspendLayout();
            // 
            // FitersDatagridView
            // 
            FitersDatagridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FitersDatagridView.Columns.AddRange(new DataGridViewColumn[] { IsActiveColumn, NameColumn });
            FitersDatagridView.Location = new Point(3, 3);
            FitersDatagridView.Name = "FitersDatagridView";
            FitersDatagridView.Size = new Size(240, 150);
            FitersDatagridView.TabIndex = 0;
            // 
            // IsActiveColumn
            // 
            IsActiveColumn.DataPropertyName = "IsActive";
            IsActiveColumn.Frozen = true;
            IsActiveColumn.HeaderText = "On / Off";
            IsActiveColumn.Name = "IsActiveColumn";
            IsActiveColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // NameColumn
            // 
            NameColumn.DataPropertyName = "Name";
            NameColumn.Frozen = true;
            NameColumn.HeaderText = "Name";
            NameColumn.Name = "NameColumn";
            // 
            // FormsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(FitersDatagridView);
            Name = "FormsControl";
            Size = new Size(1920, 500);
            ((System.ComponentModel.ISupportInitialize)FitersDatagridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView FitersDatagridView;
        private DataGridViewCheckBoxColumn IsActiveColumn;
        private DataGridViewTextBoxColumn NameColumn;
    }
}
