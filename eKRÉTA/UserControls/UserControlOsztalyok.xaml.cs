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
    /// Interaction logic for OsztalyokControlOsztalyok.xaml
    /// </summary>
    public partial class UserControlOsztalyok : UserControl
    {
        List<Osztalyok> osztalyok;
        Osztalyok selectedOsztalyok;
        public UserControlOsztalyok()
        {
            InitializeComponent();
            osztalyok = new List<Osztalyok>();
            ReadDatabase();
            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
            


        }

        private void ReadDatabase()
        {
            osztalynevTBOX.Text = "";
            teremIDTBOX.Text = "";

            var OsztalyokRepo = new GenericRepository<Osztalyok>(App.databasePath);
            var query = OsztalyokRepo.GetAll();
            datagridOsztalyok.ItemsSource = query;

            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Osztalyok osztaly = new Osztalyok(osztalynevTBOX.Text, Convert.ToInt32(teremIDTBOX.Text));
            var OsztalyokRepo = new GenericRepository<Osztalyok>(App.databasePath);
            OsztalyokRepo.insert(osztaly);
            ReadDatabase();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var OsztalyokRepo = new GenericRepository<Osztalyok>(App.databasePath);
            OsztalyokRepo.delete(selectedOsztalyok);
            ReadDatabase();
            

        }

        private void datagridOsztalyok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

            if (datagridOsztalyok.SelectedItem != null)
            {
                selectedOsztalyok = (Osztalyok)datagridOsztalyok.SelectedItem;
                osztalynevTBOX.Text = selectedOsztalyok.OsztalyNev;
                teremIDTBOX.Text = selectedOsztalyok.TeremID.ToString();
            }

        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedOsztalyok.OsztalyNev = osztalynevTBOX.Text;
            selectedOsztalyok.TeremID = Convert.ToInt32(teremIDTBOX.Text);
            var OsztalyokRepo = new GenericRepository<Osztalyok>(App.databasePath);
            OsztalyokRepo.update(selectedOsztalyok);
            ReadDatabase();

        }
    }
}
