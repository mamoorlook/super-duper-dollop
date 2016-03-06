using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTcpServer
{
    class Program
    {
        private const String RootCatalog = @"C:\Files";
        private const int PORT = 7777;

        static void Main(string[] args)
        {
            Chunker ch = new Chunker();
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener("./FileTcpServerLog.txt"));

            FileService service = new FileService(RootCatalog,PORT);
            service.Start();

        }
    }
}
