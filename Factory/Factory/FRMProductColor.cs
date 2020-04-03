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
    public partial class FRMProductColor : Form
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
        public FRMProductColor()
        {
            InitializeComponent();
        }//FRMProductColor
        private void FRMProductColor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'factory_DataBaseDataSet.tbl_Color' table. You can move, or remove it, as needed.
            //this.tbl_ColorTableAdapter.Fill(this.factory_DataBaseDataSet.tbl_Color);
            Load_List_of_Color();
        }//FRMProductColor_Load
        //-----------------------------------------------------------------------------------------
        private void btnAddColor_Click(object sender, EventArgs e)
        {
            string strTitle, strMessage;
            strTitle = Properties.Resources.ProgramTitle;
            strMessage = "";
            if (txtColorName.Text.Length > 0)
            {
                if (check_color_existanse(txtColorName.Text.Trim()))
                {
                    strMessage = "The record already exists";
                    MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }//if record exists
                else
                {
                    ///Code to save data
                    if (currentoperation == DataBaseOperation.Create)
                    {

                        if (save_product_to_DataBase())
                        {
                            strMessage = "One record is added to database";
                            Load_List_of_Color();
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear_entery();
                        }//if one record is added to data base
                    }//if New record is being insrted
                    else if (currentoperation == DataBaseOperation.Update)
                    {
                        if (update_product_in_DataBase())
                        {
                            strMessage = "One record is updated in database";
                            Load_List_of_Color();
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear_entery();
                        }//if one record is added to data base
                    }//if an edit operation is in progress
                }//else if record is unique
            }//if All data fields are filled in 
            else
            {
                strMessage = "Please fill in color field";
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//else if there is fata missing
        }//btnAddColor_Click
        private bool check_color_existanse(string colorname)
        {
            bool result = false;
            try
            {
                string strsql = string.Format("select count(*) from tbl_color where ColorName='{0}'", colorname);
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
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 4 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch

            return result;
        }//check_color_existanse
        private void clear_entery()
        {
            txtColorName.Clear();
        }//clear_entery();
        bool save_product_to_DataBase()
        {
            bool result = false;
            try
            {
                string cn = txtColorName.Text.Trim();
                string srtSQL = string.Format("Insert into tbl_Color (ColorName) values ('{0}')", cn);
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
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 5 ";
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
                string cn = txtColorName.Text.Trim();
                int cid = int.Parse(dgvColors.CurrentRow.Cells[0].Value.ToString());
                string srtSQL = string.Format("Update tbl_Color set ColorName='{0}' where ColorID={1}", cn, cid);
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(srtSQL, sqlcon);
                int r = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                if (r == 1)
                {
                    result = true;
                }//if one record is updated
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 6 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
            return result;
        }//update_product_in_DataBase

        private void dgvColors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtColorID.Text   = dgvColors.CurrentRow.Cells[0].Value.ToString();
            txtColorName.Text = dgvColors.CurrentRow.Cells[1].Value.ToString();
        }//dgvColors_CellClick

        private void btnReturn_Click(object sender, EventArgs e)
        {
            currentoperation = DataBaseOperation.none;
            clear_entery();
            EnrtyPanel.Visible = false;
        }//btnReturn_Click

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }//exitToolStripMenuItem_Click

        private void addNewColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrtyPanel.Visible = true;
            currentoperation = DataBaseOperation.Create;
        }//addNewColorToolStripMenuItem_Click

        private void editExistingColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrtyPanel.Visible = true;
            currentoperation = DataBaseOperation.Update;
        }//editExistingColorToolStripMenuItem_Click
        private void Load_List_of_Color()
        {
            try
            {

                string strsql = "select * from tbl_Color";
                SqlConnection sqlCon = new SqlConnection(strConnection);
                sqlCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(strsql, sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_Color");
                dgvColors.DataSource = ds.Tables["tbl_Color"];
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 7 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
        }//Load_List_of_Product
        //-----------------------------------------------------------------------------------------
        bool check_data_entery_for_product()
        {
            bool result = false;
            if (txtColorName.Text.Length > 0)
            {
                result = true;

            }//if ColorName is entered
            return result;
        }//check_data_entery_for_product
        //-----------------------------------------------------------------------------------------
        private bool remove_record(int CID)
        {
            bool result = false;
            string strsql = string.Format("Delete from tbl_Color where ColorID={0}", CID);
            try
            {
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);
                int r = sqlcmd.ExecuteNonQuery();
                if (r > 0)
                {
                    result = true;
                }//if removed 
                sqlcon.Close();
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 4 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
            return result;
        }//remove_record
        //-----------------------------------------------------------------------------------------
        private bool check_color_dependency(int colorid) {
            bool result = false;
            string strsql;
            SqlConnection sqlcon = new SqlConnection(strConnection);
            sqlcon.Open();
            strsql = string.Format("select count(ProductID) from tbl_product where ProductColor={0}",colorid);
            SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);
            int r =(int)sqlcmd.ExecuteScalar();
            if (r > 0) {
                result = true;
            }//if color is used
            return result;               
        }//check_color_dependency
        //-----------------------------------------------------------------------------------------
        private void btnRemove_Click(object sender, EventArgs e)
        {
            string strTitle, strMessage;
            strTitle = Properties.Resources.ProgramTitle;
            strMessage = "";
            if (check_data_entery_for_product())
            {
                DialogResult res;
                strMessage = "Are you sure for removing the selected record";
                res = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (check_color_dependency(int.Parse(txtColorID.Text.Trim()))) {
                        strMessage = "This color is used in definig products, first modify the product";
                        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }//if there is color dependency
                    else {
                        if (remove_record(int.Parse(txtColorID.Text.Trim())))
                        {
                            Load_List_of_Color();
                            clear_entery();
                            strMessage = "One record is removed";
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }//if it is OK to remove record 
                        else
                        {
                            strMessage = "The record is not removed, check again please";
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }//else if removing was not completed 
                    }//else if there is no color dependency
                }//if yes is pressesd                
            }//if All data fields are filled in 
            else
            {
                strMessage = "Please select a record";
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//else if there is fata missing

        }//btnRemove
        //---------------------------------------------------------------------
    }//FRMProductColor : Form
}//Factory