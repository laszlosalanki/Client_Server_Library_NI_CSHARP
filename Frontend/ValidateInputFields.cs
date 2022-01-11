using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FrontEnd
{
#pragma warning disable LRT001
    public static class ValidateInputFields
    {
        public static bool ValidateAddBookWindowFields(TextBox iSBN, TextBox title, TextBox authors, TextBox publisher, DatePicker releaseDate)
        {
            if (string.IsNullOrEmpty(iSBN.Text))
            {
                MessageBox.Show("ISBN should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(title.Text))
            {
                MessageBox.Show("Title should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(authors.Text))
            {
                MessageBox.Show("Authors should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(publisher.Text))
            {
                MessageBox.Show("Publisher should not be empty!");
                return false;
            }

            if (!releaseDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Release date should not be empty!");
                return false;
            }

            if (releaseDate.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Release date must be selected from the past!");
                return false;
            }

            return true;
        }

        public static bool ValidateModifyBookWindowFields(TextBox title, TextBox authors, TextBox publisher, DatePicker releaseDate)
        {
            if (string.IsNullOrEmpty(title.Text))
            {
                MessageBox.Show("Title should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(authors.Text))
            {
                MessageBox.Show("Authors should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(publisher.Text))
            {
                MessageBox.Show("Publisher should not be empty!");
                return false;
            }

            if (!releaseDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Release date should not be empty!");
                return false;
            }

            if (releaseDate.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Release date must be selected from the past!");
                return false;
            }

            return true;
        }

        public static bool ValidateLendBooksWindowFields(TextBox clientFirstName, TextBox clientLastName, DatePicker clientShouldReturnBooks)
        {
            if (string.IsNullOrEmpty(clientFirstName.Text))
            {
                MessageBox.Show("Field 'First Name' should not be empty!");
                return false;
            }

            if (string.IsNullOrEmpty(clientLastName.Text))
            {
                MessageBox.Show("Field 'Last Name' should not be empty!");
                return false;
            }

            if (!clientShouldReturnBooks.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select the date, when the client should return the given book(s)!");
                return false;
            }

            if (clientShouldReturnBooks.SelectedDate <= DateTime.Now)
            {
                MessageBox.Show("Please select a date from future!");
                return false;
            }

            return true;
        }
    }
}
