using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Common;
using FrontEnd.DataProviders;

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

            _selectedBooks = selectedBooks;

            BorrowingDetailsDataGrid.ItemsSource = _selectedBooks;
        }

        private void BorrowingDetailsCancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void LendBooks_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSelection())
            {
                try
                {
                    List<long> iSBNS = new List<long>();
                    _selectedBooks.ForEach(book => iSBNS.Add(book.ISBN));
                    AvailableBookDataProvider.LendBooks(iSBNS.ToArray());
                    this.DialogResult = true;
                    Close();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
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

            if (ClientShouldReturnBooks.SelectedDate <= DateTime.Now)
            {
                MessageBox.Show("Please select a date from future!");
                return false;
            }

            return true;
        }
    }
}
