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
    public partial class fmAddEdtSemestrSubjectsControl : Form
    {
        public int returnidcontrl;
        List<int> listcontrl = new List<int>();
        
        DBStatements statements;
        public fmAddEdtSemestrSubjectsControl(DBStatements astatements, string acontrl)
        {
            statements = astatements;      
            InitializeComponent();
            UpdateComboBoxNames(cb1, listcontrl, statements.GetTypesOfControl());
           
            cb1.Text = acontrl;
        }
        void UpdateComboBoxNames(ComboBox comboBox, List<int> listResults, DataTable table)
        {
            listResults.Clear();
            comboBox.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i]["Name"].ToString();
                int id = Convert.ToInt32(table.Rows[i][0].ToString());

                comboBox.Items.Add(name);
                listResults.Add(id);
            }
            if (comboBox.Items.Count > 0)
                comboBox.Select(0, 1);
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            returnidcontrl = listcontrl[cb1.SelectedIndex];
            Close();
        }

        private void btCansel_Click(object sender, EventArgs e)
        {
            returnidcontrl =0;
            Close();
        }
    }
}
