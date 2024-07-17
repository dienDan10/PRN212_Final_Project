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
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private LibraryManagementContext context = new LibraryManagementContext();
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void btnAddClicked(object sender, RoutedEventArgs e)
        {
            // get book information
            string name = txtName.Text;
            string author = txtAuthor.Text;
            string publisher = txtPublisher.Text;
            DateOnly publishedDate = DateOnly.Parse(txtDate.Text);
            string quantity = txtQuantity.Text;
            string price = txtPrice.Text;

            try
            {
                Book book = new Book()
                {
                    BookName = name,
                    Author = author,
                    Publisher = publisher,
                    PublishDate = publishedDate,
                    Quantity = int.Parse(quantity),
                    Price = decimal.Parse(price)
                };

                context.Books.Add(book);
                context.SaveChanges();
                MessageBox.Show("Add book successful");

            } catch(Exception ex)
            {
                MessageBox.Show("Add book unsuccessful!");
            }
        }

        private void btnRefreshClicked(object sender, RoutedEventArgs e)
        {
            txtAuthor.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtName.Text = string.Empty;
        }
    }
}
