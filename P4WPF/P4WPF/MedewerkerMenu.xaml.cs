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
    /// Interaction logic for MedewerkerMenu.xaml
    /// </summary>
    public partial class MedewerkerMenu : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ObservableCollection<Orders> Oborders = new ObservableCollection<Orders>();
   
        //public List<Klanten> lstKlanten = new List<Klanten>();


        public ObservableCollection<Orders> Orders
        {
            get { return Oborders; }
            set { Oborders = value; }
        }
        private Users userss = new Users();

        public Users Userss
        {
            get { return userss; }
            set { userss = value; OnPropertyChanged(); }
        }

        Base _db = new Base();
        private Orders selectedOrder;
        public Orders SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; OnPropertyChanged(); OnPropertyChanged("lstOrders"); }
        }
        public MedewerkerMenu()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {





                List<Orders> lstOrders = _db.GetAllOrders();

            if (lstOrders == null) {
                MessageBox.Show("Er is iets mis met je database. De database is leeg. ");
            }
            else
            {
                Orders.Clear();
                foreach (Orders order in lstOrders)
                {
                    Orders.Add(order);
                }


            }


            
            
        }

        private void btStatus_Click(object sender, RoutedEventArgs e)
        {

            if (selectedOrder == null)
            {
                MessageBox.Show("You have not chosen an order. ");
            }
            else
            {
                
                _db.UpdateOrderStatus(SelectedOrder);

            }


            //STstatus.Visibility = Visibility.Visible;

        }

        private void btIngredients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btUnits_Click(object sender, RoutedEventArgs e)
        {

            units win = new units();
            win.ShowDialog();
        }

        //private void btMade_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void btOven_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void btDeliverys_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void btClose_Click(object sender, RoutedEventArgs e)
        //{
        //    STstatus.Visibility = Visibility.Hidden;
        //}
    }
}
