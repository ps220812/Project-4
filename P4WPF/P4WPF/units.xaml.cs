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
    /// Interaction logic for units.xaml
    /// </summary>
    public partial class units : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ObservableCollection<Ingredient> obUnits = new ObservableCollection<Ingredient>();


        public ObservableCollection<Ingredient> Units
        {
            get { return obUnits; }
            set { obUnits = value; }
        }
        Base _db = new Base();
        private Ingredient selecteditem;
        public Ingredient SelectedItem
        {
            get { return selecteditem; }
            set { selecteditem = value; OnPropertyChanged(); OnPropertyChanged("lst"); }
        }

        public units()
        {
            InitializeComponent();
            LoadAllList();
            DataContext = this;
        }
        public void LoadAllList()
        {
            //Laad de hele lijst van ingredienten in.
            List<Ingredient> lstUnits = _db.GetUnit();
            if (lstUnits == null)
            {
                MessageBox.Show("Er is iets mis met je database. De database is leeg. ");
            }
            else
            {
                foreach (Ingredient i in lstUnits)
                {
                    Units.Add(i);
                }
            }

        }
    }
}
