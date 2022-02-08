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
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using P4WPF.Models;
using System.Runtime.CompilerServices;


namespace P4WPF
{
    /// <summary>
    /// Interaction logic for EditIngredient.xaml
    /// </summary>
    public partial class EditIngredient : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        Base _db = new Base();

        private Ingredient updateitem = new Ingredient();

        public Ingredient UpdateItems
        {
            get { return updateitem; }
            set { updateitem = value; OnPropertyChanged(); }
        } 
        
        public EditIngredient(Ingredient ingredient)
        {
            InitializeComponent();
            DataContext = this;
            UpdateItems = ingredient;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            _db.UpdateItem(UpdateItems);
            this.Close();
        }
    }
}
