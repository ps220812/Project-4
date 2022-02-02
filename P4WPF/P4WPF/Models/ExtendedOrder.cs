using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class ExtendedOrder: Notify
    {
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
            set { status = value; }
        }


    }

}

