using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    /// Interaction logic for ViewBookWindow.xaml
    /// </summary>
    public partial class ViewBookWindow : Window
    {
        private LibraryManagementContext context = new LibraryManagementContext();
        private int selectedBook = -1;
        public ViewBookWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            List<Book> books = context.Books.Select(s => s).ToList();
            dg.ItemsSource = null;
            dg.ItemsSource = books;
        }

        private void Reset()
        {
            selectedBook = -1;
            LoadBooks();
            txtName.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            dpPublishDate.Text = string.Empty;
            searchName.Text = string.Empty;

        }

        private void dgSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg.ItemsSource == null)
            {
                selectedBook = -1;
                return;
            }
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
            DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)cell.Content).Text.ToString();
            if (!int.TryParse(id, out selectedBook))
            {
                return;
            }
            Book book = (sender as DataGrid).SelectedItem as Book;
            txtName.Text = book.BookName;
            txtAuthor.Text = book.Author;
            txtPublisher.Text = book.Publisher;
            txtQuantity.Text = book.Quantity.ToString();
            txtPrice.Text = book.Price.ToString();
            dpPublishDate.Text = book.PublishDate.ToString();
        }

        private void btnRefreshClicked(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void btnSearchClicked(object sender, RoutedEventArgs e)
        {
            string input = searchName.Text;
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            List<Book> books = context.Books
                .Where(b => b.BookName.ToLower().Contains(input.ToLower()))
                .ToList();
            dg.ItemsSource = null;
            dg.ItemsSource = books;
        }

        private void btnUpdateClicked(object sender, RoutedEventArgs e)
        {
            if (selectedBook == -1)
            {
                MessageBox.Show("Please choose a book to delete?");
                return;
            }
            string name = txtName.Text;
            string author = txtAuthor.Text;
            string publisher = txtPublisher.Text;
            string quantity = txtQuantity.Text;
            string price = txtPrice.Text;
            try
            {
                DateOnly publishedDate = DateOnly.Parse(dpPublishDate.Text);
                Book book = context.Books.Where(b => b.BookId == selectedBook).FirstOrDefault();
                book.BookName = name;
                book.Author = author;
                book.Publisher = publisher;
                book.PublishDate = publishedDate;
                book.Quantity = int.Parse(quantity);
                book.Price = decimal.Parse(price);
                context.Books.Update(book);
                context.SaveChanges();
                Reset();
                MessageBox.Show("update success");
            } catch (Exception ex)
            {
                MessageBox.Show("Update Fail!");
            }
        }

        private void btnDeleteClicked(object sender, RoutedEventArgs e)
        {
            if (selectedBook == -1)
            {
                MessageBox.Show("Please choose a book to delete?");
                return;
            }
            MessageBoxResult res = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No)
            {
                return;
            }

            Book book = context.Books.Where(b => b.BookId ==  selectedBook).FirstOrDefault();
            context.Books.Remove(book);
            context.SaveChanges();
            Reset();
        }
    }
}
