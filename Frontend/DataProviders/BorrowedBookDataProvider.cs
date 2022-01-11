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
    public class BorrowedBookDataProvider
    {
        private const string _url = "http://localhost:5233/api/books/";

        public static IEnumerable<Book> GetBorrowedBooks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(new Uri(_url + "borrowedAll")).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(rawData);
                    return books;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void ReturnBooks(long[] iSBNS)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(iSBNS);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(new Uri($"{_url}return"), content).Result;
            }
        }
    }
}
