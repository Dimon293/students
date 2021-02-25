using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class fmInputBox : Form
    {
        public string returnString;

        public  fmInputBox(string str)
        {
            InitializeComponent();
            tb.Text = str;
        }
       
        private void btCansel_Click(object sender, EventArgs e)
        {
            returnString = string.Empty;
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            returnString = tb.Text;
            Close();
        }

        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btSave_Click(sender, e);
            if (e.KeyCode == Keys.Escape) btCansel_Click(sender, e);
        }
    }
}
