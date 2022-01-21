using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class Users
    {
        private ulong id;

        public ulong ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set{ name = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private ulong role_id;

        public ulong Role_ID
        {
            get { return role_id; }
            set { role_id = value; }
        }
        private string role_name;

        public string Role_Name
        {
            get { return role_name; }
            set { role_name = value; }
        }
    }
}
