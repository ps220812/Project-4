using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class IngredientExtend
    {
        private string ingredient;

        public string IngredientName
        {
            get { return ingredient; }
            set { ingredient = value; }
        }
        private string unit_name;

        public string Unit_Name
        {
            get { return unit_name; }
            set { unit_name = value; }
        }
    }
}
