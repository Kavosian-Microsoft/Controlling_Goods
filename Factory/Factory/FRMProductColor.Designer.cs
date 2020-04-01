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
            this.dgvColors = new System.Windows.Forms.DataGridView();
            this.EnrtyPanel = new System.Windows.Forms.Panel();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).BeginInit();
            this.EnrtyPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvColors
            // 
            this.dgvColors.AllowUserToAddRows = false;
            this.dgvColors.AllowUserToDeleteRows = false;
            this.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvColors.Location = new System.Drawing.Point(0, 24);
            this.dgvColors.Name = "dgvColors";
            this.dgvColors.ReadOnly = true;
            this.dgvColors.Size = new System.Drawing.Size(384, 150);
            this.dgvColors.TabIndex = 0;
            this.dgvColors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColors_CellClick);
            // 
            // EnrtyPanel
            // 
            this.EnrtyPanel.Controls.Add(this.btnReturn);
            this.EnrtyPanel.Controls.Add(this.btnAddColor);
            this.EnrtyPanel.Controls.Add(this.txtColorName);
            this.EnrtyPanel.Controls.Add(this.label1);
            this.EnrtyPanel.Location = new System.Drawing.Point(0, 156);
            this.EnrtyPanel.Name = "EnrtyPanel";
            this.EnrtyPanel.Size = new System.Drawing.Size(384, 100);
            this.EnrtyPanel.TabIndex = 1;
            this.EnrtyPanel.Visible = false;
            // 
            // btnAddColor
            // 
            this.btnAddColor.BackColor = System.Drawing.Color.Lime;
            this.btnAddColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColor.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAddColor.Location = new System.Drawing.Point(4, 59);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(114, 34);
            this.btnAddColor.TabIndex = 6;
            this.btnAddColor.Text = "Add Color";
            this.btnAddColor.UseVisualStyleBackColor = false;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // txtColorName
            // 
            this.txtColorName.Location = new System.Drawing.Point(124, 13);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new System.Drawing.Size(261, 33);
            this.txtColorName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Color Name:";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.Color.Red;
            this.btnReturn.Location = new System.Drawing.Point(124, 59);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(114, 34);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewColorToolStripMenuItem,
            this.editExistingColorToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addNewColorToolStripMenuItem
            // 
            this.addNewColorToolStripMenuItem.Name = "addNewColorToolStripMenuItem";
            this.addNewColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewColorToolStripMenuItem.Text = "Add New Color";
            this.addNewColorToolStripMenuItem.Click += new System.EventHandler(this.addNewColorToolStripMenuItem_Click);
            // 
            // editExistingColorToolStripMenuItem
            // 
            this.editExistingColorToolStripMenuItem.Name = "editExistingColorToolStripMenuItem";
            this.editExistingColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editExistingColorToolStripMenuItem.Text = "Edit Existing Color";
            this.editExistingColorToolStripMenuItem.Click += new System.EventHandler(this.editExistingColorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FRMProductColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.ControlBox = false;
            this.Controls.Add(this.EnrtyPanel);
            this.Controls.Add(this.dgvColors);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRMProductColor";
            this.Text = "Products Color";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FRMProductColor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).EndInit();
            this.EnrtyPanel.ResumeLayout(false);
            this.EnrtyPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvColors;
        private System.Windows.Forms.Panel EnrtyPanel;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}