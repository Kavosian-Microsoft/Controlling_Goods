namespace Factory
{
    partial class UserManagement
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
            this.grbUsersList = new System.Windows.Forms.GroupBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.grbUserInfor = new System.Windows.Forms.GroupBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.tblUserTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.factory_DataBaseDataSet_UserType = new Factory.Factory_DataBaseDataSet_UserType();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbl_UserTypeTableAdapter = new Factory.Factory_DataBaseDataSet_UserTypeTableAdapters.tbl_UserTypeTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkISActive = new System.Windows.Forms.CheckBox();
            this.grbUsersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.grbUserInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factory_DataBaseDataSet_UserType)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbUsersList
            // 
            this.grbUsersList.Controls.Add(this.dgvUsers);
            this.grbUsersList.Location = new System.Drawing.Point(12, 27);
            this.grbUsersList.Name = "grbUsersList";
            this.grbUsersList.Size = new System.Drawing.Size(939, 150);
            this.grbUsersList.TabIndex = 0;
            this.grbUsersList.TabStop = false;
            this.grbUsersList.Text = "List Of users";
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(3, 33);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(933, 114);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // grbUserInfor
            // 
            this.grbUserInfor.Controls.Add(this.chkISActive);
            this.grbUserInfor.Controls.Add(this.txtUserID);
            this.grbUserInfor.Controls.Add(this.label7);
            this.grbUserInfor.Controls.Add(this.btnCancel);
            this.grbUserInfor.Controls.Add(this.btnSaveUser);
            this.grbUserInfor.Controls.Add(this.cmbUserType);
            this.grbUserInfor.Controls.Add(this.label6);
            this.grbUserInfor.Controls.Add(this.txtMobile);
            this.grbUserInfor.Controls.Add(this.label5);
            this.grbUserInfor.Controls.Add(this.txtLastname);
            this.grbUserInfor.Controls.Add(this.label4);
            this.grbUserInfor.Controls.Add(this.txtFirstname);
            this.grbUserInfor.Controls.Add(this.label3);
            this.grbUserInfor.Controls.Add(this.txtPassword);
            this.grbUserInfor.Controls.Add(this.label2);
            this.grbUserInfor.Controls.Add(this.txtUserName);
            this.grbUserInfor.Controls.Add(this.label1);
            this.grbUserInfor.Location = new System.Drawing.Point(12, 180);
            this.grbUserInfor.Name = "grbUserInfor";
            this.grbUserInfor.Size = new System.Drawing.Size(939, 282);
            this.grbUserInfor.TabIndex = 1;
            this.grbUserInfor.TabStop = false;
            this.grbUserInfor.Visible = false;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(134, 28);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(120, 37);
            this.txtUserID.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 29);
            this.label7.TabIndex = 14;
            this.label7.Text = "User ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancel.Location = new System.Drawing.Point(792, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 94);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.LawnGreen;
            this.btnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUser.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSaveUser.Location = new System.Drawing.Point(792, 24);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(130, 84);
            this.btnSaveUser.TabIndex = 12;
            this.btnSaveUser.Text = "&Save";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // cmbUserType
            // 
            this.cmbUserType.DataSource = this.tblUserTypeBindingSource;
            this.cmbUserType.DisplayMember = "TypeName";
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(497, 172);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(162, 37);
            this.cmbUserType.TabIndex = 11;
            this.cmbUserType.ValueMember = "TypeID";
            // 
            // tblUserTypeBindingSource
            // 
            this.tblUserTypeBindingSource.DataMember = "tbl_UserType";
            this.tblUserTypeBindingSource.DataSource = this.factory_DataBaseDataSet_UserType;
            // 
            // factory_DataBaseDataSet_UserType
            // 
            this.factory_DataBaseDataSet_UserType.DataSetName = "Factory_DataBaseDataSet_UserType";
            this.factory_DataBaseDataSet_UserType.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "User Type:";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(134, 168);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(218, 37);
            this.txtMobile.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mobile:";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(497, 121);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(267, 37);
            this.txtLastname.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last Name:";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(134, 118);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(216, 37);
            this.txtFirstname.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "First Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(497, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(267, 37);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(134, 71);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(218, 37);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // tbl_UserTypeTableAdapter
            // 
            this.tbl_UserTypeTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(963, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewUserToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editUserToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addNewUserToolStripMenuItem.Text = "&Add new user";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.editUserToolStripMenuItem.Text = "&Edit User";
            this.editUserToolStripMenuItem.Click += new System.EventHandler(this.editUserToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chkISActive
            // 
            this.chkISActive.AutoSize = true;
            this.chkISActive.Location = new System.Drawing.Point(134, 230);
            this.chkISActive.Name = "chkISActive";
            this.chkISActive.Size = new System.Drawing.Size(92, 33);
            this.chkISActive.TabIndex = 16;
            this.chkISActive.Text = "Active";
            this.chkISActive.UseVisualStyleBackColor = true;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 467);
            this.Controls.Add(this.grbUserInfor);
            this.Controls.Add(this.grbUsersList);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "UserManagement";
            this.Text = "User Management";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UserManagement_Load);
            this.grbUsersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.grbUserInfor.ResumeLayout(false);
            this.grbUserInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factory_DataBaseDataSet_UserType)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUsersList;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox grbUserInfor;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Label label6;
        private Factory_DataBaseDataSet_UserType factory_DataBaseDataSet_UserType;
        private System.Windows.Forms.BindingSource tblUserTypeBindingSource;
        private Factory_DataBaseDataSet_UserTypeTableAdapters.tbl_UserTypeTableAdapter tbl_UserTypeTableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkISActive;
    }
}