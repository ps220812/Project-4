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
    /// Interaction logic for IngredientEdit.xaml
    /// </summary>
    public partial class IngredientEdit : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ObservableCollection<Ingredient> obingredienten = new ObservableCollection<Ingredient>();


        public ObservableCollection<Ingredient> Ingredienten
        {
            get { return obingredienten; }
            set { obingredienten = value; }
        }
        Base _db = new Base();

        public IngredientEdit(Ingredient SelectedItem)
        {
            
            InitializeComponent();
            DataContext = this;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
