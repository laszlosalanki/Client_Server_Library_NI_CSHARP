using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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
        }

        private void LendBooks_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputFields.ValidateLendBooksWindowFields(ClientFirstName, ClientLastName, ClientShouldReturnBooks))
            {
                try
                {
                    List<Book> dateUpdatedSelectedBooks = new List<Book>();
                    for (int i = 0; i < _selectedBooks.Count; i++)
                    {
                        dateUpdatedSelectedBooks.Add(new Book(_selectedBooks[i], ClientFirstName.Text, ClientLastName.Text, DateTime.Now, ClientShouldReturnBooks.SelectedDate.Value));
                    }
                    AvailableBookDataProvider.LendBooks(dateUpdatedSelectedBooks.ToArray());
                    this.DialogResult = true;
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
            }
        }
    }
}
