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
    public partial class fmAddEdtUser : Form
    {
        List<int> listUserAccess = new List<int>();
        public int add_edt; // 0- добавление , 1-редактирование
        public int userid;
        public string fio, login, pass, access;
        DBStatements statements;
        public fmAddEdtUser(DBStatements astatements, int aadd_edt,int auserid, string afio, string alogin, string apass, string aaccess)
        {
            statements = astatements;
            add_edt = aadd_edt;
            userid = auserid;
            fio = afio; login = alogin; pass = apass; access= aaccess;
            
            InitializeComponent();
            tbFIO.Text = fio;
            tbLogin.Text = login;
            tbPass.Text = pass;

            UpdateComboBoxNames(cbAccess, listUserAccess, statements.GetAccess());

            if (access != "") cbAccess.SelectedText = access;
            else cbAccess.Text = "";
       }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbAccess.Text == "") return;
            var i = cbAccess.SelectedIndex+1;

            if (userid > 0)
            {
                statements.SqlInsertUpdate($"update user set name = '{tbFIO.Text}', login = '{tbLogin.Text}', password ='{tbPass.Text}',access = '{i.ToString()}' where id = '{userid.ToString()}'");
            }
            else
            {
                statements.SqlInsertUpdate($"insert into user (name,login,password,access) values('{tbFIO.Text}', '{tbLogin.Text}','{tbPass.Text}',{i.ToString()})");  
            }
            Close();
        }

        void UpdateComboBoxNames(ComboBox comboBox, List<int> listResults, DataTable table)
        {
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

        private void btCansel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
