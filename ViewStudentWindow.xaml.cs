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
    /// Interaction logic for ViewStudentWindow.xaml
    /// </summary>
    public partial class ViewStudentWindow : Window
    {
        private LibraryManagementContext context = new LibraryManagementContext();
        private int selectedStudent = -1;
        public ViewStudentWindow()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            // get all students
            List<Student> students = context.Students.Select(s => s).ToList();
            dg.ItemsSource = null;
            dg.ItemsSource = students;
        }

        private void Reset()
        {
            LoadStudents();
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            searchCode.Text = string.Empty;
            searchName.Text = string.Empty;
        }

        private void btnSearchCodeClicked(object sender, RoutedEventArgs e)
        {
            string input = searchCode.Text;
            List<Student> students = context.Students.Where(s => s.StudentCode.ToLower().Contains(input.ToLower())).ToList();
            dg.ItemsSource = null;
            dg.ItemsSource = students;
        }

        private void btnSearchNameClicked(object sender, RoutedEventArgs e)
        {
            string input = searchName.Text;
            List<Student> students = context.Students.Where(s => s.Name.ToLower().Contains(input.ToLower())).ToList();
            dg.ItemsSource = null;
            dg.ItemsSource = students;
        }

        private void btnRefreshClicked(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void dgSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg.ItemsSource == null)
            {
                selectedStudent = -1;
                return;
            }

            if (dg.SelectedItems.Count == 0)
            {
                selectedStudent = -1;
                return;
            }

            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
            DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)cell.Content).Text.ToString();
            if (!int.TryParse(id, out selectedStudent))
            {
                return;
            }
            // load information
            Student student = (sender as DataGrid).SelectedItem as Student;
            txtCode.Text = student.StudentCode;
            txtName.Text = student.Name;
            txtPhone.Text = student.Phone;
            txtEmail.Text = student.Email;

        }

        private void btnUpdateClicked(object sender, RoutedEventArgs e)
        {
            // check for select student
            if (selectedStudent == -1)
            {
                MessageBox.Show("Please select a student to update");
                return;
            }
            // get student info
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string code = txtCode.Text;

            // update student
            Student student = context.Students.Where(s => s.StudentId == selectedStudent).FirstOrDefault();
            if (student != null)
            {
                student.Name = name;
                student.Phone = phone;
                student.Email = email;
                student.StudentCode = code;
                context.Students.Update(student);
                context.SaveChanges();
                MessageBox.Show("update success!");
            }

            // Reload grid
            LoadStudents();
        }

        private void btnDeleteClicked(object sender, RoutedEventArgs e)
        {
            // check for select student
            if (selectedStudent == -1)
            {
                MessageBox.Show("Please select a student to update");
                return;
            }

            // confirmation
            MessageBoxResult res = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No)
            {
                return;
            }

            // delete student
            Student student = context.Students.Where(s => s.StudentId == selectedStudent).FirstOrDefault();
            context.Students.Remove(student);
            context.SaveChanges();
            Reset();
        }
    }
}
