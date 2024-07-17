using LibraryManagement.configs;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ReturnBookWindow.xaml
    /// </summary>
    public partial class ReturnBookWindow : Window
    {
        private LibraryManagementContext context = new LibraryManagementContext();
        public ReturnBookWindow()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            List<Student> students = context.Students.Select(s => s).ToList();
            lvStudents.ItemsSource = null;
            lvStudents.ItemsSource = students;
            lvStudents.SelectedValuePath = "StudentId";
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

        private void btnRefreshClicked(object sender, RoutedEventArgs e)
        {
            LoadStudents();
            lvBorrowBooks.ItemsSource = null;
            txtSearchStudent.Text = string.Empty;
        }

        private void lvStudentsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvStudents.ItemsSource == null || lvStudents.SelectedValue == null)
            {
                return;
            }
            RenderBorrowBook();
        }

        private void btnReturnClicked(object sender, RoutedEventArgs e)
        {
            // check for borrow selected
            if (lvBorrowBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select a book to return!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // ask for confirmation 
            MessageBoxResult res = MessageBox.Show("Do you want to return this book?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
            {
                return;
            }

            try
            {
                // return book
                int selectedBook = int.Parse(lvBorrowBooks.SelectedValue.ToString());
                Borrow borrow = context.Borrows.Where(b => b.Id == selectedBook).FirstOrDefault();
                borrow.Status = BorrowStatus.RETURNED;
                DateOnly returnDate = DateOnly.FromDateTime(DateTime.Now);
                borrow.ReturnDate = returnDate;
                context.Borrows.Update(borrow);
                MessageBox.Show("Return book successful");
                // update quantity of book
                Book book = context.Books.Where(b => b.BookId == borrow.BookId).FirstOrDefault();
                book.Quantity = book.Quantity + borrow.Quantity;
                context.Books.Update(book);
                context.SaveChanges();
                // re-render borrow list of students
                RenderBorrowBook();
            } catch (Exception ex)
            {
                MessageBox.Show("Return book fail!");
            }
        }

        private void RenderBorrowBook()
        {
            // get student id
            int studentId = int.Parse(lvStudents.SelectedValue.ToString());
            // get all book borrowing by this student 
            List<Borrow> borrows = context.Borrows
                .Where(b => b.StudentId == studentId && b.Status == BorrowStatus.BORROWING)
                .Include(b => b.Book)
                .ToList();
            // display borrow book
            lvBorrowBooks.ItemsSource = null;
            lvBorrowBooks.ItemsSource = borrows;
            lvBorrowBooks.SelectedValuePath = "Id";
        }
    }
}
