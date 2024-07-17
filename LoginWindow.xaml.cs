using LibraryManagement.Models;
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
using System.Windows.Shapes;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
   public partial class LoginWindow : Window
    {
        private LibraryManagementContext context = new LibraryManagementContext();
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // get email and password
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            // validate
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                MessageBox.Show("Please provide all the input field");
                return;
            }

            // get librarian
            Librarian lb = context.Librarians.Where(l => l.Email == email && l.Password == password).FirstOrDefault();
            if (lb == null)
            {
                MessageBox.Show("Wrong email or password");
                return;
            }

            // display Main Window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
