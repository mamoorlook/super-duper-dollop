using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized;

namespace FileClient
{
    class Program
    {
        private const int SERVER_PORT = 7777;

        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener("./FileTcpClientLog.txt"));

            FileClientService client = new FileClientService(SERVER_PORT);
            client.Start();
            Cracking cracker = new Cracking();
            cracker.RunCracking();

        }

        
    }


}
