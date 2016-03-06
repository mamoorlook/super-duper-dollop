using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FileTcpServer
{
    internal class FileService
    {
        private readonly String root;
        private readonly int port;

        public FileService(string rootCatalog, int port)
        {
            root = rootCatalog;
            this.port = port;
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, port);
            server.Start();
            Trace.TraceInformation("Servre started on " + port);
            while (true)
            {
                using (TcpClient client = server.AcceptTcpClient())
                {
                    Console.WriteLine("Handlin' a client");
                    using (NetworkStream stream = client.GetStream())
                    {
                        // recieve 'command' i.e. which file to send back
                        String file = new StreamReader(stream).ReadLine();
                        String fullFilename = root + @"\" + file;
                        Trace.TraceInformation("Requested file: " + fullFilename);


                        using (FileStream fileStream = new FileStream(fullFilename, FileMode.Open))
                        {
                            fileStream.CopyTo(stream);
                        }

                        Trace.TraceInformation("Close this client");
                    }
                }

            }
        }
    }
}