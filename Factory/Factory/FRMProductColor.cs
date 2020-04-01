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
    public partial class FRMProductColor : Form
    {
        public FRMProductColor()
        {
            InitializeComponent();
        }

        private void FRMProductColor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'factory_DataBaseDataSet.tbl_Color' table. You can move, or remove it, as needed.
            this.tbl_ColorTableAdapter.Fill(this.factory_DataBaseDataSet.tbl_Color);

        }
    }
}
