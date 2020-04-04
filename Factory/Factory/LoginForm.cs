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
    
    public partial class LoginForm : Form
    {
        public string strcon = "";
        public bool LoggegIN;
        public string username;
        public string loginTime;
        public string userType;

        public LoginForm()
        {
            InitializeComponent();
        }//LoginForm

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//btnExit_Click

        private void chkShowpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowpassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }//Show password
            else {
                txtPassword.PasswordChar = '*';
            }//Hide password
        }//chkShowpassword_CheckedChanged

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strMessage, strTitle;
            strTitle = Properties.Resources.ProgramTitle;
            if (check_form_entry()) {                
                SqlConnection sqlcon = new SqlConnection(strcon);
                sqlcon.Open();
                string strsql = string.Format("select * from tbl_user where username='{0}' and userpassword='{1}' and userIsActive='True'", txtUserName.Text.Trim(),txtPassword.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(strsql, sqlcon);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblUser");
                sqlcon.Close();
                string tmp = "";
                int result = ds.Tables["tblUser"].Rows.Count;
                if (result == 1) {
                    tmp = ds.Tables["tblUser"].Rows[0]["usertypeID"].ToString();
                    switch (tmp)
                    {
                        case "1":
                            userType = "Admin";
                            break;
                        case "2":
                            userType = "Sells manager";
                            break;
                        case "3":
                            userType = "Clerck";
                            break;                            
                        default:
                            break;
                    }//switch
                    LoggegIN = true;
                    username = txtUserName.Text;
                    loginTime = DateTime.Now.ToString();
                    this.Close();
                }//if user exists
                else {
                    strMessage = "Check data and try again, and check if your account is active :-)";
                    MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }//else if username and password are wrong
                
            }//if username and password are entered 
            else {
                strMessage = "Please fill in all data";
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//else missing username and password in form 
        }//btnLogin_Click
        private bool check_form_entry() {
            bool result = false;            
            if ((txtUserName.Text.Length > 0) && (txtPassword.Text.Length > 0)) {
                result = true;
            }//if all information are entered 
            return result;
        }//check_form_entry
    }//public partial class LoginForm : Form
}//Factory
