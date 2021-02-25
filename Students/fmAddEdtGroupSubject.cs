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
    public partial class fmAddEdtGroupSubject : Form
    {
        public int returnidSemestr, returnidSubjects, returnUser;
        List<int> listSemestr = new List<int>();
        List<int> listSubjectsName = new List<int>();
        List<int> listUser = new List<int>();
        DBStatements statements;

        public fmAddEdtGroupSubject(DBStatements astatements,string asem, string asub, string auser)
        {
            InitializeComponent();
            statements = astatements;
            UpdateComboBoxNames(cb1, listSemestr, statements.GetSemestr());
            UpdateComboBoxNames(cb2, listSubjectsName, statements.GetSubjects());
            UpdateComboBoxNames(cb3, listUser, statements.GetUser());

            cb1.Text = asem;
            cb2.Text = asub;
            cb3.Text = auser;
        }

        

        //Обновление combobox
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
            returnidSemestr= listSemestr[cb1.SelectedIndex];
            returnidSubjects = listSubjectsName[cb2.SelectedIndex]; ;
            returnUser = listUser[cb3.SelectedIndex]; ;
            Close();
        }

        private void btCansel_Click(object sender, EventArgs e)
        {
            returnidSemestr = 0; returnidSubjects = 0; returnUser = 0;
            Close();
        }
    }
}
