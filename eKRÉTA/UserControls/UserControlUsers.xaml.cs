using eKRÉTA.Models;
using System.Windows;
using System.Windows.Controls;

namespace eKRÉTA.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlUsers.xaml
    /// </summary>
    public partial class UserControlUsers : UserControl
    {
        List<User> users;
        User selectedUser;
        public UserControlUsers()
        {
            InitializeComponent();
            szerepkor.ItemsSource = Enum.GetNames(typeof(UserRole)); //Név kiírása
            //szerepkor.ItemsSource = Enum.GetValues(typeof(UserRole)); //Érték kiírása
            users = new List<User>();
            ReadDatabase();
            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void ReadDatabase()
        {
            fullnameTextBox.Text = "";
            usernameTextBox.Text = "";
            //NEW!
            passwordBox.Password = "";

            //Alapértelmezett érték a comboboxnak
            szerepkor.SelectedItem = Enum.GetName(typeof(UserRole), UserRole.Guest);


            //Generic Repo használata
            var UserRepo = new GenericRepository<User>(App.databasePath);
            var query = UserRepo.GetAll();
            datagridUsers.ItemsSource = query;

            //Régi kód

            /*using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<User>();
                var query = sQLiteConnection.Table<User>().ToList();
                if (query != null)
                {
                    datagridUsers.ItemsSource = query;
                }
            }*/

            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //MODIFIED
            string selectedRoleName = (string)szerepkor.SelectedItem; //Kiválasztott szerepkör neve
            UserRole selectedRole = (UserRole)Enum.Parse(typeof(UserRole), selectedRoleName); //Kiszedjük a szerepkört teljes egészében.
            int selectedRoleValue = (int)selectedRole; //Kiszedjük a szerepkör IDjét

            User user = new User(usernameTextBox.Text, fullnameTextBox.Text, PasswordHelper.HashPassword(passwordBox.Password), selectedRoleValue);

            //User user = new User()
            //{
            //    FelhasznaloNev = usernameTextBox.Text,
            //    TeljesNev = fullnameTextBox.Text
            //};


            
            var UserRepo = new GenericRepository<User>(App.databasePath);
            UserRepo.insert(user);
            ReadDatabase();


            //Régi kód
            /* using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
             {
                 sQLiteConnection.CreateTable<User>();
                 sQLiteConnection.Insert(user);
             }
             ReadDatabase();*/
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var UserRepo = new GenericRepository<User>(App.databasePath);
            UserRepo.delete(selectedUser);
            ReadDatabase();

            //Régi kód
            /*using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<User>();
                sQLiteConnection.Delete(selectedUser);
            }
            */

        }

        private void datagridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

            if (datagridUsers.SelectedItem != null)
            {
                selectedUser = (User)datagridUsers.SelectedItem;
                fullnameTextBox.Text = selectedUser.TeljesNev;
                usernameTextBox.Text = selectedUser.FelhasznaloNev;
                szerepkor.Text = selectedUser.UserRoleName;
            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedUser.FelhasznaloNev = usernameTextBox.Text;
            selectedUser.TeljesNev = fullnameTextBox.Text;

            string selectedRoleName = (string)szerepkor.SelectedItem; //Kiválasztott szerepkör neve
            UserRole selectedRole = (UserRole)Enum.Parse(typeof(UserRole), selectedRoleName); //Kiszedjük a szerepkört teljes egészében.
            int selectedRoleValue = (int)selectedRole; //Kiszedjük a szerepkör IDjét

            selectedUser.UserRole = selectedRoleValue;

            // NEW!
            if (passwordBox.Password != "")
            {
                selectedUser.Jelszo = PasswordHelper.HashPassword(passwordBox.Password);
            }


            var UserRepo = new GenericRepository<User>(App.databasePath);
            UserRepo.update(selectedUser);
            ReadDatabase();

            //Régi kód

            /*using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<User>();
                sQLiteConnection.Update(selectedUser);
            }

            ReadDatabase();*/

        }


    }
}
