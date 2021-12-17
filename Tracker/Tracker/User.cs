using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker
{
    class User
    {
        public string name { get; set; }
        public string password { get; set; }

        public User(string username, string password)
        {
            this.name = username;
            this.password = password;
        }
    }
}
