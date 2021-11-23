using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;

namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    #pragma warning disable LRT001
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetFilterComboBoxes();
            SetAvailableBookList();
            SetBorrowedBookList();
        }

        private void SetFilterComboBoxes()
        {
            // Available
            AvailableComboFilter.ItemsSource = Constants.AVAILABLE_FILTER_OPTIONS;
            AvailableComboFilter.SelectedIndex = Constants.DEFAULT_FILTER_INDEX; // Select Title by default

            // Borrowed
            BorrowedComboFilter.ItemsSource = Constants.BORROWED_FILTER_OPTIONS;
            BorrowedComboFilter.SelectedIndex = Constants.DEFAULT_FILTER_INDEX;
        }

        private void SetAvailableBookList()
        {
            AvailableBooksDataGrid.ItemsSource = Constants.TEMPORAL_DATA_AVAILABLE;
            foreach (var column in AvailableBooksDataGrid.Columns)
            {
                column.IsReadOnly = true;
            }
        }

        private void SetBorrowedBookList()
        {
            BorrowedBooksDataGrid.ItemsSource = Constants.TEMPORAL_DATA_BORROWED;
            foreach (var column in BorrowedBooksDataGrid.Columns)
            {
                column.IsReadOnly = true;
            }
        }

        private void AvailableBooksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs arguments)
        {
            // TODO
        }

        private void BorrowedBooksDaraGrid_SelectionChanged(object sender, SelectionChangedEventArgs arguments)
        {
            // TODO
        }

        private void LendBooks_Click(object sender, RoutedEventArgs arguments)
        {
            List<AvailableBook> selectedBooks = AvailableBooksDataGrid.SelectedItems.Cast<AvailableBook>().ToList();
            if (selectedBooks.Count == 0)
            {
                MessageBox.Show("No books selected!");
                return;
            }

            var window = new BorrowingDetailsWindow(selectedBooks);
            if (window.ShowDialog() ?? false)
            {
                // TODO: update ListBox
            }
        }

        private void ReturnBooks_Click(object sender, RoutedEventArgs arguments)
        {
            // TODO
        }

        private void AvailableFilter_TextChanged(object sender, EventArgs e)
        {
            List<AvailableBook> newList;
            switch (AvailableComboFilter.Text)
            {
                case "ISBN":
                    newList = Constants.TEMPORAL_DATA_AVAILABLE
                        .Where(x => x.ISBN.ToString().Contains(AvailableFilter.Text)).ToList();
                    break;

                case "Title":
                    newList = Constants.TEMPORAL_DATA_AVAILABLE
                        .Where(x => x.Title.ToLower().Contains(AvailableFilter.Text.ToLower())).ToList();
                    break;

                case "Authors":
                    newList = Constants.TEMPORAL_DATA_AVAILABLE
                        .Where(x => x.Authors.ToLower().Contains(AvailableFilter.Text.ToLower())).ToList();
                    break;

                case "Publisher":
                    newList = Constants.TEMPORAL_DATA_AVAILABLE
                        .Where(x => x.Publisher.ToLower().Contains(AvailableFilter.Text.ToLower())).ToList();
                    break;

                default:
                    newList = Constants.TEMPORAL_DATA_AVAILABLE
                        .Where(x => x.Title.ToLower().Contains(AvailableFilter.Text.ToLower())).ToList();
                    break;
            }

            AvailableBooksDataGrid.ItemsSource = null;
            AvailableBooksDataGrid.ItemsSource = newList;
        }

        private void BorrowedFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Book> newList;
            switch (BorrowedComboFilter.Text)
            {
                case "ISBN":
                    newList = Constants.TEMPORAL_DATA_BORROWED
                        .Where(x => x.ISBN.ToString().Contains(BorrowedFilter.Text)).ToList();
                    break;

                case "Title":
                    newList = Constants.TEMPORAL_DATA_BORROWED
                        .Where(x => x.Title.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Authors":
                    newList = Constants.TEMPORAL_DATA_BORROWED
                        .Where(x => x.Authors.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Publisher":
                    newList = Constants.TEMPORAL_DATA_BORROWED
                        .Where(x => x.Publisher.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Borrower first name":
                    newList = Constants.TEMPORAL_DATA_BORROWED
                        .Where(x => x.BorrowerFirstName.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Borrower last name":
                    newList = Constants.TEMPORAL_DATA_BORROWED
                        .Where(x => x.BorrowerLastName.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                default:
                    newList = Constants.TEMPORAL_DATA_BORROWED
                        .Where(x => x.Title.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;
            }

            BorrowedBooksDataGrid.ItemsSource = null;
            BorrowedBooksDataGrid.ItemsSource = newList;
        }

        private void BorrowedFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                BorrowedFilter.Text = string.Empty;
            }
        }

        private void AvailableFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                AvailableFilter.Text = string.Empty;
            }
        }
    }
}
