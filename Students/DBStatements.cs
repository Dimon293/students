using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;
namespace Students
{
    //Запросы в бд
    public class DBStatements
    {
        public static string DbFilePath = AppDomain.CurrentDomain.BaseDirectory + "DB.db";

        public static SQLiteConnection cnn = new SQLiteConnection
            ($"Data Source={DbFilePath};Version=3;foreign_keys = ON;");
        public string ConnectionString { get; set; }

        //перевод параметров в строку
        private string ParamsToString(string [] parametrs)
        {
            string result = "";

            if(parametrs.Length != 0)
            {
                foreach(var param in parametrs)
                {
                    result += param + ",";
                }
                result = result.Remove(result.Length - 1);
            }
            return result;
        }
        //получить таблицу
        private DataSet GetTable(string[] columnsName, string[] tablesName, string statement)
        {
            DataSet dataSet = new DataSet();

            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection();
                connection.ConnectionString = ConnectionString;
                connection.Open();

            SQLiteCommand command = new SQLiteCommand(connection);
                    if (statement == "")
                        command.CommandText = @"SELECT " + ParamsToString(columnsName) + " FROM " + ParamsToString(tablesName) + ";";
                    else
                        command.CommandText = statement;

                    command.CommandType = CommandType.Text;


                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter();
                    dataAdapter.SelectCommand = command;

                    dataAdapter.Fill(dataSet);

            return dataSet;
        }
        //выполнить команду
        public static void ExecuteCommand(string command)
        {
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = command;
            mycommand.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable ExecuteWithCallback(string command)
        {
            DataTable dt = new DataTable();
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = command;
            SQLiteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
            return dt;
        }
        public DataTable GetAccess()
        {
            return GetTable(new string[] { "Id", "Name" }, new string[] { "UserAccess" }, "").Tables[0];
        }

        public DataTable  GetFaculties()
        {
            return GetTable(new string[]{ "Id", "Name" }, new string[] { "Faculties" }, "").Tables[0];
        }
        public DataTable GetChairs(string astr)
        {
            return GetTable(new string[] { "c.Id", "c.Name" }, new string[] { "Chairs c "+astr }, "").Tables[0];
        }
        public DataTable GetSpecialties(string astr)
        {
            return GetTable(new string[] { "s.Id", "s.Name" }, new string[] { "Specialties s" + astr }, "").Tables[0];
        }
        public DataTable GetGroups(int idTeacher)
        {
            if (idTeacher == -1)
                return GetTable(new string[] { "Id", "Name" }, new string[] { "Groups" }, "").Tables[0];
            else
                return ExecuteWithCallback($"Select Distinct idGroup, Name from Groups, SemesterReg Where Groups.id = SemesterReg.idGroup AND SemesterReg.idTeacher ={idTeacher}");
            }
        public DataTable GetGroups(string astr)
        {
            return GetTable(new string[] { "s.Id", "s.Name" }, new string[] { "Groups s" + astr }, "").Tables[0];
        }
        public DataTable GetSemestrSubject(string astr)
        {
            return GetTable(new string[] { "ss.Id", "s.name as 'sSame'", "sn.name as 'snName'" }, new string[] { "SemestrSubject ss inner join Semestr s on s.id = ss.idSemestr inner join SubjectsName sn on sn.id= ss.idSubjects " + astr }, "").Tables[0];

        }
        public DataTable GetSemesttSubjectsControl(string astr)
        {
            return GetTable(new string[] { "ssc.id", " t.name"}, new string[] { "SemesttSubjectsControl ssc inner join TypesOfControl t on t.id =ssc.idTypeOfControl " + astr }, "").Tables[0];
         }

        public DataTable GetSubjects(int idTeacher, int idGroup)
        {
            if (idTeacher == -1)
                return GetTable(new string[] { "Id", "Name" }, new string[] { "Subjects" }, "").Tables[0];
            else
                return ExecuteWithCallback($"Select Distinct idSubject, Name from Subjects, SemesterReg Where Subjects.id = SemesterReg.idSubject AND SemesterReg.idTeacher = {idTeacher} AND SemesterReg.idGroup = {idGroup}");
        }
        public DataTable GetSubjects()
        {
            return GetTable(new string[] { "Id", "Name" }, new string[] { "SubjectsName " }, "").Tables[0];
        }
        public DataTable GetSemestr()
        {
            return GetTable(new string[] { "Id", "Name" }, new string[] { "Semestr" }, "").Tables[0];
        }
        public DataTable GetUser()
        {
            return GetTable(new string[] { "Id", "name" }, new string[] { "User where access = 2" }, "").Tables[0];
        }
        public DataTable GetTypesOfControl()
        {
            return GetTable(new string[] { "Id", "name" }, new string[] { "TypesOfControl " }, "").Tables[0];
        }
        
        public void GetTable( DataGridView dataGrid, string sqlstr)
        {
            string statement = sqlstr;

            dataGrid.DataSource = GetTable(new string[] { "" }, new string[] { "" }, statement);
            dataGrid.DataMember = "Table";
            dataGrid.ReadOnly = true; // запрет на редактирование данных в ячейках таблицы
            dataGrid.AllowUserToAddRows = false; // убираем последнию строку в таблице
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // подгоняем все столбцы под его содержимое
            dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //растягиваем второй столбец до максимума
        }
        
        public void SqlDelete(string asql)
        {
            string statement = asql;
             ExecuteCommand(statement);
        }
        public void SqlInsertUpdate(string asql)
        {
            string statement = asql;
            ExecuteCommand(statement);
        }
    }
}
