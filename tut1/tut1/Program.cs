using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace tut1
{
    class Program
    {
        public static async Task Main(string[] args) 
        {
            var url = args.Length > 0 ? args[0] : throw new ArgumentException();
            // var url = "https://www.pja.edu.pl";

            using var httpclient = new HttpClient();
            try
            {
                var response = await httpclient.GetAsync(url);

                if(response.IsSuccessStatusCode)
                { 
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var responseContent = await response.Content.ReadAsStringAsync();

                    var emailAddresses = regex.Matches(responseContent);

                    var setOfAddresses = new HashSet<string>();

                    if (emailAddresses.Count > 0)
                    {
                        foreach (var emailAddress in emailAddresses)
                        {
                            if(setOfAddresses.Contains(emailAddress.ToString()))
                            {
                                
                            }
                            else
                            {
                                setOfAddresses.Add(emailAddress.ToString());
                                WriteLine($"Found email: {emailAddress.ToString()}");
                            }
                            
                        }
                        
                    }
                    else
                    {
                        WriteLine("No email addresses were found");
                    }
                }
            }
            catch (ArgumentException)
            {
                WriteLine("Such url was not found");
            }

        }
    }
}
