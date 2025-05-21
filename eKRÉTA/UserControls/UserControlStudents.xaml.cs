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
using static System.Net.Mime.MediaTypeNames;

namespace eKRÉTA.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlStudents.xaml
    /// </summary>
    public partial class UserControlStudents : UserControl
    {
        List<Student> tanulok;
        Student selectedTanulok;
        public UserControlStudents()
        {
            InitializeComponent();
            tanulok = new List<Student>();
            ReadDatabase();
            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void ReadDatabase()
        {
            veznevTBOX.Text = "";
            utonevTBOX.Text = "";
            szuldateTBOX.Text = "";
            anyaTBOX.Text = "";
            lakcimTBOX.Text = "";

            var StudentRepo = new GenericRepository<Student>(App.databasePath);
            var query = StudentRepo.GetAll();
            datagridStudents.ItemsSource = query;

            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Student tanulo = new Student(veznevTBOX.Text, utonevTBOX.Text, szuldateTBOX.Text, anyaTBOX.Text, lakcimTBOX.Text);
            var StudentRepo = new GenericRepository<Student>(App.databasePath);
            StudentRepo.insert(tanulo);
            ReadDatabase();
        }

       

        private void datagridStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

            if (datagridStudents.SelectedItem != null)
            {
                selectedTanulok = (Student)datagridStudents.SelectedItem;
                veznevTBOX.Text = selectedTanulok.VezNev;
                utonevTBOX.Text = selectedTanulok.UtoNev;
                szuldateTBOX.Text = selectedTanulok.SzulDate;
                anyaTBOX.Text = selectedTanulok.AnyjaNeve;
                lakcimTBOX.Text = selectedTanulok.Lakcim;
            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedTanulok.VezNev = veznevTBOX.Text;
            selectedTanulok.UtoNev = utonevTBOX.Text;
            selectedTanulok.SzulDate = szuldateTBOX.Text;
            selectedTanulok.AnyjaNeve = anyaTBOX.Text;
            selectedTanulok.Lakcim = lakcimTBOX.Text;
            var StudentRepo = new GenericRepository<Student>(App.databasePath);
            StudentRepo.update(selectedTanulok);
            ReadDatabase();

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var StudentRepo = new GenericRepository<Student>(App.databasePath);
            StudentRepo.delete(selectedTanulok);
            ReadDatabase();

        }
    }
}
