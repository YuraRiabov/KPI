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
            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
            }
            using (FileStream fs = fileInfo.Open(FileMode.Append))
            {
                byte[] line = Encoding.Default.GetBytes(ComposeClientString(client));
                fs.Write(line, 0, line.Length);
            }
        }
        public List<Client> ReadAllClients(string fileName)
        {
            List<Client> clients = new List<Client>();
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] byteText = new byte[fs.Length];
                    fs.Read(byteText, 0, byteText.Length);
                    string text = Encoding.Default.GetString(byteText);
                    clients = SplitTextToClients(text);
                } 
            }
            return clients;
        }
        public string ComposeClientString(Client client)
        {
            return $"{client.Name},{client.ComingTime},{client.LeavingTime}\n";
        }
        public Client SplitLineToClient(string line)
        {
            string[] attributes = line.Split(',');
            Client client = new Client();
            client.Name = attributes[0];
            client.ComingTime = TimeOnly.Parse(attributes[1]);
            client.LeavingTime = TimeOnly.Parse(attributes[2]);
            return client;
        }
        public List<Client> SplitTextToClients(string text)
        {
            List<Client> clients = new List<Client>();
            string[] lines = text.Split("\n");
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    clients.Add(SplitLineToClient(line)); 
                }
            }
            return clients;
        }
    }
}
