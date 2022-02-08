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
        private Ingredient selecteditem;
        public Ingredient SelectedItem
        {
            get { return selecteditem; }
            set { selecteditem = value; OnPropertyChanged();  }
        }

        private Ingredient newingredient = new Ingredient();

        public Ingredient NewIngredient
        {
            get { return newingredient; }
            set { newingredient = value; OnPropertyChanged(); }
        }
        public Management()
        {
            InitializeComponent();
            LoadAllList();
            DataContext = this;
            FrameIngredients.Content = new AddIngredient();
            
           
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        public void LoadAllList()
        {
            //Laad de hele lijst van ingredienten in.
            List<Ingredient> lstIngredients = _db.GetAllingredients();
            if (lstIngredients == null)
            {
                MessageBox.Show("Er is iets mis met je database. De database is leeg. ");
            }
            else
            {
                foreach (Ingredient i in lstIngredients)
                {
                    Ingredienten.Add(i);
                }
            }

        }


        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null)
            {
                // als er niks geselecteerd is komt er een error
                MessageBox.Show("Je hebt geen ingredient gekozen om te verwijderen.");
            }
            else
            {
                //delete het item
                _db.DeleteIngredients(SelectedItem);
                


            }
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            FrameIngredients.Content = new AddIngredient();
            FrameIngredients.Visibility = Visibility.Visible;
            
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if(selecteditem == null)
            {
                MessageBox.Show("U heeft geen item geselecteerd.");
            }
            EditIngredient win = new EditIngredient(SelectedItem);
            win.ShowDialog();
            

        }

        private void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<Ingredient> lstItems = _db.GetAllingredients();

            if (lstItems == null)
            {
                MessageBox.Show("Er is iets mis met je database. De database is leeg. ");
            }
            else
            {
                Ingredienten.Clear();
                foreach (Ingredient I in lstItems)
                {
                    Ingredienten.Add(I);
                }


            }
        }

        private void btIngredient_Click(object sender, RoutedEventArgs e)
        {
            stAdd.Visibility = Visibility.Visible;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            _db.SaveIngredient(newingredient);
            stAdd.Visibility = Visibility.Hidden;
            tbAdd.Text = " "; 
        }
    }
}
