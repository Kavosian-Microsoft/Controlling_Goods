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
            Load_List_of_Product();
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
                            Load_List_of_Product();
                            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear_entery();
                        }//if one record is added to data base
                    }//if New record is being insrted
                    else if (currentoperation == DataBaseOperation.Update)
                    {
                        if (update_product_in_DataBase())
                        {
                            strMessage = "One record is updated in database";
                            Load_List_of_Product();                            
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
        private void clear_entery() {
            txtColorName.Clear();
        }//clear_entery();
        bool save_product_to_DataBase()
        {
            bool result = false;
            try
            {
                string cn = txtColorName.Text.Trim();                
                string srtSQL = string.Format("Insert into tbl_Color (ColorName) values ('{0}')",cn);
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
                string srtSQL = string.Format("Update tbl_Color set ColorName='{0}' where ColorID={1}", cn,cid);
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
        private void Load_List_of_Product()
        {
            try
            {
                //string strsql = "Select * from tbl_product";
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
        //---------------------------------------------------------------------
    }//FRMProductColor : Form
}//Factory