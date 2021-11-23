using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly List<AvailableBook> _selectedBooks;
        public BorrowingDetailsWindow(List<AvailableBook> selectedBooks)
        {
            InitializeComponent();

            if (selectedBooks != null)
            {
                _selectedBooks = new List<AvailableBook>(selectedBooks);
            }
            else
            {
                _selectedBooks = new List<AvailableBook>();
            }

            BorrowingDetailsDataGrid.ItemsSource = _selectedBooks;
        }

        private void BorrowingDetailsCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LendBooks_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ClientFirstName.Text) || string.IsNullOrEmpty(ClientLastName.Text) || ClientShouldReturnBooks.SelectedDate == null)
            {
                MessageBox.Show("Missing arguments!");
                return;
            }
        }
    }
}
