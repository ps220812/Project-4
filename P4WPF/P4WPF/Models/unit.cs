using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class unit
    {
    
        private ulong id;

        public ulong ID
        {
            get { return id; }
            set { id = value; }
        }
        private string unit_name;

        public string Unit_Name
        {
            get { return unit_name; }
            set { unit_name = value; }
        }
     }
}
