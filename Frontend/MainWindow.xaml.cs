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
using FrontEnd.DataProviders;

namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    #pragma warning disable LRT001
    public partial class MainWindow : Window
    {
        private List<AvailableBook> AvailableBooks { get; set; }
        private List<Book> BorrowedBooks { get; set; }

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
            BorrowedComboFilter.SelectedIndex = Constants.DEFAULT_FILTER_INDEX; // Select Title by default
        }

        private void SetAvailableBookList()
        {
            try
            {
                var books = AvailableBookDataProvider.GetAvailableBooks().Select(book => new AvailableBook(book)).ToList();
                AvailableBooks = books;
                AvailableBooksDataGrid.ItemsSource = AvailableBooks;
                AvailableBooksDataGrid.IsReadOnly = true;
                foreach (var column in AvailableBooksDataGrid.Columns)
                {
                    column.IsReadOnly = true;
                }
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SetBorrowedBookList()
        {
            try
            {
                var books = BorrowedBookDataProvider.GetBorrowedBooks().ToList();
                BorrowedBooks = books;
                BorrowedBooksDataGrid.ItemsSource = BorrowedBooks;
                BorrowedBooksDataGrid.IsReadOnly = true;
                foreach (var column in BorrowedBooksDataGrid.Columns)
                {
                    column.IsReadOnly = true;
                }
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LendBooks_Click(object sender, RoutedEventArgs arguments)
        {
            List<AvailableBook> selectedBooks = AvailableBooksDataGrid.SelectedItems.Cast<AvailableBook>().ToList();
            if (!selectedBooks.Any())
            {
                MessageBox.Show("No books selected!");
                return;
            }

            var window = new BorrowingDetailsWindow(selectedBooks);
            if (window.ShowDialog() ?? false)
            {
                SetAvailableBookList();
                SetBorrowedBookList();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs arguments)
        {
            List<AvailableBook> selectedBooks = AvailableBooksDataGrid.SelectedItems.Cast<AvailableBook>().ToList();
            if (!selectedBooks.Any())
            {
                MessageBox.Show("No books selected!");
                return;
            }

            try
            {
                var iSBNS = selectedBooks.Select(book => book.ISBN).ToArray();
                AvailableBookDataProvider.DeleteBooks(iSBNS);
                SetAvailableBookList();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ReturnBooks_Click(object sender, RoutedEventArgs arguments)
        {
            List<Book> selectedBooks = BorrowedBooksDataGrid.SelectedItems.Cast<Book>().ToList();
            if (!selectedBooks.Any())
            {
                MessageBox.Show("No books selected!");
                return;
            }

            var iSBNS = selectedBooks.Select(book => book.ISBN).ToArray();

            try
            {
                BorrowedBookDataProvider.ReturnBooks(iSBNS);

                SetAvailableBookList();
                SetBorrowedBookList();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ModifyBook_Click(object sender, RoutedEventArgs arguments)
        {
            List<AvailableBook> selectedBooks = AvailableBooksDataGrid.SelectedItems.Cast<AvailableBook>().ToList();
            if (selectedBooks.Count != 1)
            {
                MessageBox.Show("Select only 1 row!");
                return;
            }

            var window = new ModifyBookWindow(selectedBooks[0]);
            if (window.ShowDialog() ?? false)
            {
                SetAvailableBookList();
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs arguments)
        {
            var window = new AddBookWindow();
            if (window.ShowDialog() ?? false)
            {
                SetAvailableBookList();
            }
        }

        private void AvailableFilter_TextChanged(object sender, EventArgs e)
        {
            List<AvailableBook> newList;
            switch (AvailableComboFilter.Text)
            {
                case "ISBN":
                    newList = AvailableBooks
                        .Where(x => x.ISBN.ToString().Contains(AvailableFilter.Text)).ToList();
                    break;

                case "Title":
                    newList = AvailableBooks
                        .Where(x => x.Title.ToLower().Contains(AvailableFilter.Text.ToLower())).ToList();
                    break;

                case "Authors":
                    newList = AvailableBooks
                        .Where(x => x.Authors.ToLower().Contains(AvailableFilter.Text.ToLower())).ToList();
                    break;

                case "Publisher":
                    newList = AvailableBooks
                        .Where(x => x.Publisher.ToLower().Contains(AvailableFilter.Text.ToLower())).ToList();
                    break;

                default:
                    newList = AvailableBooks
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
                    newList = BorrowedBooks
                        .Where(x => x.ISBN.ToString().Contains(BorrowedFilter.Text)).ToList();
                    break;

                case "Title":
                    newList = BorrowedBooks
                        .Where(x => x.Title.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Authors":
                    newList = BorrowedBooks
                        .Where(x => x.Authors.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Publisher":
                    newList = BorrowedBooks
                        .Where(x => x.Publisher.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Borrower first name":
                    newList = BorrowedBooks
                        .Where(x => x.BorrowerFirstName.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                case "Borrower last name":
                    newList = BorrowedBooks
                        .Where(x => x.BorrowerLastName.ToLower().Contains(BorrowedFilter.Text.ToLower())).ToList();
                    break;

                default:
                    newList = BorrowedBooks
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

        private void RefreshAvailableButton_Click(object sender, RoutedEventArgs e)
        {
            SetAvailableBookList();
        }

        private void RefreshBorrowedButton_Click(object sender, RoutedEventArgs e)
        {
            SetBorrowedBookList();
        }
    }
}
