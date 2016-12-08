using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Utils
{
    public class WebRead
    {
        private readonly string what;

        public WebRead(string what)
        {
            this.what = what;
        }

        public string Ask()
        {
            Console.WriteLine("Please enter the address for {0}.\n> ", what);
            var address = Console.ReadLine();

            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            var responseTask = request.GetResponseAsync();
            Task.WaitAll(responseTask);
            HttpWebResponse response = (HttpWebResponse)responseTask.Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream);

                return readStream.ReadToEnd();
            }
            
            return null;
        }
    }
}