using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    class User
    {
        public User()
        {

        }

        private int id;
        private string email;
        private string nickName;
        private string password;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
