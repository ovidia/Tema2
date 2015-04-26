using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Service
{
    public class UserService
    {
        private BooksDb _db;

        public UserService()
        {
            _db = new BooksDb();
        }

        public bool IsValid(string username, string password)
        {
            var cryptedPass = Helpers.SHA1.Encode(password);
            var users = _db.Users.Where(u => u.UserName == username && u.Password == cryptedPass).ToList();
            if (users.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegisterUser(UserModel user)
        {
            user.RoleName = "user";
            user.Password = Helpers.SHA1.Encode(user.Password);
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public string GetUserRole(string username, string password)
        {
            var cryptedPass = Helpers.SHA1.Encode(password);
            var users = _db.Users.Where(u => u.UserName == username && u.Password == cryptedPass).ToList();

            var user = users[0];

            return user.RoleName;
        }
    }
}
