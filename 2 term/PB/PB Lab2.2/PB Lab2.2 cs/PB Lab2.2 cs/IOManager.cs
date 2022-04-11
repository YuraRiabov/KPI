﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._2_cs
{
    public class IOManager
    {
        public void GetClients(string fileName)
        {
            FileManager fileManager = new FileManager();
            string name;
            string? comingTime;
            string? leavingTime;
            List<Client> clients = fileManager.ReadAllClients(fileName);
            Console.WriteLine("To input a new client, press a, else press Enter");
            string? input = Console.ReadLine();
            while(input == "a")
            {
                Console.Write("Enter clients name: ");
                name = Console.ReadLine() ?? " ";
                Console.Write("Enter coming time: ");
                comingTime = Console.ReadLine();
                Console.Write("Enter leaving time: ");
                leavingTime = Console.ReadLine();
                if (CheckInput(comingTime, leavingTime, clients))
                {
                    Client client = new Client();
                    client.Name = name;
                    client.ComingTime = TimeOnly.Parse(comingTime);
                    client.LeavingTime = TimeOnly.Parse(leavingTime);
                    clients.Add(client);
                    fileManager.WriteClient(client, fileName);
                    Console.WriteLine("Successfully added");
                }
                else
                {
                    Console.WriteLine("Either time format is wrong or timespan isn't free, client not added");
                }
                Console.WriteLine("To input a new client, press a, else press Enter");
                input = Console.ReadLine();
            }
        }
        public bool CheckInput(string? comingTime, string? leavingTime, List<Client> clients)
        {
            TimeOnly firstTime;
            TimeOnly secondTime;
            if (TimeOnly.TryParse(comingTime, out firstTime) && TimeOnly.TryParse(leavingTime, out secondTime))
            {
                foreach (Client client in clients)
                {
                    if (firstTime < client.LeavingTime && firstTime > client.ComingTime ||
                        secondTime < client.LeavingTime && secondTime > client.ComingTime ||
                        firstTime < client.ComingTime && secondTime > client.LeavingTime ||
                        firstTime > secondTime ||
                        firstTime < Client.WorkStartTime ||
                        secondTime > Client.WorkEndTime)
                    {
                        return false;
                    } 
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
