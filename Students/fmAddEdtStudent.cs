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
    public partial class fmAddEdtStudent : Form
    {
        public string returnFIO, returnGender, returnAddress, returnPhone;
        
        public fmAddEdtStudent(string afio, string aGender, string aAddress, string aPhone)
        {
            InitializeComponent();
            tb1.Text = afio;
            tb2.Text = aGender;
            tb3.Text = aAddress;
            tb4.Text = aPhone;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            returnFIO = tb1.Text;
            returnGender= tb2.Text;
            returnAddress = tb3.Text;
            returnPhone = tb4.Text;
            Close();
        }

        private void btCansel_Click(object sender, EventArgs e)
        {
            returnFIO = string.Empty;
            returnGender = string.Empty;
            returnAddress = string.Empty;
            returnPhone = string.Empty;
            Close();
        }
    }
}
