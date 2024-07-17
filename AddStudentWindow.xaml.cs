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
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
   public partial class AddStudentWindow : Window
    {
        private LibraryManagementContext context;
        public AddStudentWindow()
        {
            InitializeComponent();
            context = new LibraryManagementContext();
        }

        private void btnAddClicked(object sender, RoutedEventArgs e)
        {
            // get input info
            string name = txtName.Text;
            string code = txtCode.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            // validate
            if (string.IsNullOrEmpty(name) || 
                string.IsNullOrEmpty(code) || 
                string.IsNullOrEmpty (phone) || 
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please provide all the information");
                return;
            }
            // check for code duplicate
            Student s = context.Students
                .Where(s => s.StudentCode.ToLower() == code.ToLower())
                .FirstOrDefault();
            if (s != null)
            {
                MessageBox.Show("Student with is code exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // add new student
            Student student = new Student() { 
                Name = name,
                StudentCode = code,
                Phone = phone,
                Email = email,
            };
            try
            {
                context.Students.Add(student);
                context.SaveChanges();
                MessageBox.Show("Add student success!");
            } catch (Exception ex)
            {
                MessageBox.Show("Add student fail!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRefreshClicked(object sender, RoutedEventArgs e)
        {
            txtName.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
    }
}
