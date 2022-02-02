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
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Page
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
        private Ingredient selectedingredient;
        public Ingredient SelectedIngredient
        {
            get { return selectedingredient; }
            set { selectedingredient = value; OnPropertyChanged(); OnPropertyChanged("lst"); }
        }
        public Management()
        {
            InitializeComponent();
            LoadAllList();
            DataContext = this;
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LoadAllList()
        {
            //Laad de hele lijst van ingredienten in.
            foreach (Ingredient i in _db.GetAllingredients())
            {
                if (i == null) MessageBox.Show("Er is iets mis met je database. De database is leeg. ");
                Ingredienten.Add(i);
            }

        }


        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredient == null)
            {
                // als er niks geselecteerd is komt er een error
                MessageBox.Show("Je hebt geen Klant gekozen om te verwijderen.");
            }
            else
            {
                //delete het item
                _db.DeleteIngredients(SelectedIngredient);
                LoadAllList();


            }
        }
    }
}
