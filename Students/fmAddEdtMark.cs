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
    public partial class fmAddEdtMark : Form
    {
        public string returnmark;
        public string returndate;
        public int returnsave; //0 - отмена, 1- подтверждение
        public fmAddEdtMark(string fio, string strmark, string strdate)
        {
            returnsave = 0;
            InitializeComponent();
            this.Text = fio;
          
            tbmark.Text = strmark;

            if (strdate != string.Empty)
                dtpDate.Text = strdate;
            else dtpDate.Value = DateTime.Today;

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            returnmark = tbmark.Text;
            if (returnmark != string.Empty)
                returndate = dtpDate.Text;
            else returndate = string.Empty;
            returnsave = 1;
            Close();
        }

        private void btCansel_Click(object sender, EventArgs e)
        {
            returnmark = string.Empty;
            returndate = string.Empty;
            Close();
        }

        private void tbmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btSave_Click(sender, e);
            if (e.KeyCode == Keys.Escape) btCansel_Click(sender, e);
        }

        private void tbmark_TextChanged(object sender, EventArgs e)
        {
            string s = tbmark.Text;
            if(s.Length > 1)
            {
                MessageBox.Show("Некорректная оценка");
                tbmark.Text = string.Empty;
            }
            if(!s.Contains("2") && !s.Contains("3") && !s.Contains("4") && !s.Contains("5") && s!=string.Empty)
            {
                MessageBox.Show("Некорректная оценка");
                tbmark.Text = string.Empty;
            }
        }
    }
}
