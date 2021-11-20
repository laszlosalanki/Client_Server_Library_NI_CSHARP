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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void AvaliableBookListBox_SelectionChanged(object sender, SelectionChangedEventArgs arguments)
        {
            // TODO
        }

        private void BorrowedBookListBox_SelectionChanged(object sender, SelectionChangedEventArgs arguments)
        {
            // TODO
        }

        private void LendBooks_Click(object sender, RoutedEventArgs arguments)
        {
            var window = new BorrowingDetailsWindow(null);
            if (window.ShowDialog() ?? false)
            {
                // TODO: update ListBox
            }
        }

        private void ReturnBooks_Click(object sender, RoutedEventArgs arguments)
        {
            // TODO
        }
    }
}
