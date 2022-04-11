using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._2_cs
{
    public class FileManager
    {
        public void WriteClient(Client client, string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            using (BinaryWriter bw = new BinaryWriter(file.Open(FileMode.OpenOrCreate)))
            {
                bw.Write(client.Name);
                bw.Write(client.ComingTime.ToString());
                bw.Write(client.LeavingTime.ToString());
            }
        }
        public List<Client> ReadAllClients(string fileName)
        {
            List<Client> clients = new List<Client>();
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                while (br.PeekChar() != -1)
                {
                    Client client = new Client();
                    client.Name = br.ReadString();
                    client.ComingTime = TimeOnly.Parse(br.ReadString());
                    client.LeavingTime = TimeOnly.Parse(br.ReadString());
                    clients.Add(client);
                }
            }
            return clients;
        }
    }
}
