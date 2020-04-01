namespace Factory
{
    partial class FRMProductColor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.factory_DataBaseDataSet = new Factory.Factory_DataBaseDataSet();
            this.tblColorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_ColorTableAdapter = new Factory.Factory_DataBaseDataSetTableAdapters.tbl_ColorTableAdapter();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factory_DataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colorNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblColorBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(384, 261);
            this.dataGridView1.TabIndex = 0;
            // 
            // factory_DataBaseDataSet
            // 
            this.factory_DataBaseDataSet.DataSetName = "Factory_DataBaseDataSet";
            this.factory_DataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblColorBindingSource
            // 
            this.tblColorBindingSource.DataMember = "tbl_Color";
            this.tblColorBindingSource.DataSource = this.factory_DataBaseDataSet;
            // 
            // tbl_ColorTableAdapter
            // 
            this.tbl_ColorTableAdapter.ClearBeforeFill = true;
            // 
            // colorNameDataGridViewTextBoxColumn
            // 
            this.colorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colorNameDataGridViewTextBoxColumn.DataPropertyName = "ColorName";
            this.colorNameDataGridViewTextBoxColumn.HeaderText = "Product Color Name";
            this.colorNameDataGridViewTextBoxColumn.Name = "colorNameDataGridViewTextBoxColumn";
            this.colorNameDataGridViewTextBoxColumn.ToolTipText = "Name of color";
            // 
            // FRMProductColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRMProductColor";
            this.Text = "Products Color";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FRMProductColor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factory_DataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Factory_DataBaseDataSet factory_DataBaseDataSet;
        private System.Windows.Forms.BindingSource tblColorBindingSource;
        private Factory_DataBaseDataSetTableAdapters.tbl_ColorTableAdapter tbl_ColorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
    }
}