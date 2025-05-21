using eKRÉTA.Models;
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

namespace eKRÉTA.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlTanar.xaml
    /// </summary>
    public partial class UserControlTanar : UserControl
    {
        List<Tanar> tanar;
        Tanar selectedTanar;
        public UserControlTanar()
        {
            InitializeComponent();
            tanar = new List<Tanar>();
            ReadDatabase();
            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void ReadDatabase()
        {
            veznevTBOX.Text = "";
            utonevTBOX.Text = "";
            osztalyIDTBOX.Text = "";
            kedvesE.IsChecked = false;

            var TanarRepo = new GenericRepository<Tanar>(App.databasePath);
            var query = TanarRepo.GetAll();
            datagridTanar.ItemsSource = query;

            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Tanar tanar = new Tanar(veznevTBOX.Text, utonevTBOX.Text, Convert.ToInt32(osztalyIDTBOX.Text), Convert.ToBoolean(kedvesE.IsChecked));
            var TanarRepo = new GenericRepository<Tanar>(App.databasePath);
            TanarRepo.insert(tanar);
            ReadDatabase();
        }

        private void datagridTanar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

            if (datagridTanar.SelectedItem != null)
            {
                selectedTanar = (Tanar)datagridTanar.SelectedItem;
                veznevTBOX.Text = selectedTanar.VezNev;
                utonevTBOX.Text = selectedTanar.UtoNev;
                osztalyIDTBOX.Text = selectedTanar.OsztalyId.ToString();
                kedvesE.IsChecked = selectedTanar.KedvesE;
               
            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedTanar.VezNev = veznevTBOX.Text;
            selectedTanar.UtoNev = utonevTBOX.Text;
            selectedTanar.OsztalyId = Convert.ToInt32(osztalyIDTBOX.Text);
            selectedTanar.KedvesE = Convert.ToBoolean(kedvesE.IsChecked);
            var TanarRepo = new GenericRepository<Tanar>(App.databasePath);
            TanarRepo.update(selectedTanar);
            ReadDatabase();

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var TanarRepo = new GenericRepository<Tanar>(App.databasePath);
            TanarRepo.delete(selectedTanar);
            ReadDatabase();

        }
    }
}
