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

namespace P4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Users userss = new Users();

        public Users Userss
        {
            get { return userss; }
            set { userss = value; OnPropertyChanged(); }
        }

        Base _db = new Base();
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new MedewerkerMenu();
            DataContext = this;
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
           
            _db.ReadRole(Userss);
            mainFrame.Content = new MedewerkerMenu();
            mainFrame.Visibility = Visibility.Visible;
        }
    }
}
