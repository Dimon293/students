using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class User
    {
        public string Username;
        public int UserID;
        public int TypeUser;  
        /*
          1	Администратор
          2	Преподаватель
          3	Гость
        */
        public int GetTypeUser()  // возвращаем уровень доступа
        {
            return TypeUser;
        }
        public string GetUsername() // возвращаем фио пользователя
        {
            return Username;
        }
        public int GetUserID() // возвращаем id пользователя
        {
            return UserID;
        }
    }
}
