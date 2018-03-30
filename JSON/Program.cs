using Newtonsoft.Json;
using SportscardSystem.Models;
using System.IO;

namespace JSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = File.OpenText(@"D:\Desktop\TELERIK\ALPHA\Module-3\Sportscard-project\Seed.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Client client = (Client)serializer.Deserialize(file, typeof(Client));
                System.Console.WriteLine(client.ToString());
                
            }
        }
    }
}
