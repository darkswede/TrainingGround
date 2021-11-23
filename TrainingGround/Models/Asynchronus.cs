using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TrainingGround.Models
{
    public class Asynchronus
    {
        public async Task Run()
        {
            var content = await GetContentAsync();
            Console.WriteLine(content);
        }

        public async Task<string> GetContentAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
