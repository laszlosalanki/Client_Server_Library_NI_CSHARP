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
            if (ValidateSelection())
            {
                MessageBox.Show("TODO");
                return;
            }
        }

        private bool ValidateSelection()
        {
            if (string.IsNullOrEmpty(ClientFirstName.Text))
            {
                MessageBox.Show("Field 'First Name' should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(ClientLastName.Text))
            {
                MessageBox.Show("Field 'Last Name' should not be empty!");
                return false;
            }

            if (!ClientShouldReturnBooks.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select the date, when the client should return the given book(s)!");
                return false;
            }

            return true;
        }
    }
}
