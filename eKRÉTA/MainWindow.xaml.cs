using eKRÉTA.UserControls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eKRÉTA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void studentMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            taskPanel.Children.Clear();
            taskPanel.Children.Add(new UserControlStudents());
        }

        private void teacherMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            taskPanel.Children.Clear();
            taskPanel.Children.Add(new UnderConstruction());
        }

        private void classMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            taskPanel.Children.Clear();
            taskPanel.Children.Add(new UnderConstruction());
        }

        private void roomMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            taskPanel.Children.Clear();
            taskPanel.Children.Add(new UnderConstruction());
        }

        private void userMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            taskPanel.Children.Clear();
            taskPanel.Children.Add(new UserControlUsers());

        }

        private void exitMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}