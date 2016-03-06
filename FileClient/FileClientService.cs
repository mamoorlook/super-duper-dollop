using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using PasswordCrackerCentralized;

namespace FileClient
{
    internal class FileClientService
    {
        private int SERVER_PORT;

        public FileClientService(int SERVER_PORT)
        {
            this.SERVER_PORT = SERVER_PORT;
        }

        public void Start()
        {
            Trace.TraceInformation("Client started");

            Console.Write("Type filename: ");
            String fileToReceive = Console.ReadLine();
            Console.WriteLine();

            using (
                TcpClient client = new TcpClient("192.168.1.38", SERVER_PORT))
            {

                using (Stream stream = client.GetStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(fileToReceive);
                    writer.Flush();

                    using (FileStream fileStream = new FileStream(@"C:\Files\FileClient.txt", FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }
        

        Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}