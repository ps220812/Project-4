using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class pizza
    {
        private ulong id;

        public ulong ID
        {
            get { return id; }
            set { id = value; }
        }
        private string pizza_name;
        public string Pizza_Name
        {
            get { return pizza_name; }
            set { pizza_name = value; }
        }
    }
}
