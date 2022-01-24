using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    class Orders
    {
        private int status_id;

        public int Status_ID
        {
            get { return status_id; }
            set { status_id = value; }
        }
        private int pizza_id;

        public int Pizza_ID
        {
            get { return pizza_id; }
            set { pizza_id = value; }
        }
        private int user_id;

        public int User_ID
        {
            get { return user_id; }
            set { user_id = value; }
        }
    }
}
