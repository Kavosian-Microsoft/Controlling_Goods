﻿using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Factory
{
    public partial class frmFactory : Form
    {
        enum DataBaseOperation{
            none=-1,
            Create=1,
            Read=2,
            Update=3,
            Delete=4
        }//DataBaseOperation
        string strConnection = "";
        DataBaseOperation currentoperation = DataBaseOperation.none;
        //---------------------------------------------------------------------
        public frmFactory()
        {
            InitializeComponent();
        }//frmFactory
        //---------------------------------------------------------------------
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }//exitToolStripMenuItem_Click
        //---------------------------------------------------------------------
        private void frmFactory_Load(object sender, EventArgs e)
        {            
            this.Text = Properties.Resources.ProgramTitle;
            strConnection = "Data Source=KAVOSIAN-PC10\\SQL2K14;Initial Catalog=Factory_DataBase;Integrated Security=True";
            currentoperation = DataBaseOperation.none;
        }//frmFactory_Load
        //---------------------------------------------------------------------
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentoperation = DataBaseOperation.Create;
            grbEntery.Visible = true;
            grbListItems.Visible = true;
            openToolStripMenuItem.Checked = true;
            Load_List_of_Product();
        }//newToolStripMenuItem_Click
        //---------------------------------------------------------------------
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openToolStripMenuItem.Checked)
            {
                grbListItems.Visible = false;
                openToolStripMenuItem.Checked = false;
            }//if already open
            else if (!openToolStripMenuItem.Checked) {
                Load_List_of_Product();
                grbListItems.Visible = true;
                openToolStripMenuItem.Checked = true;
            }//if Closed            
        }//openToolStripMenuItem_Click
        //---------------------------------------------------------------------
        private void clear_entery() {
            txtProductID.Clear();
            txtProductName.Clear();
            txtProductWeight.Clear();
            txtProductColor.Clear();
        }//clear_entery
        //---------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear_entery();
            grbEntery.Visible = false;
            grbListItems.Visible = false;
            openToolStripMenuItem.Checked = false;
        }//btnCancel_Click
        bool check_data_entery_for_product() {
            bool result = false;
            if (txtProductName.Text.Length > 0) {
                if (txtProductWeight.Text.Length > 0) {
                    if (txtProductColor.Text.Length > 0) {
                        result = true;
                    }//if color is entered
                }//if weight is entered 
            }//if name is entered
            return result;
        }//check_data_entery_for_product
        //---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strTitle, strMessage;
            strTitle = Properties.Resources.ProgramTitle;
            strMessage = "";
            if (check_data_entery_for_product()) {
                if (check_Weight_numeric())
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
                    else if (currentoperation == DataBaseOperation.Update) {

                    }//if an edit operation is in progress
                }//if numeric
                else {
                    strMessage = "Please check weigth, numeric value is required";
                    MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }//else if weight is not numeric
            }//if All data fields are filled in 
            else {
                strMessage = "Please fill in all fields";
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//else if there is fata missing
        }//btnSave_Click
        //---------------------------------------------------------------------
        private bool check_Weight_numeric() {
            bool result = false;
            double weight;
            if (double.TryParse(txtProductWeight.Text, out weight)) {
                result = true;
            }//if weight is numeric
            return result;
        }//check_Weight_numeric
        //---------------------------------------------------------------------
        bool save_product_to_DataBase() {
            bool result = false;
            try
            {                
                string pn = txtProductName.Text.Trim();
                string pw = txtProductWeight.Text.Trim();
                string pc = txtProductColor.Text.Trim();
                string srtSQL = string.Format("Insert into tbl_product (ProductName,ProductWeight,ProductColor) values ('{0}','{1}','{2}')",pn,pw,pc);
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(srtSQL, sqlcon);
                int r=sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                if (r == 1) {
                    result = true;
                }//if one record is added                
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 1 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
            return result;
        }//save_product_to_DataBase
        //---------------------------------------------------------------------
        private void Load_List_of_Product() {
            try
            {
                string strsql = "Select * from tbl_product";
                SqlConnection sqlCon = new SqlConnection(strConnection);
                sqlCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(strsql, sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_product");
                dgvProduct.DataSource = ds.Tables["tbl_product"];              
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 2 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch
        }//Load_List_of_Product
        //---------------------------------------------------------------------
    }//Form
}//Factory