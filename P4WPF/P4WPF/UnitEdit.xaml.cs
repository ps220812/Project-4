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
    /// Interaction logic for UnitEdit.xaml
    /// </summary>
    public partial class UnitEdit : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        Base _db = new Base();

        private unit updateitem = new unit();

        public unit UpdateItems
        {
            get { return updateitem; }
            set { updateitem = value; OnPropertyChanged(); }
        }
        public UnitEdit(unit SelectedItem)
        {
            InitializeComponent();
            DataContext = this;
            UpdateItems = SelectedItem;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            _db.UpdateUnits(UpdateItems);
            this.Close();
        }
    }
}
