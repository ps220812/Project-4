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
                //bool Correct = BCrypt.Net.BCrypt.Verify(TxtPassword.Password, password);
                //if (Correct == true)
                //{
                //    switch (Userss[i].RoleName)
                //    {
                //        case "management":
                //            MessageBox.Show("manager login");
                //            break;
                //        case "admin":
                //            MessageBox.Show("gelukt");
                //            break;
                //        default:
                //            break;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("error");
                //}
            Users login = _db.ReadRole(Userss);
            if (login == null)
            {
                MessageBox.Show("Voer een medewerker in.");
            }
            else
            {
                //_db.ReadRole(Userss);
                mainFrame.Content = new MedewerkerMenu();
                mainFrame.Visibility = Visibility.Visible;
            }

        }
      
    }
}
