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
    /// Interaction logic for ModifyBookWindow.xaml
    /// </summary>
#pragma warning disable LRT001
#pragma warning disable CA1305
    public partial class ModifyBookWindow : Window
    {
        private readonly AvailableBook _book;
        public ModifyBookWindow(AvailableBook book)
        {
            InitializeComponent();

            _book = book;

            FillFields();
        }

        private void FillFields()
        {
            ISBN.Text = _book.ISBN.ToString();
            Title.Text = _book.Title;
            Authors.Text = _book.Authors;
            Publisher.Text = _book.Publisher;
            ReleaseDate.Text = _book.ReleaseDate.ToString();
        }

        private void SaveFieldsClick(object sender, RoutedEventArgs arguments)
        {
            if (ValidateChanges())
            {
                try
                {
                    AvailableBookDataProvider.UpdateBook(new Book(_book));
                    this.DialogResult = true;
                    Close();
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

        private bool ValidateChanges()
        {
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
