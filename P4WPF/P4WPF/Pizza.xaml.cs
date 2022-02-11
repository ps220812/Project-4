using P4WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P4WPF
{
    /// <summary>
    /// Interaction logic for Pizza.xaml
    /// </summary>
    public partial class Pizza : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((name)));
        }

        private ObservableCollection<Orders> obPizza = new ObservableCollection<Orders>();
        public ObservableCollection<Orders> Pizzas
        {
            get { return obPizza; }
            set { obPizza = value; }
        }
        private Orders newitem = new Orders();
        public Orders NewItem
        {
            get { return newitem; }
            set { newitem = value; OnPropertyChanged(); }
        }

        Base _db = new Base();

        private Orders selectedPizza;
        public Orders SelectedPizza
        {
            get { return selectedPizza; }
            set { selectedPizza = value; OnPropertyChanged(); }
        }


        public Pizza()
        {
            InitializeComponent();
            LoadAllList();
            DataContext = this;
        }

        public void LoadAllList()
        {
            List<Orders> lstPizza = _db.GetAllPizzas();
            if(lstPizza==null)
            {
                MessageBox.Show("Er is iets mis met je database. De database is leeg");
            }
            else
            {
                foreach (Orders i in lstPizza)
                {
                    Pizzas.Add(i);
                }
            }    
        }

        private void btPizza_Click(object sender, RoutedEventArgs e)
        {
            if (newitem==null)
            {
                MessageBox.Show("Vul eerst een pizza in");
                return;
            }
            _db.SavePizza(NewItem);
        }

        private void btEdit_click(object sender, RoutedEventArgs e)
        {

        }

        private void btDelete_click(object sender, RoutedEventArgs e)
        {
            if (selectedPizza == null)
            {
                MessageBox.Show("je hebt geen pizza gekozen om te verwijderen");
            }
            else
            {
                _db.DeletePizza(SelectedPizza);
                
            }
        }
        private void BtRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<Orders> lstPizza = _db.GetAllPizzas();
            if (lstPizza == null)
            {
                MessageBox.Show("Er is iets mis met je database. De database is leeg");
            }
            else
            {
                Pizzas.Clear();
                foreach (Orders i in lstPizza)
                {
                    Pizzas.Add(i);
                }
            }
        }
    }
}
