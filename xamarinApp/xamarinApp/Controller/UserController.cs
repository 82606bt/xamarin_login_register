using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using xamarinApp.Models;
using xamarinApp.Data;
using System.Linq;

namespace xamarinApp.Controller
{
    class UserController
    {
        private SQLiteConnection connection;
        public UserController()
        {
            connection = DependencyService.Get<ISQLiteConnection>().GetSQLiteConnection();
            connection.CreateTable<User>();
        }
        public IEnumerable<User> GetUsers()
        {
            return (from u in connection.Table<User>()
                    select u).ToList();
        }
        public User GetSpecificUser(int id)
        {
            return connection.Table<User>().FirstOrDefault(t => t.Id == id);
        }
        public void DeleteUser(int id)
        {
            connection.Delete<User>(id);
        }
        public string AddUser(User user)
        {
            var data = connection.Table<User>();
            var d1 = data.Where(x => x.name == user.name && x.userName == user.userName).FirstOrDefault();
            if (d1 == null)
            {
                connection.Insert(user);
                return "Tạo tài khoản thành công";
            }
            else
                return "Tài khoản đã tồn tại";

        }
        public bool updateUserValidation(string userid)
        {
            var data = connection.Table<User>();
            var d1 = (from values in data
                      where values.name == userid
                      select values).Single();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
        public bool updateUser(string username, string pwd)
        {
            var data = connection.Table<User>();
            var d1 = (from values in data
                      where values.name == username
                      select values).Single();
            if (true)
            {
                d1.password = pwd;
                connection.Update(d1);
                return true;
            }
            else
                return false;
        }
        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = connection.Table<User>();
            var d1 = data.Where(x => x.name == userName1 && x.password == pwd1).FirstOrDefault();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
