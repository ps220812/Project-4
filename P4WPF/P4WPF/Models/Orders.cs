using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class Orders : ExtendedOrder
    {
        private ulong id;

        public ulong ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }
        private ulong status_id;

        public ulong Status_ID
        {
            get { return status_id; }
            set { status_id = value; OnPropertyChanged();  }
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

    }
    
}
