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
            if (ValidateInputFields.ValidateModifyBookWindowFields(Title, Authors, Publisher, ReleaseDate))
            {
                try
                {
                    AvailableBookDataProvider.UpdateBook(new Book(long.Parse(ISBN.Text), Title.Text, Authors.Text, Publisher.Text, ReleaseDate.SelectedDate.Value, null, null, null, null));
                    this.DialogResult = true;
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
