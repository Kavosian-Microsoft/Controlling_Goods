using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factory
{
    public partial class UserManagement : Form
    {
        enum DataBaseOperation
        {
            none = -1,
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4
        }//DataBaseOperation
        public string strConnection = "";
        DataBaseOperation currentoperation = DataBaseOperation.none;
        //-----------------------------------------------------------------------------------------     
        public UserManagement()
        {
            InitializeComponent();
        }//UserManagement
        //-----------------------------------------------------------------------------------------
        private void UserManagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'factory_DataBaseDataSet_UserType.tbl_UserType' table. You can move, or remove it, as needed.
            this.tbl_UserTypeTableAdapter.Fill(this.factory_DataBaseDataSet_UserType.tbl_UserType);
            Load_List_of_Users();
            currentoperation = DataBaseOperation.none;
            clear_form();
        }//UserManagement_Load
        //-----------------------------------------------------------------------------------------
        void clear_form()
        {
            TextBox t = new TextBox();
            CheckBox ch = new CheckBox();
            foreach (var c in grbUserInfor.Controls)
            {
                if (c.GetType() == t.GetType())
                {
                    t = (TextBox)c;
                    t.Clear();
                }//if Control is Textbox
            }//foreach
            foreach (var c in grbUserInfor.Controls)
            {
                if (c.GetType() == ch.GetType())
                {
                    ch = (CheckBox)c;
                    ch.Checked = false;
                }//if Control is Textbox
            }//foreach
        }//clear_form
        //-----------------------------------------------------------------------------------------
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }//exitToolStripMenuItem_Click
        //-----------------------------------------------------------------------------------------
        private void Load_List_of_Users()
        {
            try
            {
                //string strsql = "Select * from tbl_product";
                string strsql = "select * from tbl_user inner join tbl_UserType on usertypeID= tbl_UserType.TypeID";
                SqlConnection sqlCon = new SqlConnection(strConnection);
                sqlCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(strsql, sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_User");
                dgvUsers.DataSource = ds.Tables["tbl_User"];
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 8 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
        }//Load_List_of_Load_List_of_Users
        //-----------------------------------------------------------------------------------------
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_form();
            grbUserInfor.Visible = true;
            currentoperation = DataBaseOperation.Create;
            Load_List_of_Users();
        }//addNewUserToolStripMenuItem_Click
        //-----------------------------------------------------------------------------------------
        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_form();
            grbUserInfor.Visible = true;
            currentoperation = DataBaseOperation.Update;
            Load_List_of_Users();
        }//editUserToolStripMenuItem_Click
        //-----------------------------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            currentoperation = DataBaseOperation.none;
            grbUserInfor.Visible = false;
            Load_List_of_Users();
            clear_form();
        }//btnCancel_Click
         //-----------------------------------------------------------------------------------------
        bool check_data_entery_for_product()
        {
            bool result = false;
            if (txtUserName.Text.Length > 0)
            {
                if (txtPassword.Text.Length > 0)
                {
                    if (txtFirstname.Text.Length > 0)
                    {
                        if (txtLastname.Text.Length > 0)
                        {
                            if (txtMobile.Text.Length > 0)
                            {
                                result = true;
                            }//if mobile is entered 
                        }//if last name is entered                        
                    }//if txtFirstname is entered
                }//if txtPassword is entered 
            }//if txtUserName is entered
            return result;
        }//check_data_entery_for_product
        //-----------------------------------------------------------------------------------------
        private bool check_existanse()
        {
            bool result = false;
            try
            {
                string strsql = string.Format("select count(*) from tbl_User where username='{0}'", txtUserName.Text.Trim());
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);
                int r = (int)sqlcmd.ExecuteScalar();
                sqlcon.Close();
                if (r > 0)
                {
                    result = true;
                }//if record already exists

            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 9 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
            return result;
        }//check_existanse
        //-----------------------------------------------------------------------------------------        
        private bool check_existanse(int uid, string un)
        {
            bool result = false;
            try
            {
                string strsql = string.Format("select count(*) from tbl_User where username='{0}' and UID <>{1}", un, uid);
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);
                int r = (int)sqlcmd.ExecuteScalar();
                sqlcon.Close();
                if (r > 0)
                {
                    result = true;
                }//if record already exists

            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 9 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
            return result;
        }//check_existanse
        //-----------------------------------------------------------------------------------------        
        bool save_product_to_DataBase()
        {
            bool result = false;
            try
            {
                string un = txtUserName.Text.Trim();
                string pw = txtPassword.Text.Trim();
                string fn = txtFirstname.Text.Trim();
                string ln = txtLastname.Text.Trim();
                string mn = txtMobile.Text.Trim();
                bool ia = chkISActive.Checked;
                int ut = int.Parse(cmbUserType.SelectedValue.ToString());
                string srtSQL = string.Format("insert into tbl_User (userfirstname,userlastname,usermobile,Username,userpassword,usertypeIDinsert into tbl_User (userfirstname,userlastname,usermobile,Username,userpassword,usertypeID) values ('{0}','{1}','{2}','{3}','{4}',{5},'{6}') values ('{0}','{1}','{2}','{3}','{4}',{5})", fn, ln, mn, un, pw, ut, ia);
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(srtSQL, sqlcon);
                int r = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                if (r == 1)
                {
                    result = true;
                }//if one record is added                
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 10 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
            return result;
        }//save_product_to_DataBase
         //-----------------------------------------------------------------------------------------
        bool update_product_in_DataBase()
        {
            bool result = false;
            try
            {
                int ui = int.Parse(txtUserID.Text.Trim());
                string un = txtUserName.Text.Trim();
                string pw = txtPassword.Text.Trim();
                string fn = txtFirstname.Text.Trim();
                string ln = txtLastname.Text.Trim();
                string mn = txtMobile.Text.Trim();
                int ut = int.Parse(cmbUserType.SelectedValue.ToString());
                bool ia = chkISActive.Checked;
                string srtSQL = string.Format("Update tbl_User set userfirstname='{0}',userlastname='{1}',usermobile='{2}' ,Username='{3}' ,userpassword ='{4}',usertypeID={5},userIsActive='{7}' where UID={6}", fn, ln, mn, un, pw, ut, ui, ia);
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(srtSQL, sqlcon);
                int r = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                if (r == 1)
                {
                    result = true;
                }//if one record is added   

            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 2 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
            return result;
        }//update_product_in_DataBase
        //-----------------------------------------------------------------------------------------
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            string strTitle, strMessage;
            strTitle = Properties.Resources.ProgramTitle;
            strMessage = "";
            if (check_data_entery_for_product())
            {

                ///Code to save data
                if (currentoperation == DataBaseOperation.Create)
                {
                    if (check_existanse())
                    {
                        strMessage = "The record already exists";
                        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }//if record exists
                    else
                    {
                        if (save_product_to_DataBase())
                        {
                            strMessage = "One record is added to database";
                            Load_List_of_Users();
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear_form();
                        }//if one record is added to data base
                        if (save_product_to_DataBase())
                        {
                            strMessage = "One record is added to database";
                            Load_List_of_Users();
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear_form();
                        }//if one record is added to data base
                    }//else

                }//if New record is being inserted
                else if (currentoperation == DataBaseOperation.Update)
                {
                    if (check_existanse( int.Parse(txtUserID.Text.Trim()),txtUserName.Text))
                    {
                        strMessage = "The record already exists";
                        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }//if record exists
                    else {
                        if (update_product_in_DataBase())
                        {
                            strMessage = "One record is updated in database";
                            Load_List_of_Users();
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear_form();
                        }//if one record is added to data base
                    }//else                    
                }//if an edit operation is in progress
            }//if All data fields are filled in 
            else
            {
                strMessage = "Please fill in all fields";
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//else if there is fata missing
        }//btnSaveUser_Click
        //-----------------------------------------------------------------------------------------
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserID.Text = dgvUsers.CurrentRow.Cells[0].Value.ToString();
            txtFirstname.Text = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            txtLastname.Text = dgvUsers.CurrentRow.Cells[4].Value.ToString();
            txtMobile.Text = dgvUsers.CurrentRow.Cells[5].Value.ToString();
            txtPassword.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            txtUserName.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            cmbUserType.SelectedValue = dgvUsers.CurrentRow.Cells[6].Value.ToString();
            chkISActive.Checked = bool.Parse(dgvUsers.CurrentRow.Cells[7].Value.ToString());
        }//dgvUsers_CellClick
        //-----------------------------------------------------------------------------------------
    }//public partial class UserManagement : Form
}//Factory
