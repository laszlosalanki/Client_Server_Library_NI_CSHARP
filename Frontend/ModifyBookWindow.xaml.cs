using Common;
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

            if (book != null)
            {
                _book = book;
            }
            else
            {
                _book = new AvailableBook();
            }

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
            MessageBox.Show("TODO");
        }

        private void CancelClick(object sender, RoutedEventArgs arguments)
        {
            Close();
        }
    }
}
