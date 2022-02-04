using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class Ingredient : Notify
    {
        private ulong id;

        public ulong ID
        {
            get { return id; }
            set { id = value; }
        }
        private string ingredient;

        public string IngredientName
        {
            get { return ingredient; }
            set { ingredient = value; }
        }
    }
}
