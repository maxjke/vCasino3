using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.DataAccess.Classes.Base_Classes
{
    public static class Settings
    {
        public static User User { get; private set; }
        public static Balance Balance { get; set; }

        public static void setStaticUser(User user, Balance balance)
        {
            User = user;
            Balance = balance;
        }
    }
}
