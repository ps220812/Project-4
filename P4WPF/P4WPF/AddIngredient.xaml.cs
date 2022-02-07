using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using P4WPF.Models;
using System.Collections.ObjectModel;

namespace P4WPF
{
    /// <summary>
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Ingredient newitem = new Ingredient();

        public Ingredient NewItem
        {
            get { return newitem; }
            set { newitem = value; OnPropertyChanged(); }
        }

        Base _db = new Base();

        public AddIngredient()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            if (newitem == null)
            {
                MessageBox.Show("Leeg textboxen. je moet een waarde geven om een costumer toe te voegen.");
                return;
            }
            _db.SaveItem(newitem);
            this.Visibility = Visibility.Hidden;
        }
    }
}
