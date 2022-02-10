using P4WPF.Models;
using System;
using System.Collections.Generic;
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
        private Orders newitem = new Orders();
        public Orders NewItem
        {
            get { return newitem; }
            set { newitem = value; OnPropertyChanged(); }
        }

        Base _db = new Base();

        public Pizza()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btPizza_Click(object sender, RoutedEventArgs e)
        {
            if (newitem==null)
            {
                MessageBox.Show("Vul eerst een pizza in");
                return;
            }
            _db.SavePizza(NewItem);
            this.Visibility = Visibility.Hidden;
        }
    }
}
