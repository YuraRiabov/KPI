using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._2_cs
{
    internal class Program
    {
        static void Main()
        {
            IOManager iOManager = new IOManager();
            FileManager fileManager = new FileManager();
            const string fileName = "Clients.dat";
            iOManager.GetClients(fileName);
            List<Client> clients = fileManager.ReadAllClients(fileName);
            foreach (Client client in clients)
            {
                Console.WriteLine(client.Name);
            }
        }
    }
}