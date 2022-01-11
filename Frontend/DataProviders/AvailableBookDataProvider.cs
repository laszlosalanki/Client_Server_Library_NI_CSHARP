using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

namespace FrontEnd.DataProviders
{
#pragma warning disable LRT001
    public class AvailableBookDataProvider
    {
        private const string _url = "http://localhost:5233/api/books/";

        public static IEnumerable<Book> GetAvailableBooks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(new Uri($"{_url}availableAll")).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(rawData);
                    return books;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static bool IsIsbnExists(long iSBN)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(new Uri($"{_url}isbn/{iSBN}")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(rawData);
                    return result;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void AddBook(Book book)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(book);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(new Uri($"{_url}add"), content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateBook(Book book)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(book);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(new Uri($"{_url}update"), content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteBook(long iSBN)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(new Uri($"{_url}delete/{iSBN}")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteBooks(long[] iSBNS)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(iSBNS);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                // TODO
            }
        }

        public static void LendBooks(long[] iSBNS)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(iSBNS);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(new Uri($"{_url}lend"), content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
