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
    public partial class fmAdmin : Form
    {
        
        DBStatements statements = new DBStatements();
        List<int> listFaculties = new List<int>();
        List<int> listChairs = new List<int>();
        List<int> listSpecialties = new List<int>();
        List<int> listGroups = new List<int>();

        public fmAdmin(string afio)
        {
            InitializeComponent();
            this.Text =  "Пользователь - "+ afio;
            statements.ConnectionString = $"Data Source={DBStatements.DbFilePath};Version=3;foreign_keys = ON;";

            UpdateUserTable();
        }

        public void UpdateUserTable()
        {
            statements.GetTable(dgvUser, "SELECT u.id as 'Код', u.Name as 'ФИО', ua.name  as 'Доступ' , u.login as 'Логин', u.password as 'Пароль' FROM User  u inner join useraccess  ua on u.access = ua.id");
        }

        public void UpdateSubjectTable()
        {
            statements.GetTable(dgvSubjects, "SELECT id as 'Код', name as 'Название' FROM SubjectsName");
        }

        public void UpdateSemestrTable()
        {
            statements.GetTable(dgvSemestr, "SELECT id as 'Код', name as 'Название' FROM Semestr");
        }

        public void UpdateControlsTable()
        {
            statements.GetTable(dgvControls, "SELECT id as 'Код', name as 'Название' FROM TypesOfControl");
        }

        public void UpdateFacultiesTable()
        {
            statements.GetTable(dgvFaculties, "SELECT id as 'Код', name as 'Название факультетов' FROM Faculties");
            if (dgvFaculties.RowCount > 0)
                UpdateChairsTable(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString());
        }

        public void UpdateChairsTable(string str)
        {
            statements.GetTable(dgvChairs, $"SELECT id as 'Код', name as 'Название кафедры' FROM Chairs where idFaculty = '{str}'");
            if (dgvChairs.RowCount > 0)
                UpdateSpecialtiesTable(this.dgvChairs.CurrentRow.Cells[0].Value.ToString());
        }

        public void UpdateSpecialtiesTable(string str)
        {
            statements.GetTable(dgvSpecialties, $"SELECT id as 'Код', name as 'Название специальности' FROM Specialties where idChair = '{str}'");
        }

        public void UpdateGroupsTable(string astr)
        {
            statements.GetTable(dgvGroups, "SELECT g.id as 'Код', g.name as 'Название групп' FROM Groups g"+ astr);
            if (dgvGroups.RowCount >0)
                UpdateStudentsTable(this.dgvGroups.CurrentRow.Cells[0].Value.ToString());
            else UpdateStudentsTable("0");
        }

        public void UpdateStudentsTable(string astr)
        {
            statements.GetTable(dgvStudents, "SELECT s.id as 'Код', s.fio as 'Фамилия' , s.Gender as 'Пол', Address as 'Адрес', Phone  as 'Телефон' FROM Students s where idGroup= " + astr);
        }

        public void UpdateGroupsPrTable()
        {
            statements.GetTable(dgvGroupPr, "SELECT g.id as 'Код', g.name as 'Название групп' FROM Groups g");
                if (dgvGroupPr.RowCount > 0)
                    UpdateSemestrSubjectTable(this.dgvGroupPr.CurrentRow.Cells[0].Value.ToString());
                else UpdateSemestrSubjectTable("0");
        }

        public void UpdateSemestrSubjectTable(string str)
        {
            statements.GetTable(dgvSemestrSubject, "SELECT ss.id as 'Код', s.name as 'Название семестра', sn.name as 'Название предмета', u.name as 'ФИО преподавателя' FROM SemestrSubject ss" +
                " inner join Semestr s on ss.idSemestr=s.id" +
                " inner join SubjectsName sn on ss.idSubjects=sn.id" +
                " inner join User u on ss.idUser=u.id"
                + " where idGroups = " + str);
            if (dgvSemestrSubject.RowCount > 0)
                UpdateSemesttSubjectsControlTable(this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString());
            else UpdateSemesttSubjectsControlTable("0");
        }

        public void UpdateSemesttSubjectsControlTable(string str)
        {
            if (dgvSemestrSubject.RowCount > 0  )
            statements.GetTable(dgvSemesttSubjectsControl, "SELECT ss.id as 'Код',с.name as 'Название проверочной работы' " +
                "FROM SemesttSubjectsControl ss" +
                " inner join TypesOfControl с on ss.idTypeOfControl=с.id"
                + " where idSemestrSubject = " + str);
            else statements.GetTable(dgvSemesttSubjectsControl, "SELECT ss.id as 'Код',с.name as 'Название проверочной работы' " +
                "FROM SemesttSubjectsControl ss" +
                " inner join TypesOfControl с on ss.idTypeOfControl=с.id"
                + " where idSemestrSubject = 0 ");
        }

        // обработка выбора закладок
        private void dgvControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvControl.SelectedIndex == 0)
                {
                    UpdateUserTable();
                }
                if (dgvControl.SelectedIndex == 1)
                {
                    UpdateSubjectTable();
                }
                if (dgvControl.SelectedIndex == 2)
                {
                    UpdateSemestrTable();
                }
                if (dgvControl.SelectedIndex == 3)
                {
                    UpdateControlsTable();
                }
                if (dgvControl.SelectedIndex == 4)
                {
                    UpdateFacultiesTable();
                    if (dgvFaculties.RowCount > 0)
                    {
                        UpdateChairsTable(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString());
                        if (dgvChairs.RowCount > 0) UpdateSpecialtiesTable(this.dgvChairs.CurrentRow.Cells[0].Value.ToString());
                    }
                }
                if (dgvControl.SelectedIndex == 5)
                {
                    UpdateComboBoxNames(comboBoxFaculties, listFaculties, statements.GetFaculties());
                }

                if (dgvControl.SelectedIndex == 6)
                {
                    UpdateGroupsPrTable(); //dgvGroupPr
                    if (dgvGroupPr.RowCount > 0)
                    {
                        UpdateSemestrSubjectTable(this.dgvGroupPr.CurrentRow.Cells[0].Value.ToString());
                        if (dgvSemestrSubject.RowCount > 0)
                        {
                            UpdateSemesttSubjectsControlTable(this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        // Работа со списком пользователей
        private void btDelUser_Click(object sender, EventArgs e)
        {
            if (this.dgvUser.RowCount > 0)
            {
                string log = (this.dgvUser.CurrentRow.Cells[0].Value).ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	User  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateUserTable();
            }
        }
        private void btAddUser_Click(object sender, EventArgs e)
        {
            fmAddEdtUser fmedit = new fmAddEdtUser(statements, 0,0,"","","","");
            fmedit.Owner = this;
            fmedit.ShowDialog();
            UpdateUserTable();
            }
        private void btEdtUser_Click(object sender, EventArgs e)
        {
            fmAddEdtUser fmedit = new fmAddEdtUser(statements, 0, int.Parse( this.dgvUser.CurrentRow.Cells[0].Value.ToString())
                                        , this.dgvUser.CurrentRow.Cells[1].Value.ToString()
                                        , this.dgvUser.CurrentRow.Cells[3].Value.ToString()
                                        , this.dgvUser.CurrentRow.Cells[4].Value.ToString()
                                        , this.dgvUser.CurrentRow.Cells[2].Value.ToString());
            fmedit.Owner = this;
            fmedit.ShowDialog();
            UpdateUserTable();
        }
        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(this.dgvUser.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtUser_Click(sender, e);
                else btAddUser_Click(sender, e);
            }
            catch
            {
                btAddUser_Click(sender, e);
            }


        }
        
        // Работа со списком предметов
        private void btAddSubject_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox("");
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"insert into SubjectsName (name) values('{fmedit.returnString}')");
            }
            UpdateSubjectTable();
        }
        private void btedtSubject_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox(this.dgvSubjects.CurrentRow.Cells[1].Value.ToString());
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"update SubjectsName set name = '{fmedit.returnString}' where id = '{int.Parse(this.dgvSubjects.CurrentRow.Cells[0].Value.ToString())}'");
            }
            UpdateSubjectTable();
        }
        private void btDelSubject_Click(object sender, EventArgs e)
        {
            if (this.dgvSubjects.RowCount > 0)
            {
                string log = this.dgvSubjects.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	SubjectsName  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateSubjectTable();
            }
        }
        private void dgvSubjects_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(this.dgvSubjects.CurrentRow.Cells[0].Value.ToString()) > 0) btedtSubject_Click(sender, e);
                else btAddSubject_Click(sender, e);
            }
            catch
            {
                btAddSubject_Click(sender, e);
            }
        }

        // Работа со списком семестров
        private void btAddsemestr_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox("");
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"insert into Semestr (name) values('{fmedit.returnString}')");
            }
            UpdateSemestrTable();
        }
        private void btEdtsemestr_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox(this.dgvSemestr.CurrentRow.Cells[1].Value.ToString());
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"update Semestr set name = '{fmedit.returnString}' where id = '{int.Parse(this.dgvSemestr.CurrentRow.Cells[0].Value.ToString())}'");
            }
            UpdateSemestrTable();
        }
        private void btDelsemestr_Click(object sender, EventArgs e)
        {
            if (this.dgvSemestr.RowCount > 0)
            {
                string log = this.dgvSemestr.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	Semestr  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateSemestrTable();
            }
        }
        private void dgvSemestr_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(this.dgvSemestr.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtsemestr_Click(sender, e);
                else btAddsemestr_Click(sender, e);
            }
            catch 
            {
                btAddsemestr_Click(sender, e);
            }
        }

        // Работа с типами проверок
        private void btAddControl_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox("");
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"insert into TypesOfControl (name) values('{fmedit.returnString}')");
            }
            UpdateControlsTable();
        }
        private void btEdtControl_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox(this.dgvControls.CurrentRow.Cells[1].Value.ToString());
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"update TypesOfControl set name = '{fmedit.returnString}' where id = '{int.Parse(this.dgvControls.CurrentRow.Cells[0].Value.ToString())}'");
            }
            UpdateControlsTable();
        }
        private void btDelControl_Click(object sender, EventArgs e)
        {
            if (this.dgvControls.RowCount > 0)
            {
                string log = this.dgvControls.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	TypesOfControl  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateControlsTable();
            }
        }
        private void dgvControls_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(this.dgvControls.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtControl_Click(sender, e);
                else btAddControl_Click(sender, e);
            }
            catch
            {
                btAddControl_Click(sender, e);
            }
        }
        
        // Работа с факультетами
        private void btAddFaculties_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox("");
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"insert into Faculties (name) values('{fmedit.returnString}')");
            }
            UpdateFacultiesTable();
        }
        private void btEdtFaculties_Click(object sender, EventArgs e)
        {
            fmInputBox fmedit = new fmInputBox(this.dgvFaculties.CurrentRow.Cells[1].Value.ToString());
            fmedit.Owner = this;
            fmedit.ShowDialog();
            if (fmedit.returnString != "")
            {
                statements.SqlInsertUpdate($"update Faculties set name = '{fmedit.returnString}' where id = '{int.Parse(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString())}'");
            }
            UpdateFacultiesTable();
        }
        private void btDelFaculties_Click(object sender, EventArgs e)
        {
            if (this.dgvFaculties.RowCount > 0)
            {
                string log = this.dgvFaculties.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	Faculties  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateFacultiesTable();
            }
        }
        private void dgvFaculties_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtFaculties_Click(sender, e);
                else btAddFaculties_Click(sender, e);
            }
            catch 
            {
                btEdtFaculties_Click(sender, e);
            }
        }
        private void dgvFaculties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFaculties.RowCount > 0)
            {
                UpdateChairsTable(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString());
                dgvChairs_CellClick(sender, e);
            }
        }

        // Работа со списком кафедр
        private void btAddChairs_Click(object sender, EventArgs e)
        {
            if (dgvFaculties.RowCount > 0)
            {
                fmInputBox fmedit = new fmInputBox("");
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnString != "")
                {
                    statements.SqlInsertUpdate($"insert into Chairs (name,idFaculty) values('{fmedit.returnString}','{this.dgvFaculties.CurrentRow.Cells[0].Value.ToString()}')");
                    UpdateChairsTable(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }
        private void btEdtChairs_Click(object sender, EventArgs e)
        {
            if (dgvFaculties.RowCount > 0 && this.dgvChairs.RowCount>0)
            {
                fmInputBox fmedit = new fmInputBox(this.dgvChairs.CurrentRow.Cells[1].Value.ToString());
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnString != "")
                {

                    statements.SqlInsertUpdate($"update Chairs set name = '{fmedit.returnString}' where id = '{this.dgvChairs.CurrentRow.Cells[0].Value.ToString()}'");
                    UpdateChairsTable(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString());
                }
            }

        }
        private void btDelChairs_Click(object sender, EventArgs e)
        {
            if (this.dgvChairs.RowCount > 0)
            {
                string log = this.dgvChairs.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	Chairs  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateChairsTable(this.dgvFaculties.CurrentRow.Cells[0].Value.ToString());
            }
        }
        private void dgvChairs_DoubleClick(object sender, EventArgs e)
        {

            if (dgvChairs.RowCount > 0)
            {
                try
                {
                    if (int.Parse(this.dgvChairs.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtChairs_Click(sender, e);
                    else btAddChairs_Click(sender, e);
                }
                catch 
                {
                    btEdtChairs_Click(sender, e);
                }
            }
        }
        private void dgvChairs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFaculties.RowCount > 0 && dgvChairs.RowCount>0)
            {
                UpdateSpecialtiesTable(this.dgvChairs.CurrentRow.Cells[0].Value.ToString());
            }
        }

        // Работа со списком специальностей
        private void btAddSpecialties_Click(object sender, EventArgs e)
        {
            if (dgvFaculties.RowCount > 0 && dgvChairs.RowCount > 0)
            {
                fmInputBox fmedit = new fmInputBox("");
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnString != "")
                {
                    statements.SqlInsertUpdate($"insert into Specialties (name,idChair) values('{fmedit.returnString}','{this.dgvChairs.CurrentRow.Cells[0].Value.ToString()}')");
                    UpdateSpecialtiesTable(this.dgvChairs.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }
        private void btEdtSpecialties_Click(object sender, EventArgs e)
        {
            if (dgvFaculties.RowCount > 0 && this.dgvChairs.RowCount > 0 && dgvSpecialties.RowCount > 0)
            {
                fmInputBox fmedit = new fmInputBox(this.dgvSpecialties.CurrentRow.Cells[1].Value.ToString());
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnString != "")
                {

                    statements.SqlInsertUpdate($"update Specialties set name = '{fmedit.returnString}' where id = '{this.dgvSpecialties.CurrentRow.Cells[0].Value.ToString()}'");
                    UpdateSpecialtiesTable(this.dgvChairs.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }
        private void btDelSpecialties_Click(object sender, EventArgs e)
        {
            if (this.dgvSpecialties.RowCount > 0)
            {
                string log = this.dgvSpecialties.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	Specialties  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateSpecialtiesTable(this.dgvChairs.CurrentRow.Cells[0].Value.ToString());
            }
        }
        private void dgvSpecialties_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSpecialties.RowCount > 0)
            {
                try
                {
                    if (int.Parse(this.dgvSpecialties.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtSpecialties_Click(sender, e);
                    else btAddSpecialties_Click(sender, e);
                }
                catch
                {
                    btEdtSpecialties_Click(sender, e);
                }
            }
        }

        // Работа со списком групп
        private void btAddGroups_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecialties.Text != string.Empty)
            {
                fmInputBox fmedit = new fmInputBox("");
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnString != "")
                {
                    statements.SqlInsertUpdate($"insert into Groups (name,idSpetialty) values('{fmedit.returnString}','{listSpecialties[comboBoxSpecialties.SelectedIndex].ToString()}')");
                    UpdateGroupsTable(" inner join Specialties s on s.id= g.idSpetialty where s.name='" + comboBoxSpecialties.Text + "'");
                }
            }
        }

        private void btEdtGroups_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecialties.Text != string.Empty && this.dgvGroups.RowCount > 0)
            {
                fmInputBox fmedit = new fmInputBox(this.dgvGroups.CurrentRow.Cells[1].Value.ToString());
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnString != "")
                {
                    statements.SqlInsertUpdate($"update Groups set name = '{fmedit.returnString}' where id = '{this.dgvGroups.CurrentRow.Cells[0].Value.ToString()}'");
                    UpdateGroupsTable(" inner join Specialties s on s.id= g.idSpetialty where s.name='" + comboBoxSpecialties.Text + "'");
                }
            }
        }

        private void btDelGroups_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecialties.Text != string.Empty && this.dgvGroups.RowCount > 0)
            {
                string log = this.dgvGroups.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	Groups  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateGroupsTable(" inner join Specialties s on s.id= g.idSpetialty where s.name='" + comboBoxSpecialties.Text + "'");

            }
        }

        private void dgvGroups_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGroups.RowCount > 0)
            {
                try
                {
                    if (int.Parse(this.dgvGroups.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtGroups_Click(sender, e);
                    else btAddGroups_Click(sender, e);
                }
                catch
                {
                    btEdtGroups_Click(sender, e);
                }
            }
        }
        private void dgvGroups_Click(object sender, EventArgs e)
        {
            if (dgvGroups.RowCount > 0)
            {
                UpdateStudentsTable(this.dgvGroups.CurrentRow.Cells[0].Value.ToString());
            }
        }

        // Работа со списком студентов
        private void btAddStudents_Click(object sender, EventArgs e)
        {
            if (dgvGroups.RowCount > 0 )
            {
                fmAddEdtStudent fmedit = new fmAddEdtStudent("","","","");
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnFIO != string.Empty)
                {
                    statements.SqlInsertUpdate($"insert into Students (fio,Gender,Address,Phone,idGroup) values('{fmedit.returnFIO}','{fmedit.returnGender}','{fmedit.returnAddress}','{fmedit.returnPhone}','{this.dgvGroups.CurrentRow.Cells[0].Value.ToString()}')");

                    UpdateStudentsTable(this.dgvGroups.CurrentRow.Cells[0].Value.ToString());
                 
                }
            }
        }

        private void btEdtStudents_Click(object sender, EventArgs e)
        {
            if (dgvGroups.RowCount > 0 && dgvStudents.RowCount > 0)
            {
                fmAddEdtStudent fmedit = new fmAddEdtStudent(this.dgvStudents.CurrentRow.Cells[1].Value.ToString(), this.dgvStudents.CurrentRow.Cells[2].Value.ToString()
                        , this.dgvStudents.CurrentRow.Cells[3].Value.ToString(), this.dgvStudents.CurrentRow.Cells[4].Value.ToString());
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnFIO != string.Empty)
                {
                    statements.SqlInsertUpdate($"update Students set fio = '{fmedit.returnFIO}',Gender = '{fmedit.returnGender}',Address = '{fmedit.returnAddress}',Phone = '{fmedit.returnPhone}' where id = '{this.dgvStudents.CurrentRow.Cells[0].Value.ToString()}'");
                    UpdateStudentsTable(this.dgvGroups.CurrentRow.Cells[0].Value.ToString());

                }
            }
        }

        private void btDelStudents_Click(object sender, EventArgs e)
        {
            if (dgvStudents.RowCount>0)
            {
                string log = this.dgvStudents.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	Students  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateStudentsTable(this.dgvGroups.CurrentRow.Cells[0].Value.ToString());

            }
        }

        private void dgvStudents_DoubleClick(object sender, EventArgs e)
        {
            if (dgvStudents.RowCount > 0)
            {
                try
                {
                    if (int.Parse(this.dgvStudents.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtStudents_Click(sender, e);
                    else btAddStudents_Click(sender, e);
                }
                catch
                {
                    btEdtStudents_Click(sender, e);
                }
            }
        }

        // список групп для предметов
        private void dgvGroupPr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSemestrSubjectTable(this.dgvGroupPr.CurrentRow.Cells[0].Value.ToString());
        }

        // список предметов в группе
        private void btAddSemestrSubject_Click(object sender, EventArgs e)
        {
            if (dgvGroupPr.RowCount > 0)
            {
                fmAddEdtGroupSubject fmedit = new fmAddEdtGroupSubject(statements,"", "", "");
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnidSemestr!= 0)
                {
                    statements.SqlInsertUpdate($"insert into SemestrSubject (idGroups,idSemestr,idSubjects,idUser)" +
                        $" values('{this.dgvGroupPr.CurrentRow.Cells[0].Value.ToString()}','{fmedit.returnidSemestr.ToString()}'" +
                        $",'{fmedit.returnidSubjects.ToString()}','{fmedit.returnUser.ToString()}')");

                    UpdateSemestrSubjectTable(this.dgvGroupPr.CurrentRow.Cells[0].Value.ToString());

                }
            }
        }

        private void btEdtSemestrSubject_Click(object sender, EventArgs e)
        {
            if (dgvGroupPr.RowCount > 0 && dgvSemestrSubject.RowCount>0)
            {
                fmAddEdtGroupSubject fmedit = new fmAddEdtGroupSubject(statements, 
                    this.dgvSemestrSubject.CurrentRow.Cells[1].Value.ToString(),
                    this.dgvSemestrSubject.CurrentRow.Cells[2].Value.ToString(),
                        this.dgvSemestrSubject.CurrentRow.Cells[3].Value.ToString());
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnidSemestr != 0)
                {
                    statements.SqlInsertUpdate($"update SemestrSubject set idSemestr = '{fmedit.returnidSemestr.ToString()}'" +
                                $",idSubjects = '{fmedit.returnidSubjects.ToString()}'" +
                                $",idUser = '{fmedit.returnUser.ToString()}' where id = '{this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString()}'");
                    UpdateSemestrSubjectTable(this.dgvGroupPr.CurrentRow.Cells[0].Value.ToString());

                }
            }
        }

        private void btDelSemestrSubject_Click(object sender, EventArgs e)
        {
            if (dgvSemestrSubject.RowCount > 0)
            {
                string log = this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	SemestrSubject  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateSemestrSubjectTable(this.dgvGroupPr.CurrentRow.Cells[0].Value.ToString());

            }
        }

        private void dgvSemestrSubject_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSemestrSubject.RowCount > 0)
            {
                try
                {
                    if (int.Parse(this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtSemestrSubject_Click(sender, e);
                    else btAddSemestrSubject_Click(sender, e);
                }
                catch 
                {
                    btEdtSemestrSubject_Click(sender, e);
                }
            }
        }
        private void dgvSemestrSubject_Click(object sender, EventArgs e)
        {
            if (dgvSemestrSubject.RowCount>0 )
                UpdateSemesttSubjectsControlTable(this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString());
        }

        /// Настройка списка контроля по предмету
        private void btAddSemesttSubjectsControl_Click(object sender, EventArgs e)
        {
            if (dgvSemestrSubject.RowCount > 0)
            {
                fmAddEdtSemestrSubjectsControl fmedit = new fmAddEdtSemestrSubjectsControl(statements, "");
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnidcontrl != 0)
                {
                    statements.SqlInsertUpdate($"insert into SemesttSubjectsControl (idSemestrSubject,idTypeOfControl)" +
                        $" values('{this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString()}','{fmedit.returnidcontrl.ToString()}')");
                    
                    UpdateSemesttSubjectsControlTable(this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }

        private void btEdtSemesttSubjectsControl_Click(object sender, EventArgs e)
        {
            if (dgvSemestrSubject.RowCount > 0 && dgvSemesttSubjectsControl.RowCount > 0)
            {
                fmAddEdtSemestrSubjectsControl fmedit = new fmAddEdtSemestrSubjectsControl(statements, this.dgvSemesttSubjectsControl.CurrentRow.Cells[1].Value.ToString());
                fmedit.Owner = this;
                fmedit.ShowDialog();
                if (fmedit.returnidcontrl != 0)
                {
                    statements.SqlInsertUpdate($"update SemesttSubjectsControl set idTypeOfControl = '{fmedit.returnidcontrl.ToString()}'" +
                                    $"  where id = '{this.dgvSemesttSubjectsControl.CurrentRow.Cells[0].Value.ToString()}'");
                    
                        UpdateSemesttSubjectsControlTable(this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }

        private void btDelSemesttSubjectsControl_Click(object sender, EventArgs e)
        {
            if (dgvSemesttSubjectsControl.RowCount > 0)
            {
                string log = this.dgvSemesttSubjectsControl.CurrentRow.Cells[0].Value.ToString();
                // удаляем запись
                statements.SqlDelete($" delete	from	SemesttSubjectsControl  where   ID = '{log}' ");
                // обновляем таблицу
                UpdateSemesttSubjectsControlTable(this.dgvSemestrSubject.CurrentRow.Cells[0].Value.ToString());

            }
        }

        private void dgvSemesttSubjectsControl_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSemestrSubject.RowCount > 0)
            {
                try
                {
                    if (int.Parse(this.dgvSemesttSubjectsControl.CurrentRow.Cells[0].Value.ToString()) > 0) btEdtSemesttSubjectsControl_Click(sender, e);
                    else btAddSemesttSubjectsControl_Click(sender, e);
                }
                catch
                {
                    btEdtSemesttSubjectsControl_Click(sender, e);
                }
            }
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

        private void comboBoxFaculties_SelectedIndexChanged(object sender, EventArgs e)
        {
                comboBoxChairs.Text = string.Empty;
                comboBoxSpecialties.Text = string.Empty;
                UpdateComboBoxNames(comboBoxChairs, listChairs, statements.GetChairs(" inner join Faculties f on c.idFaculty=f.id where f.name = '" + comboBoxFaculties.Text + "'"));
                UpdateGroupsTable(" inner join Specialties s on s.id= g.idSpetialty where s.name='" + comboBoxSpecialties.Text + "'");
        }

        private void comboBoxChairs_SelectedIndexChanged(object sender, EventArgs e)
        {
                comboBoxSpecialties.Text = string.Empty;
                UpdateComboBoxNames(comboBoxSpecialties, listSpecialties, statements.GetSpecialties(" inner join Chairs c on c.id=s.idChair where c.name = '" + comboBoxChairs.Text + "'"));
                UpdateGroupsTable(" inner join Specialties s on s.id= g.idSpetialty where s.name='" + comboBoxSpecialties.Text + "'");
        }

        private void comboBoxSpecialties_SelectedIndexChanged(object sender, EventArgs e)
        {
                UpdateGroupsTable(" inner join Specialties s on s.id= g.idSpetialty where s.name='"+ comboBoxSpecialties.Text+"'");
        }
    }
}
