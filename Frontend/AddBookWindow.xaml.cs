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
                MessageBox.Show("TODO");
            }
        }

        private void CancelClick(object sender, RoutedEventArgs arguments)
        {
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

            // TODO: check if ReleaseDate is later than the actual date?

            // TODO: check if the ISBN number exists?

            return true;
        }
    }
}
