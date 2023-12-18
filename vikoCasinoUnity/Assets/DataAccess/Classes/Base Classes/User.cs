using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class User : Entity
    {
        public User(string username, string password, string email, DateTime dateOfBirth, int balance_Id, int percentOfWin)
        {
            if (int.Parse(dateOfBirth.ToString("yyyy"))-int.Parse(DateTime.Now.ToString("yyyy"))<18)
            {
                throw new Exception("The user must be of legal age");
            }

            Username = username;
            Password = password;
            Email = email;
            DateOfBirth = dateOfBirth;
            Balance_Id = balance_Id;
            PercentOfWin = percentOfWin;
        }

        private string Username { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }
        private DateTime DateOfBirth { get; set; }
        private int Balance_Id { get; set; }
        private int PercentOfWin { get; set; }
    }
}
