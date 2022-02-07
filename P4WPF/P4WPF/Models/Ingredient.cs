using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4WPF.Models
{
    public class Ingredient : IngredientExtend
    {
        private ulong id;

        public ulong ID
        {
            get { return id; }
            set { id = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private ulong unit_id;

        public ulong Unit
        {
            get { return unit_id; }
            set { unit_id = value; }
        }
        private ulong ingredient_id;

        public ulong IngredientID
        {
            get { return ingredient_id; }
            set { ingredient_id = value; }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
