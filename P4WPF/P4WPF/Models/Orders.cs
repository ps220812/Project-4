using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class Orders : Notify
    {
        private ulong status_id;

        public ulong Status_ID
        {
            get { return status_id; }
            set { status_id = value; OnPropertyChanged(); }
        }
        private ulong pizza_id;

        public ulong Pizza_ID
        {
            get { return pizza_id; }
            set { pizza_id = value; }
        }
        private ulong user_id;

        public ulong User_ID
        {
            get { return user_id; }
            set { user_id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string pizza_name;

        public string Pizza_Name
        {
            get { return pizza_name; }
            set { pizza_name = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }

        public string Full_Order
        {
            get { return Name + " " + Pizza_Name + " " + Status; }
            set { }
        }
    }
    
}
