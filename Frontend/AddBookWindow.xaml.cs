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
using Common;
using FrontEnd.DataProviders;

namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
#pragma warning disable LRT001
    public partial class AddBookWindow : Window
    {
        private readonly AvailableBook _book;
        public AddBookWindow()
        {
            InitializeComponent();

            _book = new AvailableBook();
        }

        private void AddClick(object sender, RoutedEventArgs arguments)
        {
            if (ValidateInputFields.ValidateAddBookWindowFields(ISBN, Title, Authors, Publisher, ReleaseDate))
            {
                try
                {
                    if (AvailableBookDataProvider.IsIsbnAvailable(long.Parse(ISBN.Text)))
                    {
                        AvailableBookDataProvider.AddBook(new Book(long.Parse(ISBN.Text), Title.Text, Authors.Text, Publisher.Text, ReleaseDate.SelectedDate.Value, null, null, null, null));
                        this.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("ISBN number is already registered.");
                    }
                }
                catch (InvalidOperationException e)
                {
                    MessageBox.Show(e.Message);
                    this.DialogResult = false;
                }
            }
        }

        private void CancelClick(object sender, RoutedEventArgs arguments)
        {
            this.DialogResult = false;
        }

        private void ISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var ch in ISBN.Text)
            {
                if (!char.IsDigit(ch))
                {
                    if (ISBN.Text.Length == 1)
                    {
                        ISBN.Text = string.Empty;
                    }
                    else
                    {
                        ISBN.Text = ISBN.Text[.. (ISBN.Text.Length - 1)];
                        ISBN.SelectionStart = ISBN.Text.Length;
                        ISBN.SelectionLength = 0;
                    }
                    MessageBox.Show("Enter decimal numbers only!");
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
            }
        }
    }
}
