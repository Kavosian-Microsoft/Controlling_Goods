using System;
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
        public string strConnection = "";
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
            // TODO: This line of code loads data into the 'factory_DataBaseDataSet.tbl_Color' table. You can move, or remove it, as needed.
            this.tbl_ColorTableAdapter.Fill(this.factory_DataBaseDataSet.tbl_Color);
            this.Text = Properties.Resources.ProgramTitle;
            strConnection = "Data Source=KAVOSIAN-PC10\\SQL2K14;Initial Catalog=Factory_DataBase;Integrated Security=True";
            currentoperation = DataBaseOperation.none;
            LoginForm login = new LoginForm();
            login.strcon = strConnection;
            login.ShowDialog();
            login.Focus();
            if (login.LoggegIN) {
                string strtitle = "";
                strtitle = Properties.Resources.ProgramTitle + "  UserName:" + login.username + "  User Type :" + login.userType + "  Loging Time:" + login.loginTime;
                this.Text = strtitle;
            }//if user is logged in
            else {
                this.Close();
            }//else if login is unseccessful
        }//frmFactory_Load
        //---------------------------------------------------------------------
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentoperation = DataBaseOperation.Create;
            grbEntery.Visible = true;
            grbListItems.Visible = true;
            openToolStripMenuItem.Checked = true;
            btnDelete.Visible = false;
            btnSave.Visible = true;
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
            //txtProductColor.Clear();
            cmbProductColor.Text = "";
        }//clear_entery
        //---------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear_entery();
            grbEntery.Visible = false;
            grbListItems.Visible = false;
            openToolStripMenuItem.Checked = false;
            btnSave.Visible = true;
            btnDelete.Visible = false;
            currentoperation = DataBaseOperation.none;
        }//btnCancel_Click
        bool check_data_entery_for_product() {
            bool result = false;
            if (txtProductName.Text.Length > 0) {
                if (txtProductWeight.Text.Length > 0) {
                    if (cmbProductColor.Text.Length > 0) {
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
                    if (check_existanse()) {
                        strMessage = "The record already exists";                        
                        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }//if record exists
                    else {
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
                //string pc = txtProductColor.Text.Trim();
                int pc = int.Parse(cmbProductColor.SelectedValue.ToString());
                string srtSQL = string.Format("Insert into tbl_product (ProductName,ProductWeight,ProductColor) values ('{0}','{1}',{2})",pn,pw,pc);
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
                //string strsql = "Select * from tbl_product";
                string strsql = "select * from tbl_product inner join tbl_Color on tbl_product.ProductColor=tbl_Color.ColorID";
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
        private void EditProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tbl_ColorTableAdapter.Fill(factory_DataBaseDataSet.tbl_Color);
            Load_List_of_Product();
            currentoperation = DataBaseOperation.Update;
            grbEntery.Visible = true;
            grbListItems.Visible = true;
            btnSave.Visible = true;
            btnDelete.Visible = false;
        }//EditProductToolStripMenuItem_Click
        //---------------------------------------------------------------------
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = dgvProduct.CurrentRow.Cells[0].Value.ToString();
            txtProductName.Text = dgvProduct.CurrentRow.Cells[1].Value.ToString();
            txtProductWeight.Text = dgvProduct.CurrentRow.Cells[2].Value.ToString();
            //txtProductColor.Text = dgvProduct.CurrentRow.Cells[3].Value.ToString();
            cmbProductColor.SelectedValue= dgvProduct.CurrentRow.Cells[3].Value.ToString();
        }//dgvProduct_CellClick
         //---------------------------------------------------------------------
        bool update_product_in_DataBase()
        {
            bool result = false;
            try
            {
                string pid = txtProductID.Text.Trim();
                string pn = txtProductName.Text.Trim();
                string pw = txtProductWeight.Text.Trim();
                int pc = int.Parse(cmbProductColor.SelectedValue.ToString());
                string srtSQL = string.Format("Update tbl_product set ProductName='{0}',ProductWeight={1},ProductColor={2}  where ProductID={3}", pn, pw, pc,pid);
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
        private bool check_existanse() {
            bool result = false;
            try
            {
                string strsql = string.Format("select count(*) from tbl_product where productName='{0}' and productweight={1} and productColor={2}",txtProductName.Text.Trim(),txtProductWeight.Text.Trim(),int.Parse(cmbProductColor.SelectedValue.ToString()));
                SqlConnection sqlcon = new SqlConnection(strConnection);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);
                int r = (int)sqlcmd.ExecuteScalar();
                sqlcon.Close();
                if (r > 0){
                    result = true;
                }//if record already exists
                
            }//try
            catch (Exception ex)
            {
                string strTitle, strMessage;
                strTitle = Properties.Resources.ProgramTitle;
                strMessage = "An exception has occured please contact the system administrator and inform exception No. 3 ";
                strMessage += "\nAnd following message \n " + ex.Message;
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//catch

            return result;
        }//check_existanse

        private void RemoveProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnDelete.Visible = true;
            Load_List_of_Product();
            currentoperation = DataBaseOperation.Delete;
            grbEntery.Visible = true;
            grbListItems.Visible = true;
        }//RemoveProductToolStripMenuItem_Click

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strTitle, strMessage;
            strTitle = Properties.Resources.ProgramTitle;
            strMessage = "";
            if (check_data_entery_for_product())
            {
                DialogResult res;
                strMessage = "Are you sure for removing the selected record";
                res = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) {
                    if (remove_record(int.Parse(txtProductID.Text.Trim())))
                    {
                        Load_List_of_Product();
                        clear_entery();
                        strMessage = "One record is removed";
                        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }//if it is OK to remove record 
                    else {
                        strMessage = "The record is not removed, check again please";
                        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }//else if removing was not completed 
                }//if yes is pressesd                
            }//if All data fields are filled in 
            else
            {
                strMessage = "Please select a record";
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//else if there is fata missing
        }//btnDelete_Click
        private bool remove_record(int PID) {
            bool result = false;
            string strsql = string.Format("Delete from tbl_product where ProductID={0}",PID);
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

        private void productColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMProductColor frm = new FRMProductColor();
            frm.strConnection = strConnection;
            frm.ShowDialog();
        }//productColorsToolStripMenuItem_Click
    }//Form
}//Factory
