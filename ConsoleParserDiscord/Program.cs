using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json; // <- Download his in NuGet packages

// Before use this code you must download NewtonSoft in NuGet packages.

namespace ConsoleParserDiscord
{
    public class Channel
    {
        // Fields into key. You can convert json file to C# class here -> https://json2csharp.com/
        public string id { get; set; } 
        public string name { get; set; }
    }

    public class Root
    {
        //Fields, which stored class Channel inside yourself. You can generate class by json file here -> https://json2csharp.com/
        public string name { get; set; }
        public List<Channel> channels { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string path_json = "path_to_json"; // Instead "path_to_json" write your path to json file. This json file must match a class above (In my example this classes Channel and Root)

            WebRequest request = WebRequest.Create(path_json);
            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                List<Root> roots = JsonConvert.DeserializeObject<List<Root>>(responseFromServer);

                foreach (Root root in roots)
                {
                    foreach (Channel channel in root.channels)
                    {
                        // You can write objects in console. In my example this channel.name and channel.id
                        Console.WriteLine(channel.name);
                        Console.WriteLine(channel.id);
                    }
                }
            }
        }

        
    }
}
