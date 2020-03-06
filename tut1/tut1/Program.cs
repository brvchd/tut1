using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace tut1
{
    class Program
    {
        static async Task Main(string[] args) 
        {
            if(args[0] == null)
            {
                throw new Exception("You didn't ini")
            }


            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(args[0]);

            var regex = new Regex(@"[a-z][A-Z]@");

            var content = response.Content;
            var matches = regex.Matches(content.ToString());

            foreach ( var match in matches)
            {
                WriteLine(match.ToString());
            }

        }
    }
}
