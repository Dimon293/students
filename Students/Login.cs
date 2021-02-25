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
    public class UserAdmin : User
    {
        public UserAdmin(DataTable adt)
        {
            this.UserID = int.Parse( adt.Rows[0].ItemArray[0].ToString());
            this.Username = adt.Rows[0].ItemArray[1].ToString();
            this.TypeUser = int.Parse(adt.Rows[0].ItemArray[2].ToString());
        }
    }

    public class UserTeacher : User
    {
        public UserTeacher(DataTable adt)
        {
            this.UserID = int.Parse(adt.Rows[0].ItemArray[0].ToString());
            this.Username = adt.Rows[0].ItemArray[1].ToString();
            this.TypeUser = int.Parse(adt.Rows[0].ItemArray[2].ToString());
        }
    }

    public class UserGuest : User
    {
        public UserGuest(DataTable adt)
        {
            this.UserID = int.Parse(adt.Rows[0].ItemArray[0].ToString());
            this.Username = adt.Rows[0].ItemArray[1].ToString();
            this.TypeUser = int.Parse(adt.Rows[0].ItemArray[2].ToString());
        }
    }

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            string log = textBoxLog.Text;
            string pas = textBoxPas.Text;
            DataTable dt = DBStatements.ExecuteWithCallback($"SELECT id, name, Access FROM User WHERE Login = '{log}' AND Password = '{pas}'");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0].ItemArray[2].ToString() == "1")
                { // вход администратора
                    Hide();
                    UserAdmin user = new UserAdmin(dt);

                    fmAdmin main = new fmAdmin(user.GetUsername());
                    main.Owner = this;
                    main.ShowDialog();
                    
                }
                if (dt.Rows[0].ItemArray[2].ToString() == "2")
                { // вход преподавателя
                    Hide();
                    UserTeacher user = new UserTeacher(dt);
                    fmStudentAddMark main = new fmStudentAddMark(user.UserID ,user.GetUsername());
                    main.Owner = this;
                    main.ShowDialog();
                }
                if (dt.Rows[0].ItemArray[2].ToString() == "3")
                { // вход гостя
                    Hide();
                    UserGuest user = new UserGuest(dt);
                    fmViewMark main = new fmViewMark( user.GetUsername());
                    main.Owner = this;
                    main.ShowDialog();
                }


                this.Close();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            Hide();
            fmViewMark main = new fmViewMark("Гость");
            main.Owner = this;
            main.ShowDialog();
            this.Close();
        }
    }
}
