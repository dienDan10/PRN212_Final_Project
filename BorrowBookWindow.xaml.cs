using LibraryManagement.configs;
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
    /// Interaction logic for BorrowBookWindow.xaml
    /// </summary>
    public partial class BorrowBookWindow : Window
    {
        
        private LibraryManagementContext context = new LibraryManagementContext();
        public BorrowBookWindow()
        {
            InitializeComponent();
            LoadStudents();
            LoadBooks();
        }

        private void LoadStudents()
        {
            List<Student> students = context.Students.Select(s => s).ToList();
            lvStudents.ItemsSource = null;
            lvStudents.ItemsSource = students;
            lvStudents.SelectedValuePath = "StudentId";
        }

        private void LoadBooks()
        {
            List<Book> books = context.Books.Select(s => s).ToList();
            lvBooks.ItemsSource = null;
            lvBooks.ItemsSource = books;
            lvBooks.SelectedValuePath = "BookId";
        }

        private void btnRefreshClicked(object sender, RoutedEventArgs e)
        {
            LoadStudents();
            LoadBooks();
            txtSearchStudent.Text = string.Empty;
            txtSearchBook.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDate.Text = string.Empty;
        }

        private void btnSearchStudentClicked(object sender, RoutedEventArgs e)
        {
            string input = txtSearchStudent.Text;
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please input student name.");
                return;
            }
            List<Student> students = context.Students.Where(s => s.Name.ToLower().Contains(input.ToLower())).ToList();
            lvStudents.ItemsSource = null;
            lvStudents.ItemsSource = students;
        }

        private void btnSearchBookClicked(object sender, RoutedEventArgs e)
        {
            string input = txtSearchBook.Text;
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please input book name.");
                return;
            }
            List<Book> books = context.Books.Where(b => b.BookName.ToLower().Contains(input.ToLower())).ToList();
            lvBooks.ItemsSource = null;
            lvBooks.ItemsSource = books;
        }

        private void btnIssueBookClicked(object sender, RoutedEventArgs e)
        {
            // check student and book selected
            if (lvStudents.SelectedValue == null)
            {
                MessageBox.Show("Please choose a student!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (lvBooks.SelectedValue == null)
            {
                MessageBox.Show("Please choose a book!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // check quantity valid
            string quantity = txtQuantity.Text;
            if (string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please enter book quantity!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            bool parseResult = int.TryParse(quantity, out int quan);
            if (!parseResult)
            {
                MessageBox.Show("Quantity must be a number!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (quan <= 0)
            {
                MessageBox.Show("Quantity must greater than 0!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int bookId = int.Parse(lvBooks.SelectedValue.ToString());
            Book book = context.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            if (book.Quantity < quan)
            {
                MessageBox.Show("Book quantity is not enough!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // check date valid
            string date = txtDate.Text;
            if (string.IsNullOrEmpty(date))
            {
                MessageBox.Show("Please enter issue date!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DateOnly dateOnly = DateOnly.Parse(date);
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            if (dateOnly > today)
            {
                MessageBox.Show("Issue date cannot be in the future!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // create borrow object
            int studentId = int.Parse(lvStudents.SelectedValue.ToString());
            Student student = context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
            Borrow borrow = new Borrow() {
                BorrowDate = dateOnly,
                Student = student,
                Book = book,
                Status = BorrowStatus.BORROWING,
                Quantity = quan
            };

            // save to db
            try
            {
                context.Borrows.Add(borrow);
                // decrease book quantity
                book.Quantity = book.Quantity - quan;
                LoadBooks();
                context.SaveChanges();
                MessageBox.Show("Issue book success!");
            } catch (Exception ex)
            {
                MessageBox.Show("Issue book fail!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}
