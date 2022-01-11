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
            if (ValidateBook())
            {
                try
                {
                    if (!AvailableBookDataProvider.IsIsbnExists(long.Parse(ISBN.Text)))
                    {
                        AvailableBookDataProvider.AddBook(new Book(long.Parse(ISBN.Text), Title.Text, Authors.Text, Publisher.Text, ReleaseDate.SelectedDate, null, null, null, null));
                        this.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("ISBN number is already registered.");
                        this.DialogResult = false;
                    }
                }
                catch (InvalidOperationException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void CancelClick(object sender, RoutedEventArgs arguments)
        {
            this.DialogResult = false;
            Close();
        }

        private bool ValidateBook()
        {
            if (string.IsNullOrEmpty(ISBN.Text))
            {
                MessageBox.Show("ISBN should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(Title.Text))
            {
                MessageBox.Show("Title should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(Authors.Text))
            {
                MessageBox.Show("Authors should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(Publisher.Text))
            {
                MessageBox.Show("Publisher should not be empty!");
                return false;
            }

            if (!ReleaseDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Release date should not be empty!");
                return false;
            }

            if (ReleaseDate.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Release date must be selected from the past!");
                return false;
            }

            return true;
        }
    }
}
