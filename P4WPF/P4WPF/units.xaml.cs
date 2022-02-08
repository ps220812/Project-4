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
        private ObservableCollection<unit> obunits = new ObservableCollection<unit>();


        public ObservableCollection<unit> Units
        {
            get { return obunits; }
            set { obunits = value; }
        }


        Base _db = new Base();
        private unit selecteditem;
        public unit SelectedItem
        {
            get { return selecteditem; }
            set { selecteditem = value; OnPropertyChanged(); }
        }
        private unit newunit = new unit();

        public unit NewUnit
        {
            get { return newunit; }
            set { newunit = value; OnPropertyChanged(); }
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
            List<unit> lstUnits = _db.GetUnit();
            if (lstUnits == null)
            {
                MessageBox.Show("Er is iets mis met je database. De database is leeg. ");
            }
            else
            {
                foreach (unit i in lstUnits)
                {
                    Units.Add(i);
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
                    _db.DeleteUnit(SelectedItem);
               

                }
        }

        private void tbAdd_Click(object sender, RoutedEventArgs e)
        {
            if (NewUnit== null)
            {
                MessageBox.Show("Leeg textboxen. je moet een waarde geven om een costumer toe te voegen.");
                return;
            }
            _db.SaveUnit(NewUnit);
        }
    }
}
