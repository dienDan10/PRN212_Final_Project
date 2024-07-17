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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private LibraryManagementContext context = new LibraryManagementContext();
        public ReportWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            List<Book> books = context.Books.Select(s => s).ToList();
            lvBooks.ItemsSource = null;
            lvBooks.ItemsSource = books;
            lvBooks.SelectedValuePath = "BookId";
        }

       

        private void btnSearchBookClicked(object sender, RoutedEventArgs e)
        {
            string input = txtSearchBook.Text;
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please input book name!");
                return;
            }
            List<Book> books = context.Books.Where(b => b.BookName.ToLower().Contains(input.ToLower())).ToList();
            lvBooks.ItemsSource = null;
            lvBooks.ItemsSource = books;
            lvBooks.SelectedValuePath = "BookId";
        }

        private void btnRefreshClicked(object sender, RoutedEventArgs e)
        {
            txtSearchBook.Text = string.Empty;
            LoadBooks();
            lvBorrowBooks.ItemsSource = null;
            lbQuantity.Content = string.Empty;
            lbReport.Content = string.Empty;
        }

        private void btnBorrowingClicked(object sender, RoutedEventArgs e)
        {
            List<Borrow> borrows = context.Borrows.Where(b => b.Status == BorrowStatus.BORROWING)
                .Include(b => b.Student)
                .Include(b => b.Book)
                .ToList();
            lvBorrowBooks.ItemsSource = null;
            lvBorrowBooks.ItemsSource= borrows;
            lvBorrowBooks.SelectedValuePath = "Id";
            lbReport.Content = "Total Book Being Borrowed:";
            lbQuantity.Content = borrows.Count.ToString();
        }

        private void btnReturnedClicked(object sender, RoutedEventArgs e)
        {
            List<Borrow> borrows = context.Borrows.Where(b => b.Status == BorrowStatus.RETURNED)
                .Include(b => b.Student)
                .Include(b => b.Book)
                .OrderByDescending(b => b.BorrowDate)
                .ToList();
            lvBorrowBooks.ItemsSource = null;
            lvBorrowBooks.ItemsSource = borrows;
            lvBorrowBooks.SelectedValuePath = "Id";
            lbReport.Content = "Total Book Has Been Returned:";
            lbQuantity.Content = borrows.Count.ToString();
        }

        private void lvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBooks.ItemsSource == null || lvBooks.SelectedValue == null)
            {
                return;
            }
            // get book id
            int bookId = int.Parse(lvBooks.SelectedValue.ToString());
            // get list of borrows
            List<Borrow> borrows = context.Borrows.Select(s => s)
                .Include(b => b.Student)
                .Include(b => b.Book)
                .Where(b => b.Book.BookId == bookId)
                .OrderByDescending(b => b.BorrowDate)
                .ToList();
            // display 
            lvBorrowBooks.ItemsSource = null;
            lvBorrowBooks.ItemsSource = borrows;
            lvBorrowBooks.SelectedValuePath = "Id";

        }
    }
}
