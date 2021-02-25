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
    public partial class fmViewMark : Form
    {
        DBStatements statements = new DBStatements();
        List<int> listFaculties = new List<int>();
        List<int> listChairs = new List<int>();
        List<int> listSpecialties = new List<int>();
        List<int> listGroups = new List<int>();
        List<int> listSubject = new List<int>();
        List<int> listControl = new List<int>();

        public fmViewMark(string afio)
        {
            InitializeComponent();
            this.Text = "Пользователь - " + afio;
            statements.ConnectionString = $"Data Source={DBStatements.DbFilePath};Version=3;foreign_keys = ON;";
        }

        public void PaintChart(bool b)
        {
            chMark.Visible = b;
            if (b)
            {
                Series series1 = new Series(cbControl.Text);

                double count2 = 0, count3 = 0, count4 = 0, count5 = 0;
                for (int i = 0; i < dgvStudentsMark.Rows.Count; i++)
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

        void UpdateComboBoxNames(ComboBox comboBox, List<int> listResults, DataTable table)
        {
            listResults.Clear();
            comboBox.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name;
                try
                {
                     name = table.Rows[i]["Name"].ToString();
                }
                catch
                {
                     name = table.Rows[i][1].ToString() + " " + table.Rows[i][2].ToString();
                }
                int id = Convert.ToInt32(table.Rows[i][0].ToString());

                comboBox.Items.Add(name);
                listResults.Add(id);
            }
            if (comboBox.Items.Count > 0)
                comboBox.Select(0, 1);
        }

        private void fmViewMark_Shown(object sender, EventArgs e)
        {
            UpdateComboBoxNames(cbFaculties, listFaculties, statements.GetFaculties());
            PaintChart(false);
            UpdateStudentsMarkTable("0");
        }

        private void comboBoxFaculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbChairs.Text = string.Empty;
            cbSpecialties.Text = string.Empty;
            cbGroup.Text = string.Empty;
            cbSubject.Text = string.Empty;
            cbControl.Text = string.Empty;

            UpdateComboBoxNames(cbChairs, listChairs, statements.GetChairs(" where idFaculty = '" + listFaculties[cbFaculties.SelectedIndex].ToString() + "'"));
            PaintChart(false); UpdateStudentsMarkTable("0");
        }

        private void comboBoxChairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSpecialties.Text = string.Empty;
            cbGroup.Text = string.Empty;
            cbSubject.Text = string.Empty;
            cbControl.Text = string.Empty;
            UpdateComboBoxNames(cbSpecialties, listSpecialties, statements.GetSpecialties("  where idChair = '" + listChairs[cbChairs.SelectedIndex].ToString() + "'"));
            PaintChart(false);
            UpdateStudentsMarkTable("0");
        }

        private void cbSpecialties_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbGroup.Text = string.Empty;
            cbSubject.Text = string.Empty;
            cbControl.Text = string.Empty;
            UpdateComboBoxNames(cbGroup, listGroups, statements.GetGroups("  where idSpetialty = '" + listSpecialties[cbSpecialties.SelectedIndex].ToString() + "'"));
            PaintChart(false);
            UpdateStudentsMarkTable("0");
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubject.Text = string.Empty;
            cbControl.Text = string.Empty;
            UpdateComboBoxNames(cbSubject, listSubject, statements.GetSemestrSubject("  where idGroups = '" + listGroups[cbGroup.SelectedIndex].ToString() + "'"));
            PaintChart(false);
            UpdateStudentsMarkTable("0");
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbControl.Text = string.Empty;
            UpdateComboBoxNames(cbControl, listControl, statements.GetSemesttSubjectsControl("  where idSemestrSubject = '" + listSubject[cbSubject.SelectedIndex].ToString() + "'"));
            PaintChart(false);
            UpdateStudentsMarkTable("0");
        }

        private void fmViewMark_Scroll(object sender, ScrollEventArgs e)
        {
            PaintChart(false);
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
            if (dgvStudentsMark.RowCount > 0) PaintChart(true);

        }
       

        private void cbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbControl.Text != string.Empty)
            {
                UpdateStudentsMarkTable(listControl[cbControl.SelectedIndex].ToString());

                PaintChart(true);
            }
            else
            {
                UpdateStudentsMarkTable("0");
                PaintChart(false);
            }
        }
    }
}
