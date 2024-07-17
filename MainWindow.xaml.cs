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

namespace LibraryManagement
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

        private void btnAddStudentClicked(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.Show();
        }

        private void btnViewStudentClicked(object sender, RoutedEventArgs e)
        {
            ViewStudentWindow viewStudentWindow = new ViewStudentWindow();
            viewStudentWindow.Show();
        }

        private void btnAddBookClicked(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Show();
        }

        private void btnViewBookClicked(object sender, RoutedEventArgs e)
        {
            ViewBookWindow viewBookWindow = new ViewBookWindow();
            viewBookWindow.Show();
        }

        private void btnBorrowBookClicked(object sender, RoutedEventArgs e)
        {
            BorrowBookWindow borrowBookWindow = new BorrowBookWindow();
            borrowBookWindow.Show();
        }

        private void btnReturnBookClicked(object sender, RoutedEventArgs e)
        {
            ReturnBookWindow returnBookWindow = new ReturnBookWindow();
            returnBookWindow.Show();
        }

        private void btnReportClicked(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
        }
    }
}