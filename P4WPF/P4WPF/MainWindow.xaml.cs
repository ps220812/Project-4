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
            Users login = _db.ReadRole(Userss);
            Users loginM = _db.ReadForM(Userss);
            if (loginM != null)
            {
                switch (loginM)
                {
                    case null:
                        MessageBox.Show("Voer een medewerker in.");
                        break;

                    default:
                        TxtUser.Text = " ";
                        txtPass.Text = " ";
                        mainFrame.Content = new Management();
                        mainFrame.Visibility = Visibility.Visible;
                        break;
                }
            }
            else
            {
                switch (login)
                {
                    case null:
                        MessageBox.Show("Voer een medewerker in.");
                        break;

                    default:
                        TxtUser.Text = " ";
                        txtPass.Text = " ";
                        mainFrame.Content = new MedewerkerMenu();
                        mainFrame.Visibility = Visibility.Visible;
  
                        break;
                }
            }

        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new MedewerkerMenu();
            mainFrame.Visibility = Visibility.Visible;
        }
    }
}
