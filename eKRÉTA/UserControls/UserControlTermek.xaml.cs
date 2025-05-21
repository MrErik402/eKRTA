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
    /// Interaction logic for UserControlTermek.xaml
    /// </summary>
    public partial class UserControlTermek : UserControl
    {
        List<Termek> termek;
        Termek selectedTermek;
        public UserControlTermek()
        {
            InitializeComponent();
            termek = new List<Termek>();
            ReadDatabase();
            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void ReadDatabase()
        {
            teremnevTBOX.Text = "";

            var OsztalyokRepo = new GenericRepository<Termek>(App.databasePath);
            var query = OsztalyokRepo.GetAll();
            datagridTermek.ItemsSource = query;

            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void datagridTermek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

            if (datagridTermek.SelectedItem != null)
            {
                selectedTermek = (Termek)datagridTermek.SelectedItem;
                teremnevTBOX.Text = selectedTermek.TeremNev;
            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedTermek.TeremNev = teremnevTBOX.Text;
            var TermekRepo = new GenericRepository<Termek>(App.databasePath);
            TermekRepo.update(selectedTermek);
            ReadDatabase();

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var TermekRepo = new GenericRepository<Termek>(App.databasePath);
            TermekRepo.delete(selectedTermek);
            ReadDatabase();


        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Termek terem = new Termek(teremnevTBOX.Text);
            var TermekRepo = new GenericRepository<Termek>(App.databasePath);
            TermekRepo.insert(terem);
            ReadDatabase();
        }
    }
}
