using System.Windows;
using Common;

namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for BorrowingDetailsWindow.xaml
    /// </summary>
    #pragma warning disable LRT001
    public partial class BorrowingDetailsWindow : Window
    {
        private readonly Book _book;
        public BorrowingDetailsWindow(Book book)
        {
            InitializeComponent();

            if (book != null)
            {
                _book = book;
            }
            else
            {
                _book = new Book();
            }
        }

        private void BorrowingDetailsCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
