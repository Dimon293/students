using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Students
{
    public partial class fmStudentAddMark : Form
    {
        DBStatements statements = new DBStatements();
        public int idUser;
       
        public fmStudentAddMark(int aidUser, string fio)
        {
            InitializeComponent();
            this.Text = "Преподаватель - " + fio;
            statements.ConnectionString = $"Data Source={DBStatements.DbFilePath};Version=3;foreign_keys = ON;";
            idUser = aidUser;

        }
        private void fmStudentdAddMark_Shown(object sender, EventArgs e)
        {
            UpdateUserTable(idUser.ToString());
        }
        
        public void UpdateUserTable(string str)
        {
            statements.GetTable(dgvSemestrSubjectMark, "SELECT ss.id as 'Код', sn.name as 'Название предмета',g.name as 'Группа', s.name as 'Название семестра' FROM SemestrSubject ss" +
               " inner join Semestr s on ss.idSemestr=s.id" +
               " inner join SubjectsName sn on ss.idSubjects=sn.id" +
               " inner join Groups g on ss.idGroups=g.id"
               + " where  ss.idUser = " + str + "  order by 2,3,4"); 
            if (dgvSemestrSubjectMark.RowCount > 0)
                UpdateSSControlTable(dgvSemestrSubjectMark.CurrentRow.Cells[0].Value.ToString());
            else
                UpdateSSControlTable("0");

        }

        private void dgvSemestrSubjectMark_Click(object sender, EventArgs e)
        {
            UpdateSSControlTable(dgvSemestrSubjectMark.CurrentRow.Cells[0].Value.ToString());
        }

        public void UpdateSSControlTable(string str)
        {
            statements.GetTable(dgvSSControl, "select ssc.id as 'Код',tc.name  as 'Название' from SemesttSubjectsControl ssc inner join TypesOfControl tc on tc.[id] = ssc.idTypeOfControl where ssc.idSemestrSubject =  " + str);

            if (dgvSSControl.RowCount > 0)
            {
                UpdateStudentsMarkTable(dgvSSControl.CurrentRow.Cells[0].Value.ToString());
                PaintChart(true);
            }
            else
            {
                UpdateStudentsMarkTable("0");
                PaintChart(false);
            }

        }
        private void dgvSSControl_Click(object sender, EventArgs e)
        {
            if (dgvSSControl.RowCount > 0)
            {
                UpdateStudentsMarkTable(dgvSSControl.CurrentRow.Cells[0].Value.ToString());

                PaintChart(true);
            }
            else
            {
                UpdateStudentsMarkTable("0");
                PaintChart(false);
            }

        }
        public void PaintChart( bool tr)
        {
            chMark.Visible = tr;
            if (tr)
            {
                Series series1 = new Series(dgvSSControl.CurrentRow.Cells[1].Value.ToString());

                double count2 = 0, count3 = 0, count4 = 0, count5 = 0;
                for (int i =0; i < dgvStudentsMark.Rows.Count ; i++)
                {
                    if (dgvStudentsMark.Rows[i].Cells[4].Value.ToString() != string.Empty)
                    {
                        count2 += dgvStudentsMark.Rows[i].Cells[4].Value.ToString() == "2" ? 1 : 0;
                        count3 += dgvStudentsMark.Rows[i].Cells[4].Value.ToString() == "3" ? 1 : 0;
                        count4 += dgvStudentsMark.Rows[i].Cells[4].Value.ToString() == "4" ? 1 : 0;
                        count5 += dgvStudentsMark.Rows[i].Cells[4].Value.ToString() == "5" ? 1 : 0;
                    }
                }

                int countStudents = dgvStudentsMark.Rows.Count;
                count2 /= countStudents;
                count3 /= countStudents;
                count4 /= countStudents;
                count5 /= countStudents;
                
                series1.Points.AddXY("2", count2);
                series1.Points.AddXY("3", count3);
                series1.Points.AddXY("4", count4);
                series1.Points.AddXY("5", count5);

                series1.ChartType = SeriesChartType.Column;
                chMark.ChartAreas[0].AxisY.Maximum = 1;
                chMark.Series.Clear();
                
                    chMark.Series.Add(series1);
            }
        }

        public void UpdateStudentsMarkTable(string str)
        {
            statements.GetTable(dgvStudentsMark, "select st.id  as 'Код студента',st.fio  as 'ФИО' ,ms.id  as 'id оценки',ms.date  as 'Дата', ms.mark  as 'Оценка'" +
                "from SemesttSubjectsControl ssc  " +
                "inner join SemestrSubject ss on ss.[id] = ssc.idSemestrSubject " +
                "inner join groups g on g.[id] = ss.idGroups " +
                "inner join Students  st on st.[idGroup] = g.id " +
                "left join  MarkOfStudents ms on ms.idStudents = st.id and  ms.idSemestrSubjectsControl = ssc.id " +
                "where ssc.[id] =" + str);
            if (dgvStudentsMark.RowCount > 0)
                PaintChart(true);
        }

        private void dgvStudentsMark_DoubleClick(object sender, EventArgs e)
        {
            if (dgvStudentsMark.RowCount > 0)
            {
                fmAddEdtMark fmedit;

                if (dgvStudentsMark.CurrentRow.Cells[4].Value.ToString() != string.Empty)
                {
                    fmedit = new fmAddEdtMark(dgvStudentsMark.CurrentRow.Cells[1].Value.ToString(),
                            dgvStudentsMark.CurrentRow.Cells[4].Value.ToString(),
                            dgvStudentsMark.CurrentRow.Cells[3].Value.ToString());
                }
                else
                {
                    fmedit = new fmAddEdtMark(dgvStudentsMark.CurrentRow.Cells[1].Value.ToString(), "", "");
                }

                fmedit.Owner = this;
                fmedit.ShowDialog();

                // сохраняем результат
                if (fmedit.returnsave == 1)
                {
                    if (dgvStudentsMark.CurrentRow.Cells[4].Value.ToString() == string.Empty)
                    {
                        //добавляем
                        statements.SqlInsertUpdate($"insert into MarkOfStudents (idStudents,idSemestrSubjectsControl,Date,Mark)" +
                              $" values('{dgvStudentsMark.CurrentRow.Cells[0].Value.ToString()}','" +
                               $"{dgvSSControl.CurrentRow.Cells[0].Value.ToString()}'" +
                               $",'{fmedit.returndate.ToString()}','{fmedit.returnmark.ToString()}')");
                    }
                    else
                    {
                        //обновляем
                       statements.SqlInsertUpdate($"update MarkOfStudents set Date = '{fmedit.returndate.ToString()}'" +
                              $",Mark = '{fmedit.returnmark.ToString()}'" +
                              $" where id = '{this.dgvStudentsMark.CurrentRow.Cells[2].Value.ToString()}'");
                    }
                }
                    UpdateStudentsMarkTable(dgvSSControl.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}
