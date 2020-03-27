using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factory
{
    public partial class frmFactory : Form
    {
        public frmFactory()
        {
            InitializeComponent();
        }//frmFactory

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }//exitToolStripMenuItem_Click

        private void frmFactory_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.ProgramTitle;
        }//frmFactory_Load
    }//Form
}//Factory
